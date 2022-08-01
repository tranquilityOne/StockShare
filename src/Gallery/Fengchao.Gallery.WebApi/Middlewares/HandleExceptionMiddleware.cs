using Fengchao.Gallery.Core.Errors;
using Fengchao.Gallery.Core.Json;
using Fengchao.Gallery.WebApi.ViewModels;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Fengchao.Gallery.WebApi.Middlewares
{
    /// <summary>
    /// Represents a middleware, which can be used to handle exceptions.
    /// </summary>
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly int _defaultErrorCode;
        private readonly bool _hideErrorMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/></param>
        /// <param name="defaultErrorCode">The default error code.</param>
        /// <param name="hideErrorMessage">
        /// Whether the error message should be hided in <see cref="HttpResponse"/>. Hides error message in production
        /// environment is recommended, and the default value is set to <see langword="true"/>.
        /// </param>
        public HandleExceptionMiddleware(
            RequestDelegate next,
            int defaultErrorCode = -1,
            bool hideErrorMessage = true)
        {
            _next = next;
            _defaultErrorCode = defaultErrorCode;
            _hideErrorMessage = hideErrorMessage;
        }

        /// <summary>
        /// Invokes current middleware.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task InvokeAsync(
            HttpContext context,
            ILogger<HandleExceptionMiddleware> logger)
        {
            try
            {
                // calling the next delegate/middleware in the pipeline
                await _next(context);
                return;
            }
            catch (RpcException rpcEx)
            {
                try
                {
                    // parsing custom gRPC error
                    var detailJsonString = rpcEx.Status.Detail;
                    var codedEx = JsonConvert.DeserializeObject<CodedException>(detailJsonString)!;
                    logger.LogWarning($"rpc custom error handled. Error: {codedEx}");
                    await WriteResponseAsync(context, codedEx.Code, codedEx.Message);
                }
                catch (Exception ex)
                {
                    logger.LogError($"gRPC error handled. Error: {rpcEx}");
                    await WriteResponseAsync(context, _defaultErrorCode, ex.ToString());
                }
            }
            catch (CodedException codedEx)
            {
                logger.LogWarning($"Custom error handled. Error: {codedEx}");

                await WriteResponseAsync(context, codedEx.Code, codedEx.Message);
            }
            catch (Exception ex)
            {
                logger.LogError($"Unexpected error handled. Error: {ex}");

                await WriteResponseAsync(context, _defaultErrorCode, ex.ToString());
            }
        }

        private async Task WriteResponseAsync(
            HttpContext context, int errorCode, string errorMsg)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";

            var responseResult = new StatusResponseResult
            {
                Code = errorCode,
                Message = _hideErrorMessage ? string.Empty : errorMsg
            };

            await context.Response.WriteAsync(responseResult.ToJsonString());
        }
    }
}
