
namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Request model with paging and query condition.
    /// </summary>
    /// <typeparam name="TCondition">Type of query condition.</typeparam>
    public class PagerRequest<TCondition> : SortedPager
    {
        /// <summary>
        /// Query condition.
        /// </summary>
        public TCondition Condition { get; set; } = default!;
    }
}
