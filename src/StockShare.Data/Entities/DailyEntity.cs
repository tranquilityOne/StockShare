using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockShare.Data.Entities
{
    public class DailyEntity : EntityBase
    {
        /// <summary>
        /// 股票代码
        /// </summary>
        [StringLength(20)]
        public string TS_Code { get; set; } = default!;

        /// <summary>
        /// 交易日期
        /// </summary>
        [StringLength(50)]
        public string Trade_Date { get; set; } = default!;

        /// <summary>
        /// 开盘价
        /// </summary>
        public float Open { get; set; }

        /// <summary>
        /// 最高价
        /// </summary>
        public float High { get; set; }

        /// <summary>
        /// 最低价
        /// </summary>
        public float Low { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public float Close { get; set; }

        /// <summary>
        /// 昨日收盘价
        /// </summary>
        public float Pre_Close { get; set; }

        /// <summary>
        /// 涨跌额
        /// </summary>
        public float Change { get; set; }

        /// <summary>
        /// 涨跌幅
        /// </summary>
        public float Percentage_Change { get; set; }

        /// <summary>
        /// 成交量(手)
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// 成交额(千元)
        /// </summary>
        public float Amount { get; set; }
    }
}
