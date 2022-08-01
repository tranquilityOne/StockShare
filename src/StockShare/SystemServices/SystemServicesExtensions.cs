using Microsoft.Extensions.DependencyInjection;

namespace StockShare.SystemServices
{
    /// <summary>
    /// Extension methods for adding system services to application's reqeust pipeline.
    /// </summary>
    public static class SystemServicesExtensions
    {
        /// <summary>
        /// Adds system services to application's reqeust pipeline.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddSystemServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITokenService, TokenService>();
        }
    }
}
