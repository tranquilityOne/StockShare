using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Provides extension methods for <see cref="IQueryable{T}"/>.
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Pages the elements in a sequence based on index and size.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IQueryable{T}"/> to filter.</param>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after paging.</returns>
        public static IQueryable<T> Page<T>(this IQueryable<T> source, int pageIndex, int pageSize)
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
        /// <param name="source">An <see cref="IQueryable{T}"/> to filter.</param>
        /// <param name="pager">A <see cref="Pager"/> instance.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after paging.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="pager"/> is null.</exception>
        public static IQueryable<T> Page<T>(this IQueryable<T> source, Pager? pager)
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
        /// <param name="source">An <see cref="IQueryable{T}"/> to filter.</param>
        /// <param name="sortedPager">An <see cref="SortedPager"/> instance.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting and paging.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sortedPager"/> is null.</exception>
        public static IQueryable<T> SortAndPage<T>(this IQueryable<T> source, SortedPager? sortedPager)
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
        /// <param name="source">An <see cref="IQueryable{T}"/> to filter.</param>
        /// <param name="sortedPager">An <see cref="SortedPager"/> instance.</param>
        /// <param name="defaultSorts">The default sort order list.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting and paging.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sortedPager"/> is null.</exception>
        public static IQueryable<T> SortAndPage<T>(
            this IQueryable<T> source, SortedPager? sortedPager, IEnumerable<OrderBy>? defaultSorts)
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
        /// <param name="source">An <see cref="IQueryable{T}"/> to filter.</param>
        /// <param name="judgement">The judgement to decide whether the filter should take affect.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An <see cref="IQueryable{T}"/> that contains elements from the input sequence that satisfy the condition
        /// specified by predicate.
        /// </returns>
        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool judgement,
            Expression<Func<TSource, bool>> predicate)
        {
            if (!judgement)
            {
                return source;
            }

            return source.Where(predicate);
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IQueryable{T}"/> sequence by the given order list.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IQueryable{T}"/> to sort.</param>
        /// <param name="sorts">The sort order list.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting.</returns>
        /// <exception cref="ArgumentException">Thrown if sorts is null or not contains any element.</exception>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<OrderBy>? sorts)
        {
            // https://entityframeworkcore.com/knowledge-base/54232892/ef-sorting-by-property-of-property-of-object-with-string

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
        /// Sorts the elements of an <see cref="IQueryable{T}"/> sequence by the given order list.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IQueryable{T}"/> to sort.</param>
        /// <param name="sorts">The sort order list.</param>
        /// <param name="defaultSorts">The default sort order list.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting.</returns>
        /// <exception cref="ArgumentException">Thrown if sorts is null or not contains any element.</exception>
        public static IOrderedQueryable<T> OrderBy<T>(
            this IQueryable<T> source, IEnumerable<OrderBy>? sorts, IEnumerable<OrderBy>? defaultSorts)
        {
            if (defaultSorts == null || defaultSorts.Count() == 0)
            {
                throw new ArgumentException(nameof(defaultSorts));
            }

            return source.OrderBy(sorts?.Count() > 0 ? sorts : defaultSorts);
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IQueryable{T}"/> sequence by the given sort string.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IQueryable{T}"/> to sort.</param>
        /// <param name="sortString">The sort string.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting.</returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string? sortString)
        {
            return source.OrderBy(sortString, null);
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IQueryable{T}"/> sequence by the given sort string.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IQueryable{T}"/> to sort.</param>
        /// <param name="sortString">The sort string.</param>
        /// <param name="defaultSortString">The default sort string.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting.</returns>
        public static IQueryable<T> OrderBy<T>(
            this IQueryable<T> source,
            string? sortString,
            string? defaultSortString)
        {
            var sortPager = SortedPager.FromSortString(
                string.IsNullOrWhiteSpace(sortString) ? defaultSortString : sortString);

            return source.OrderBy(sortPager.OrderBy);
        }

        /// <summary>
        /// Sorts the elements of an <see cref="IQueryable{T}"/> sequence by the given order list
        /// based on a predicate if the judgement is matched.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">An <see cref="IQueryable{T}"/> to sort.</param>
        /// <param name="judgement">The judgement to decide whether the sort should take affect.</param>
        /// <param name="sorts">The sort order list.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements after sorting.</returns>
        public static IQueryable<T> OrderByIf<T>(
            this IQueryable<T> source, bool judgement, IEnumerable<OrderBy>? sorts)
        {
            if (!judgement)
            {
                return source;
            }

            return source.OrderBy(sorts);
        }

        private static Expression<Func<T, object?>> BuildSortKeySelector<T>(OrderBy sort)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var rootPropName = sort.Field.Trim('.').Split('.')[0];

            if (!props.Any(p => string.Equals(p.Name, rootPropName, StringComparison.InvariantCulture)))
            {
                throw new ArgumentException($"Invalid sorting key '{sort.Field}'.");
            }

            return BuildSortKeySelector<T>(sort.Field);
        }

        private static Expression<Func<T, object?>> BuildSortKeySelector<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var member = propertyName.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);
            var obj = Expression.Convert(member, typeof(object));

            return Expression.Lambda<Func<T, object?>>(obj, parameter);
        }
    }
}
