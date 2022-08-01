using Fengchao.Gallery.Core.Linq;

namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Response with summary.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    /// <typeparam name="TSummary">Type of response summary.</typeparam>
    public class SummarizedEnumerableResponseResult<TItem, TSummary>
        : ResponseResult<SummarizedEnumerableResponse<TItem, TSummary>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedEnumerableResponseResult{TItem, TSummary}"/> class.
        /// </summary>
        public SummarizedEnumerableResponseResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedEnumerableResponseResult{TItem, TSummary}"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public SummarizedEnumerableResponseResult(SummarizedEnumerableResponse<TItem, TSummary> data)
            : base(data)
        {
        }
    }
}
