using AspNetCoreRateLimit;
using Fengchao.Gallery.Core.Json;
using Fengchao.Gallery.WebApi.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using CommonErrorCodes = StockShare.Common.ErrorCodes;

namespace StockShare.RateLimit
{
    internal static class RateLimitExtensions
    {
        public static IServiceCollection AddRateLimit(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimit"));
            services.PostConfigure<IpRateLimitOptions>(options =>
            {
                options.QuotaExceededResponse = new QuotaExceededResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    ContentType = "application/json",
                    Content = new StatusResponseResult
                    {
                        Code = (int)CommonErrorCodes.QuotaExceeded,
                        Message = "Quota exceeded. Maximum allowed: {0} per {1}. Please try again in {2} second(s)."
                    }.ToJsonString(continueWithStringFormat: true)
                };
            });

            services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddMemoryCache();
            services.AddInMemoryRateLimiting();

            return services;
        }
    }
}
