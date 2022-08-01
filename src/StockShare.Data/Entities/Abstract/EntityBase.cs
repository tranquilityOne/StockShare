using System;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// Entity base.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime LatestUpdatedOn { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Comment { get; set; }
    }
}
