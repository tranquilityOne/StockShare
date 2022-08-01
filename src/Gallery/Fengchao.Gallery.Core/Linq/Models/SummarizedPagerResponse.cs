namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Query result with paging info and summary.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    /// <typeparam name="TSummary">Type of response summary.</typeparam>
    public class SummarizedPagerResponse<TItem, TSummary> : PagerResponse<TItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedPagerResponse{TItem, TSummary}"/> class.
        /// </summary>
        public SummarizedPagerResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedPagerResponse{TItem, TSummary}"/> class.
        /// </summary>
        /// <param name="pager">A <see cref="Pager"/> object.</param>
        public SummarizedPagerResponse(Pager pager)
        {
            PageIndex = pager.PageIndex;
            PageSize = pager.PageSize;
        }

        /// <summary>
        /// Summary of response result.
        /// </summary>
        public TSummary Summary { get; set; } = default!;
    }
}