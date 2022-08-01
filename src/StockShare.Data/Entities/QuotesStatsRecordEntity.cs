using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StockShare.Data.Entities.Enum;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 统计记录
    /// </summary>
    [Table("QuotesStatsRecord")]
    public class QuotesStatsRecordEntity : EntityBase
    {
        /// <summary>
        /// 开始交易日期
        /// </summary>
        public int StartTradeDate { get; set; } = default!;

        /// <summary>
        /// 结束交易日期
        /// </summary>
        [StringLength(50)]
        public int EndTradeDate { get; set; } = default!;

        /// <summary>
        /// 统计类型
        /// </summary>
        public QuotesStatsType QuotesStatsType { get; set; }
    }
}
