using System.Collections.Generic;

namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Query result with summary.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    /// <typeparam name="TSummary">Type of response summary.</typeparam>
    public class SummarizedEnumerableResponse<TItem, TSummary>
    {
        /// <summary>
        /// Summary of response result.
        /// </summary>
        public TSummary Summary { get; set; } = default!;

        /// <summary>
        /// Response items.
        /// </summary>
        public IEnumerable<TItem> Items { get; set; } = default!;
    }
}
