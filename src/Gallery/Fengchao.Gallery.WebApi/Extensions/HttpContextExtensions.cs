using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Fengchao.Gallery.WebApi.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="HttpRequest"/>.
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Builds request url from the given <see cref="HttpContext"/> instance.
        /// </summary>
        /// <param name="context">A <see cref="HttpContext"/> instance.</param>
        /// <returns>Request url.</returns>
        public static string BuildRequestUrl(this HttpContext context)
        {
            var requestUri = new UriBuilder(
                context.Request.Scheme,
                context.Request.Host.Host,
                context.Connection.LocalPort,
                context.Request.Path,
                context.Request.QueryString.Value);

            return requestUri.ToString();
        }

        /// <summary>
        /// Reads all characters within length limit from the request stream asynchronously and returns them
        /// as one string.
        /// </summary>
        /// <param name="context">A <see cref="HttpContext"/> instance.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>A string with all characters read from the request stream.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if count is negative</exception>
        public static async Task<string> ReadRequestContentAsync(this HttpContext context, int count = 8 * 1024)
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

                            while ((length = await request.Body.ReadAsync(buffer, 0, bufferLength)) > 0)
                            {
                                // length of buffer string may not be equal to the length of buffer stream (e.g., file stream)
                                var bufferStr = Encoding.UTF8.GetString(buffer);
                                var leftLength = count - cachedLength;
                                var expectedLength = Math.Min(leftLength, length);
                                var strLength = leftLength >= length ? bufferStr.Length : leftLength;

                                sbRequestContent.Append(bufferStr, 0, strLength);

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
                            while ((await request.Body.ReadAsync(buffer, 0, bufferLength)) > 0)
                            {
                                var bufferStr = Encoding.UTF8.GetString(buffer);
                                sbRequestContent.Append(bufferStr, 0, bufferStr.Length);
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


        /// <summary>
        /// Builds stringified request record for given <see cref="HttpContext"/> instance.
        /// </summary>
        /// <param name="context">A <see cref="HttpContext"/> instance.</param>
        /// <returns>Stringified request record.</returns>
        public static async Task<string> BuildRequestRecordAsync(this HttpContext context)
        {
            var request = context.Request;
            var txtBody = string.Empty;

            if (request.ContentLength.HasValue)
            {
                if (request.Body.CanSeek)
                {
                    try
                    {
                        request.Body.Seek(0, SeekOrigin.Begin);
                        var sr = new StreamReader(request.Body);

                        if (request.ContentLength > 8 * 1024)
                        {
                            var buffer = new byte[Convert.ToInt32(4 * 1024)];
                            await request.Body.ReadAsync(buffer, 0, buffer.Length);

                            txtBody = $"{Encoding.UTF8.GetString(buffer)}...";
                        }
                        else
                        {
                            // Synchronous operations are disallowed here.
                            txtBody = await sr.ReadToEndAsync();
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
                else
                {
                    txtBody = $"Request body doesn't support seeking, failed to read the content.";
                }
            }

            object? requestBody;

            try
            {
                requestBody = JsonConvert.DeserializeObject(txtBody);
            }
            catch
            {
                requestBody = txtBody;
            }

            var requestUri = new UriBuilder(
                request.Scheme,
                request.Host.Host,
                context.Connection.LocalPort,
                request.Path,
                request.QueryString.Value);

            var requestRecord = new
            {
                Uri = requestUri.ToString(),
                Schema = request.Method,
                Body = requestBody,
                request.Headers
            };

            return JsonConvert.SerializeObject(requestRecord);
        }
    }
}
