using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 每日基础指标
    /// </summary>
    public class DailyBasicEntity : EntityBase
    {
        /// <summary>
        /// 交易日期
        /// </summary>
        [StringLength(30)]
        public string Trade_Date { get; set; } = default!;

        /// <summary>
        /// 交易代码
        /// </summary>
        [StringLength(30)]
        public string TS_Code { get; set; } = default!;

        /// <summary>
        /// 复权因子
        /// </summary>
        public decimal Adj_Factor { get; set; }

        /// <summary>
        /// 开盘价(不复权)
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// 开盘价(后复权)
        /// </summary>
        public decimal Open_HFQ { get; set; }

        /// <summary>
        /// 开盘价(前复权)
        /// </summary>
        public decimal Open_QFQ { get; set; }

        /// <summary>
        /// 最高价(不复权)
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// 最高价(后复权)
        /// </summary>
        public decimal High_HFQ { get; set; }

        /// <summary>
        /// 最高价(前复权)
        /// </summary>
        public decimal High_QFQ { get; set; }

        /// <summary>
        /// 最低价(不复权)
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// 最低价(前复权)
        /// </summary>
        public decimal Low_QFQ { get; set; }

        /// <summary>
        /// 最低价(后复权)
        /// </summary>
        public decimal Low_HFQ { get; set; }

        /// <summary>
        /// 当日收盘价(不复权)
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// 当日收盘价(前复权)
        /// </summary>
        public decimal Close_QFQ { get; set; }

        /// <summary>
        /// 当日收盘价(后复权)
        /// </summary>
        public decimal Close_HFQ { get; set; }

        /// <summary>
        /// 涨停价
        /// </summary>
        public decimal Up_Limit { get; set; }

        /// <summary>
        /// 跌停价
        /// </summary>
        public decimal Down_Limit { get; set; }

        /// <summary>
        /// 成交量(手)
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 成交额(千元)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 涨跌额
        /// </summary>
        public decimal Change { get; set; }

        /// <summary>
        /// 涨跌幅
        /// </summary>
        public decimal Pct_Change { get; set; }

        /// <summary>
        /// 当日换手率
        /// </summary>
        public decimal TurnOver_Rate { get; set; }

        /// <summary>
        /// 当日换手率(自由流通股)
        /// </summary>
        public decimal TurnOver_Rate_Float { get; set; }

        /// <summary>
        /// 量比(当天即时(某分钟)成交量/前五天每分钟平均成交量)
        /// </summary>
        public decimal Volume_Ratio { get; set; }

        /// <summary>
        /// 市盈率（总市值/净利润， 亏损的PE为空）
        /// </summary>
        public decimal PE { get; set; }

        /// <summary>
        /// 市盈率（TTM，亏损的PE为空）
        /// </summary>
        public decimal PE_TTM { get; set; }

        /// <summary>
        /// 市净率（总市值/净资产）
        /// </summary>
        public decimal PB { get; set; }

        /// <summary>
        /// 市销率(总市值／营收)
        /// </summary>
        public decimal PS { get; set; }

        /// <summary>
        /// 市销率(TTM)
        /// </summary>
        public decimal PS_TTM { get; set; }

        /// <summary>
        /// 股息率
        /// </summary>
        public decimal DV_Ratio { get; set; }

        /// <summary>
        /// 股息率(TTM)
        /// </summary>
        public decimal DV_Ratio_TTM { get; set; }

        /// <summary>
        /// 总股本(万股)
        /// </summary>
        public decimal Total_Share { get; set; }

        /// <summary>
        /// 流通股本(万股)
        /// </summary>
        public decimal Float_Share { get; set; }

        /// <summary>
        /// 自由流通股本(万股)
        /// </summary>
        public decimal Free_Share { get; set; }

        /// <summary>
        /// 总市值(万元)
        /// </summary>
        public decimal Total_MV { get; set; }

        /// <summary>
        /// 流通市值(万元)
        /// </summary>
        public decimal Circ_MV { get; set; }
    }
}
