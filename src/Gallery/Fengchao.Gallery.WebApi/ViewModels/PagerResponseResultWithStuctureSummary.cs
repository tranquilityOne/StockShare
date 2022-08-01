using Fengchao.Gallery.Core.Linq;

namespace Fengchao.Gallery.WebApi.ViewModels
{
    /// <summary>
    /// Response with paging info and summary.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    /// <typeparam name="TSummary">Type of response summary.</typeparam>
    public class PagerResponseResultWithStuctureSummary<TItem, TSummary>
        : ResponseResult<PagerResponseWithStructureSummary<TItem, TSummary>>
        where TSummary : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagerResponseResultWithStuctureSummary{TItem, TSummary}"/> class.
        /// </summary>
        public PagerResponseResultWithStuctureSummary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagerResponseResultWithStuctureSummary{TItem, TSummary}"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public PagerResponseResultWithStuctureSummary(PagerResponseWithStructureSummary<TItem, TSummary> data)
            : base(data)
        {
        }
    }
}
