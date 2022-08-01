namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Provides some most used sort order list.
    /// </summary>
    public static class DefaultSorts
    {
        /// <summary>
        /// Sorts items by its "Id" in ascending.
        /// </summary>
        public static OrderBy[] ById => new[]
        {
            new OrderBy { Field = "Id", Type = 0 }
        };


        /// <summary>
        /// Sorts items by its "Id" in descending.
        /// </summary>
        public static OrderBy[] ByIdDesc => new[]
        {
            new OrderBy { Field = "Id", Type = 1 }
        };
    }
}
