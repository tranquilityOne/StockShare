using Fengchao.Gallery.WebApi.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Fengchao.StockShare.Swagger
{
    internal static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = Assembly.GetEntryAssembly()!.GetName().Name,
                        Version = "v1"
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. " +
                        "Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Scheme = "oauth2"
                        },
                        Array.Empty<string>()
                    }
                });

                c.DocumentFilter<SwaggerEnumDescriptionFilter>();
                c.SchemaFilter<SwaggerExcludeFilter>();
                c.OperationFilter<SwaggerHeaderFilter>();

                var paths = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                foreach (var path in paths)
                {
                    c.IncludeXmlComments(path);
                }
            });

            return services;
        }
    }
}
