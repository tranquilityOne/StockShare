using Fengchao.Gallery.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using CommonErrorCodes = StockShare.Common.ErrorCodes;

namespace StockShare.Filters
{
    /// <summary>
    /// A filter that is used for validating model state.
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <inheritdoc/>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new OkObjectResult(new StatusResponseResult
                {
                    Code = (int)CommonErrorCodes.IllegalRequest,
                    Message = string.Join(
                        " ",
                        context.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(x => x.ErrorMessage))
                });
            }
        }
    }
}
