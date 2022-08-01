using Microsoft.Extensions.DependencyInjection;

namespace StockShare.Core.Contexts
{
    /// <summary>
    /// Extension methods for adding custom contexts to an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ContextExtensions
    {
        /// <summary>
        /// Adds custom contexts to application's reqeust pipeline.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddContexts(this IServiceCollection services)
        {
            return services.AddScoped<OperationContext>();
        }
    }
}
