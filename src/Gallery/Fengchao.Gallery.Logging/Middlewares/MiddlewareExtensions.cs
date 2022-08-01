using Microsoft.AspNetCore.Builder;

namespace Fengchao.Gallery.Logging.Middlewares
{
    /// <summary>
    /// Provides extension methods for adding middlewares to the application's request pipeline.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Adds <see cref="SerilogMiddleware"/> to the application's request pipeline.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseSerilogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SerilogMiddleware>();
        }
    }
}
