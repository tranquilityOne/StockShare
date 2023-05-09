using Microsoft.Extensions.DependencyInjection;
using StockShare.Services.Collection;

namespace StockShare.Services
{
    /// <summary>
    /// Extension methods for adding services to an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds business services to application's reqeust pipeline.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add HttpClientFactory
            services.AddHttpClient();

            services.AddScoped<IStockBasicService, TuShareStockBasicService>();
            services.AddScoped<IDailyQuotesService, TuShareDailyQuotesService>();
            services.AddScoped<TuShareApiRequestService>()
                .AddScoped<TuShareFinaIndicatorService>();
            return services;
        }
    }
}
