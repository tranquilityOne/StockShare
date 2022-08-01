using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Fengchao.Gallery.Logging.Middlewares
{
    /// <summary>
    /// A middleware that enriches serilog context for request pipline.
    /// </summary>
    public class SerilogMiddleware
    {
        private const string TraceIdKey = "trace-id";
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new intance of the <see cref="SerilogMiddleware"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the remaining middleware in the request pipeline.</param>
        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Request handling method.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
        /// <returns>A task that represents the result.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey(TraceIdKey))
            {
                var traceId = context.Request.Headers[TraceIdKey].ToArray().FirstOrDefault()?.Split(",")[0];
                context.TraceIdentifier = traceId;
            }

            LogContext.PushProperty("TraceId", context.TraceIdentifier);
            LogContext.PushProperty("IpAddress", context.Connection.RemoteIpAddress);
            await _next(context);
        }
    }
}
