namespace Fengchao.Gallery.Core.Linq
{
    /// <summary>
    /// Pager.
    /// </summary>
    public class Pager
    {
        private int pageIndex = 0;
        private int pageSize = 0;

        /// <summary>
        /// Gets or sets page index. Start with 1, default as 1.
        /// </summary>
        public int PageIndex
        {
            get
            {
                return pageIndex > 0
                    ? pageIndex
                    : 1;
            }
            set
            {
                pageIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets page size. Start with 1, default as 10.
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize > 0
                    ? pageSize
                    : 10;
            }
            set
            {
                pageSize = value;
            }
        }
    }
}
