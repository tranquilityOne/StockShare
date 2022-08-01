using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Pages the elements in a sequence based on a pager.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after paging.</returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var pager = new Pager
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return source.Page(pager);
        }

        /// <summary>
        /// Pages the elements in a sequence based on a pager.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="pager">A <see cref="Pager"/> instance.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after paging.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="pager"/> is null.</exception>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, Pager? pager)
        {
            if (pager == null)
            {
                throw new ArgumentNullException(nameof(pager));
            }

            return source
                .Skip((pager.PageIndex - 1) * pager.PageSize)
                .Take(pager.PageSize);
        }

        /// <summary>
        /// Sorts sources data and returns the specified page data.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="sortedPager">An <see cref="SortedPager"/> instance.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after sorting and paging.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sortedPager"/> is null.</exception>
        public static IEnumerable<T> SortAndPage<T>(this IEnumerable<T> source, SortedPager? sortedPager)
        {
            if (sortedPager == null)
            {
                throw new ArgumentNullException(nameof(sortedPager));
            }

            return source
                .OrderByIf(sortedPager.OrderBy != null && sortedPager.OrderBy.Count > 0, sortedPager.OrderBy)
                .Page(sortedPager);
        }

        /// <summary>
        /// Sorts sources data and returns the specified page data.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="sortedPager">An <see cref="SortedPager"/> instance.</param>
        /// <param name="defaultSorts">The default sort order list.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after sorting and paging.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sortedPager"/> is null.</exception>
        public static IEnumerable<T> SortAndPage<T>(
            this IEnumerable<T> source, SortedPager? sortedPager, IEnumerable<OrderBy>? defaultSorts)
        {
            if (sortedPager == null)
            {
                throw new ArgumentNullException(nameof(sortedPager));
            }

            return source
                .OrderBy(sortedPager.OrderBy?.Count() > 0 ? sortedPager.OrderBy : defaultSorts)
                .Page(sortedPager);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate if the judgement is matched.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
        /// <param name="judgement">The judgement to decide whether the filter should take affect.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition
        /// specified by predicate.
        /// </returns>
        public static IEnumerable<TSource> WhereIf<TSource>(
            this IEnumerable<TSource> source,
            bool judgement,
            Func<TSource, bool> predicate)
        {
            if (!judgement)
            {
                return source;
            }

            return source.Where(predicate);
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IEnumerable{T}"/> sequence by the given order list.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to sort.</param>
        /// <param name="sorts">The sort order list.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after sorting.</returns>
        /// <exception cref="ArgumentException">Thrown if sorts is null or not contains any element.</exception>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, IEnumerable<OrderBy>? sorts)
        {
            if (sorts == null || sorts.Count() == 0)
            {
                throw new ArgumentException(nameof(sorts));
            }

            var firstSort = sorts.First();
            var firstSortKeySelector = BuildSortKeySelector<T>(firstSort);
            var sortedSource = firstSort.InAsc
                ? source.OrderBy(firstSortKeySelector)
                : source.OrderByDescending(firstSortKeySelector);

            for (var i = 1; i < sorts.Count(); i++)
            {
                var sort = sorts.ElementAt(i);
                var sortKeySelector = BuildSortKeySelector<T>(sort);

                sortedSource = sort.InAsc
                    ? sortedSource.ThenBy(sortKeySelector)
                    : sortedSource.ThenByDescending(sortKeySelector);
            }

            return sortedSource;
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IEnumerable{T}"/> sequence by the given order list.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to sort.</param>
        /// <param name="sorts">The sort order list.</param>
        /// <param name="defaultSorts">The default sort order list.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after sorting.</returns>
        /// <exception cref="ArgumentException">Thrown if sorts is null or not contains any element.</exception>
        public static IEnumerable<T> OrderBy<T>(
            this IEnumerable<T> source, IEnumerable<OrderBy>? sorts, IEnumerable<OrderBy>? defaultSorts)
        {
            if (defaultSorts == null || defaultSorts.Count() == 0)
            {
                throw new ArgumentException(nameof(defaultSorts));
            }

            return source.OrderBy(sorts?.Count() > 0 ? sorts : defaultSorts);
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IEnumerable{T}"/> sequence by the given order list
        /// based on a predicate if the judgement is matched.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to sort.</param>
        /// <param name="sorts">The sort order list.</param>
        /// <param name="judgement">The judgement to decide whether the sort should take affect.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains elements after sorting.</returns>
        public static IEnumerable<T> OrderByIf<T>(
            this IEnumerable<T> source, bool judgement, IEnumerable<OrderBy>? sorts)
        {
            if (!judgement)
            {
                return source;
            }

            return source.OrderBy(sorts);
        }

        /// <summary>
        /// Performs the specified function on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to invoke an asynchronous function.</param>
        /// <param name="func">An asynchronous function to apply to each element.</param>
        /// <returns>A task that represents the result.</returns>
        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> func)
        {
            return Task.WhenAll(
                source.Select(arg => Task.Run(() => func(arg))));
        }

        /// <summary>
        /// Performs the specified function on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to invoke an asynchronous function.</param>
        /// <param name="func">An asynchronous function to apply to each element.</param>
        /// <param name="dop">The degree of parallelism.</param>
        /// <returns>A task that represents the result.</returns>
        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> func, int dop)
        {
            // https://devblogs.microsoft.com/pfxteam/implementing-a-simple-foreachasync-part-2/

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(dop)
                    .Select(partition => Task.Run(async () =>
                    {
                        using (partition)
                        {
                            while (partition.MoveNext())
                            {
                                await func(partition.Current);
                            }
                        }
                    })));
        }

        private static Func<T, object?> BuildSortKeySelector<T>(OrderBy sort)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var rootPropName = sort.Field.Trim('.').Split('.')[0];

            if (!props.Any(p => string.Equals(p.Name, rootPropName, StringComparison.InvariantCulture)))
            {
                throw new ArgumentException($"Invalid sorting key '{sort.Field}'.");
            }

            return BuildSortKeySelector<T>(sort.Field);
        }

        private static Func<T, object?> BuildSortKeySelector<T>(string propertyName)
        {
            return obj =>
            {
                var splits = propertyName.Trim('.').Split('.');
                var type = typeof(T);
                object? o = obj;

                for (int i = 0; i < splits.Length; i++)
                {
                    var prop = type.GetProperty(splits[i]);
                    type = prop.PropertyType;
                    o = prop.GetValue(o);
                }

                return o;
            };
        }
    }
}
