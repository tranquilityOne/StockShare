using Fengchao.Gallery.Core.Linq;
using Fengchao.Gallery.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockShare.Areas.Basic.Controllers
{
    /// <summary>
    /// A base class for api controller.
    /// </summary>
    public partial class BasicController
    {
        /// <summary>
        /// Creates a <see cref="StatusResponseResult"/> instance with default response code, which indicates
        /// current request bas been processed successfully.
        /// </summary>
        /// <returns>A <see cref="StatusResponseResult"/> instance with default response code.</returns>
        internal StatusResponseResult Succeed()
        {
            return new StatusResponseResult();
        }

        /// <summary>
        /// Creates a <see cref="ResponseResult{TData}"/> instance with default response code and given response data.
        /// </summary>
        /// <param name="data">Response data.</param>
        /// <returns>A <see cref="ResponseResult{TData}"/> instance with default response code.</returns>
        internal ResponseResult<TData> Succeed<TData>(TData data)
            where TData : class
        {
            return new ResponseResult<TData>(data);
        }

        /// <summary>
        /// Creates a <see cref="PagerResponseResult{TItem}"/> instance with default response code and a
        /// paged response item collection.
        /// </summary>
        /// <param name="response">A <see cref="PagerResponse{TItem}"/> instance.</param>
        /// <returns>A <see cref="PagerResponseResult{TItem}"/> instance with default response code.</returns>
        internal PagerResponseResult<TItem> Succeed<TItem>(PagerResponse<TItem> response)
        {
            return new PagerResponseResult<TItem>(response);
        }

        /// <summary>
        /// Creates a <see cref="PagerResponseResult{TItem}"/> instance with default response code and all
        /// items found.
        /// </summary>
        /// <param name="items">A collection of items to response.</param>
        /// <returns>A <see cref="PagerResponseResult{TItem}"/> instance with default response code.</returns>
        internal PagerResponseResult<TItem> Succeed<TItem>(IEnumerable<TItem> items)
        {
            return new PagerResponseResult<TItem>(new PagerResponse<TItem>
            {
                Items = items,
                PageIndex = 1,
                PageSize = int.MaxValue,
                TotalCount = items.Count()
            });
        }

        /// <summary>
        /// Creates a <see cref="PagerResponseResult{TItem}"/> instance with default response code and a
        /// paged response item collection.
        /// </summary>
        /// <param name="response">A <see cref="PagerResponse{TItem}"/> instance.</param>
        /// <param name="converter">The converter to convert source items to a specify type.</param>
        /// <returns>A <see cref="PagerResponseResult{TItem}"/> instance with default response code.</returns>
        internal PagerResponseResult<TItem> Succeed<TSource, TItem>(
            PagerResponse<TSource> response, Func<IEnumerable<TSource>, IEnumerable<TItem>> converter)
        {
            return new PagerResponseResult<TItem>(new PagerResponse<TItem>
            {
                Items = converter(response.Items),
                PageIndex = response.PageIndex,
                PageSize = response.PageSize,
                TotalCount = response.TotalCount
            });
        }

        /// <summary>
        /// Creates a <see cref="SummarizedPagerResponseResult{TItem, TSummary}"/> instance with default response code,
        /// a paged response item collection and it's summary data.
        /// </summary>
        /// <param name="response">A <see cref="SummarizedPagerResponse{TItem, TSummary}"/> instance.</param>
        /// <returns>
        /// A <see cref="SummarizedPagerResponseResult{TItem, TSummary}"/> instance with default response code.
        /// </returns>
        internal SummarizedPagerResponseResult<TItem, TSummary> Succeed<TItem, TSummary>(
            SummarizedPagerResponse<TItem, TSummary> response)
            where TSummary : class
        {
            return new SummarizedPagerResponseResult<TItem, TSummary>(response);
        }
    }
}
