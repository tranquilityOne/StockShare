using Fengchao.Gallery.Core.Linq;

namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Response with paging info.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    public class PagerResponseResult<TItem> : ResponseResult<PagerResponse<TItem>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagerResponseResult{TItem}"/> class.
        /// </summary>
        public PagerResponseResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagerResponseResult{TItem}"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public PagerResponseResult(PagerResponse<TItem> data)
            : base(data)
        {
        }
    }
}
