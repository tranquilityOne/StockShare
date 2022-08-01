using System.Collections.Generic;

namespace Fengchao.Gallery.Core.Linq.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="OrderBy"/>.
    /// </summary>
    public static class OrderByExtensions
    {
        /// <summary>
        /// Converts <see cref="OrderBy"/> list to equivalent string format.
        /// </summary>
        /// <param name="orderBy">The <see cref="OrderBy"/> list to convert.</param>
        /// <returns>String format of <see cref="OrderBy"/>.</returns>
        public static string ToSql(this List<OrderBy> orderBy)
        {
            return new SortedPager
            {
                OrderBy = orderBy
            }
            .GetSortString();
        }
    }
}
