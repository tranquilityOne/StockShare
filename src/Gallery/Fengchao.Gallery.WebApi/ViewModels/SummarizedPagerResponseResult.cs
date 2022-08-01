using Fengchao.Gallery.Core.Linq;

namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Response with paging info and summary.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    /// <typeparam name="TSummary">Type of response summary.</typeparam>
    public class SummarizedPagerResponseResult<TItem, TSummary>
        : ResponseResult<SummarizedPagerResponse<TItem, TSummary>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedPagerResponseResult{TItem, TSummary}"/> class.
        /// </summary>
        public SummarizedPagerResponseResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedPagerResponseResult{TItem, TSummary}"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public SummarizedPagerResponseResult(SummarizedPagerResponse<TItem, TSummary> data)
            : base(data)
        {
        }
    }
}
