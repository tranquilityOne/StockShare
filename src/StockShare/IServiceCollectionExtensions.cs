using AutoMapper;
using Fengchao.Gallery.Core.Configurations;
using Fengchao.Gallery.WebApi.HealthChecks;
using Fengchao.StockShare.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using StockShare.Core.Configuration;
using StockShare.Core.Contexts;
using StockShare.Data;
using StockShare.Filters;
using StockShare.Mappers;
using StockShare.ProtoLibs;
using StockShare.RateLimit;
using StockShare.Services;
using StockShare.SystemServices;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockShare
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddControllers(options =>
                {
                    options.SuppressAsyncSuffixInActionNames = true;

                    options.Filters.Add<ValidateModelStateAttribute>();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddNewtonsoftJson(options =>
                {
                    // It seems that swagger won't read MvcNewtonsoftJsonOptions, so we need to AddJsonOptions.
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                // options.ForwardLimit = 2;
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedHost;

                // Do not restrict to local network/proxy
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            // Configures and validates options.
            services.ConfigureAndValidate<JwtIssuerOptions>(configuration.GetSection("JwtBearerAuthentication"));
            services.ConfigureAndValidate<TuShareOptions>(configuration.GetSection("TuShare"));

            // Redis cache
            services.AddStackExchangeRedisCache(options =>
            {
                var connectionString = services
                    .BuildServiceProvider()
                    .GetRequiredService<IConfiguration>()
                    .GetConnectionString("Redis");

                options.Configuration = connectionString;
                options.InstanceName = Assembly.GetEntryAssembly()!.GetName().Name;
            });

            // Data layer
            services.AddDbContext(configuration.GetConnectionString("StockShareContext"));
            services.AddSingleton(sp =>
            {
                var redisConf = sp.GetService<IConfiguration>().GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(redisConf);
            });

            // Services
            services.AddHttpContextAccessor();
            services.AddJwtAuthentication();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserPolicy", builder =>
                {
                    builder.RequireRole("User");
                });
            });
            services.AddContexts();
            services.AddSystemServices();
            services.AddServices();

            // Mapping
            /*services.AddSingleton(provider =>
            {
                return new MapperConfiguration(expr =>
                {
                    var profileTypes = Assembly.GetEntryAssembly()!.DefinedTypes.Where(t => t.IsAssignableTo(typeof(Profile)));

                    foreach (var t in profileTypes)
                    {
                        Profile profile = (Profile)Activator.CreateInstance(t)!;

                        expr.AddProfile(profile);
                    }
                })
                .CreateMapper();
            });*/

            services.AddAutoMapper(typeof(BusinessMappingProfile));

            // Grpc clients
            services.AddGrpcServices(configuration);

            // Swagger
            services.AddSwagger();

            // Add Health checks
            services.AddHealthChecks()
                .AddMemoryHealthCheck()
                .AddRedis(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("Redis"))
                .AddPrivateMemoryHealthCheck(1024L * 1024L * 1024L);

            // Add rate limit
            services.AddRateLimit(configuration);

            return services;
        }

        private static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var jwtIssuerOptions = serviceProvider.GetRequiredService<IOptionsMonitor<JwtIssuerOptions>>().CurrentValue;

            var tokenValidationParamerters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = jwtIssuerOptions.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtIssuerOptions.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtIssuerOptions.Secret)),

                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.ClaimsIssuer = jwtIssuerOptions.Issuer;
                options.TokenValidationParameters = tokenValidationParamerters;
                options.SaveToken = true;

                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = ctx =>
                    {
                        var tokenService = ctx.HttpContext.RequestServices.GetRequiredService<ITokenService>();
                        var accessToken = ((JwtSecurityToken)ctx.SecurityToken).RawData!;

                        if (tokenService.IsAccessTokenBlocked(accessToken))
                        {
                            ctx.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            ctx.Fail("Access token has been blocked.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}
