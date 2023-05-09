using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace StockShare.Data
{
    /// <summary>
    /// Extension methods for adding db context to an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add db context.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContextPool<StockShareContext>((sp, options) =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

                // options.EnableSensitiveDataLogging(Debugger.IsAttached);
            });

            return services;
        }
    }
}
