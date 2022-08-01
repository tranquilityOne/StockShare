using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Pager with sort.
    /// </summary>
    public class SortedPager : Pager
    {
        /// <summary>
        /// Gets or sets sorts of result data.
        /// </summary>
        public List<OrderBy>? OrderBy { get; set; }

        /// <summary>
        /// Converts <see cref="OrderBy"/> to equivalent string format.
        /// </summary>
        /// <returns>String format of <see cref="OrderBy"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Triggered if any item of <see cref="OrderBy.Field"/> is null or empty, or any whitespace is found inner 
        /// <see cref="OrderBy.Field"/>.
        /// </exception>
        public virtual string GetSortString()
        {
            if (OrderBy == null || OrderBy.Count == 0)
            {
                return string.Empty;
            }

            var orderList = new List<string>();

            foreach (var order in OrderBy)
            {
                order.Validate(new ValidationContext(order));

                orderList.Add($"{order.Field.Trim()} {(order.InAsc ? "asc" : "desc")}");
            }

            return string.Join(", ", orderList);
        }

        /// <summary>
        /// Builds a new <see cref="SortedPager"/> instance from sort string. PageIndex and PageSize will be 
        /// set to default values.
        /// </summary>
        /// <param name="sortString">Sort string.</param>
        /// <returns>A <see cref="SortedPager"/> instance.</returns>
        public static SortedPager FromSortString(string? sortString)
        {
            var sortedPager = new SortedPager
            {
                OrderBy = new List<OrderBy>()
            };

            if (string.IsNullOrWhiteSpace(sortString))
            {
                return sortedPager;
            }

            var sorts = sortString.Split(',');
            foreach (var sort in sorts)
            {
                var formattedSort = Regex.Replace(sort.Trim(), @"\s+", " ");
                var sortSplits = formattedSort.Split(' ');
                var orderByAsc = true;

                if (sortSplits.Length > 2)
                {
                    throw new ArgumentException($"Invalid sort '{sort}'");
                }
                else if (sortSplits.Length == 2)
                {
                    orderByAsc = sortSplits[1].ToLower() switch
                    {
                        "asc" => true,
                        "desc" => false,
                        _ => throw new ArgumentException($"Invalid sort 'sort'")
                    };
                }

                sortedPager.OrderBy.Add(new Linq.OrderBy
                {
                    Field = sortSplits[0],
                    Type = orderByAsc ? 0 : 1
                });
            }

            return sortedPager;
        }
    }
}
