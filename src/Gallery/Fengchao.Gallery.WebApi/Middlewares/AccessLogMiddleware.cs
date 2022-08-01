using Fengchao.Gallery.WebApi.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fengchao.Gallery.WebApi.Middlewares
{
    /// <summary>
    /// Represents a middleware, which can be used to log requests information.
    /// </summary>
    public class AccessLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<string> _bypassRoutes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessLogMiddleware"/>.
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/></param>
        public AccessLogMiddleware(
            RequestDelegate next)
        {
            _next = next;
            _bypassRoutes = Array.Empty<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessLogMiddleware"/>.
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/></param>
        /// <param name="bypassRoutes">
        /// Route list of which access records should not be recorded. Case insensitive.
        /// </param>
        public AccessLogMiddleware(
            RequestDelegate next,
            IEnumerable<string> bypassRoutes)
        {
            _next = next;
            _bypassRoutes = bypassRoutes;
        }

        /// <summary>
        /// Invokes current middleware.
        /// </summary>
        /// <param name="context"><see cref="HttpContext"/></param>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <returns>A task that represents the work.</returns>
        public async Task Invoke(
            HttpContext context,
            ILogger<AccessLogMiddleware> logger)
        {
            AttachEnrichProperties(context);

            await LogRequestBodyAsync(context, logger);

            await _next(context);
        }

        private static void AttachEnrichProperties(HttpContext httpContext)
        {
            try
            {
                // user id
                var userId = httpContext.User.Claims.SingleOrDefault(c =>
                    c.Type == ClaimTypes.NameIdentifier
                    || c.Type == ClaimTypes.Sid
                    || c.Type == "sid")
                    ?.Value;

                LogContext.PushProperty("UserId", userId);
            }
            catch
            {
            }

            LogContext.PushProperty("IpAddress", httpContext.Connection.RemoteIpAddress);
        }

        private async Task LogRequestBodyAsync(HttpContext httpContext, ILogger logger)
        {
            var requestPath = httpContext.Request.Path.Value ?? string.Empty;

            if (_bypassRoutes.Any(r => requestPath.Contains(r, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            var bypassAccessLoggerAttr = httpContext.GetEndpoint()?.Metadata?.GetMetadata<BypassAccessLoggerAttribute>();

            if (bypassAccessLoggerAttr != null)
            {
                // logs nothing
                return;
            }

            httpContext.Request.EnableBuffering();

            var requestBody = httpContext.Request.Body.CanSeek
                ? await ReadRequestContentAsync(httpContext)
                : "Request body doesn't support seeking, failed to read the content.";

            logger.LogInformation("request {@body}", requestBody);
        }

        static async Task<string> ReadRequestContentAsync(HttpContext context, int count = 8 * 1024)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var sbRequestContent = new StringBuilder();
            var request = context.Request;

            if (request.ContentLength.HasValue)
            {
                if (request.Body.CanSeek)
                {
                    try
                    {
                        request.Body.Seek(0, SeekOrigin.Begin);

                        var bufferLength = 4 * 1024;
                        var buffer = new byte[bufferLength];
                        int length;

                        if (request.ContentLength > count)
                        {
                            var cachedLength = 0;

                            while ((length = await request.Body.ReadAsync(buffer.AsMemory(0, bufferLength))) > 0)
                            {
                                // length of buffer string may not be equal to the length of buffer stream (e.g., file stream)
                                var bufferStr = Encoding.UTF8.GetString(buffer);
                                var leftLength = count - cachedLength;
                                var expectedLength = Math.Min(leftLength, length);
                                var strLength = leftLength >= length ? bufferStr.Length : leftLength;

                                sbRequestContent.Append(bufferStr);

                                cachedLength += expectedLength;

                                if (cachedLength >= count)
                                {
                                    break;
                                }
                            }

                            sbRequestContent.Append("...");
                        }
                        else
                        {
                            while ((length = await request.Body.ReadAsync(buffer.AsMemory(0, bufferLength))) > 0)
                            {
                                var bufferStr = Encoding.UTF8.GetString(buffer);
                                sbRequestContent.Append(bufferStr);
                            }
                        }
                    }
                    finally
                    {
                        if (request.Body.CanSeek)
                        {
                            request.Body.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }
            }

            return sbRequestContent.ToString();
        }
    }
}
