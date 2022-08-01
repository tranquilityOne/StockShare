using System.Collections.Generic;
using System.Linq;

namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Query result with paging info.
    /// </summary>
    /// <typeparam name="TItem">Type of response item.</typeparam>
    public class PagerResponse<TItem> : Pager
    {
        private int totalCount = 0;

        /// <summary>
        /// Response items.
        /// </summary>
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();

        /// <summary>
        /// Total count.
        /// </summary>
        public int TotalCount
        {
            get
            {
                return totalCount > 0
                    ? totalCount
                    : 0;
            }
            set
            {
                totalCount = value;
            }
        }

        /// <summary>
        /// Total page.
        /// </summary>
        public int PageTotal
        {
            get
            {
                return (int)System.Math.Ceiling((double)TotalCount / PageSize);
            }
        }
    }
}
