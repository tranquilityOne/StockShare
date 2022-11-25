using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Services.Model
{
    /// <summary>
    /// 日线行情请求参数
    /// </summary>
    public class TuShareDailyRequest
    {
        /// <summary>
        /// 股票代码
        /// </summary>
        [JsonProperty("ts_code")]
        public string TS_Code { get; set; } = default!;

        /// <summary>
        /// 交易日期
        /// </summary>
        [JsonProperty("trade_date")]
        public string Trade_Date { get; set; } = string.Empty;

        /// <summary>
        /// 开始日期
        /// </summary>
        [JsonProperty("start_date")]
        public string Start_Date { get; set; } = string.Empty;

        /// <summary>
        /// 结束日期
        /// </summary>
        [JsonProperty("end_date")]
        public string End_Date { get; set; } = string.Empty;
    }
}
