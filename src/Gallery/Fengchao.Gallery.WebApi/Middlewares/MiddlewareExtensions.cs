using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Fengchao.Gallery.WebApi.Middlewares
{
    /// <summary>
    /// Provides extension methods for adding middlewares to the application's request pipeline.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Adds <see cref="HandleExceptionMiddleware"/> to the application's request pipeline.
        /// </summary>
        /// <param name="app">An <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="defaultErrorCode">The default error code.</param>
        /// <param name="hideErrorMessage">
        /// Whether the error message should be hided in <see cref="HttpResponse"/>.
        /// </param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseHandleExceptionMiddleware(
            this IApplicationBuilder app, int defaultErrorCode = -1, bool hideErrorMessage = true)
        {
            return app.UseMiddleware<HandleExceptionMiddleware>(defaultErrorCode, hideErrorMessage);
        }

        /// <summary>
        /// Adds <see cref="AccessLogMiddleware"/> to the application's request pipeline.
        /// </summary>
        /// <param name="app">An <see cref="IApplicationBuilder"/> instance.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseAccessLogMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AccessLogMiddleware>();
        }

        /// <summary>
        /// Adds <see cref="AccessLogMiddleware"/> to the application's request pipeline.
        /// </summary>
        /// <param name="app">An <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="bypassRoutes">Route list of which access records should not be recorded. Case insensitive.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseAccessLogMiddleware(
            this IApplicationBuilder app, IEnumerable<string> bypassRoutes)
        {
            return app.UseMiddleware<AccessLogMiddleware>(bypassRoutes);
        }
    }
}
