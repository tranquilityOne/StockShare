using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Services.Model
{
    /// <summary>
    /// StockBaseRequest
    /// </summary>
    public class TuShareStockBasicRequest
    {
        /// <summary>
        /// 是否沪深港通标的
        /// </summary>
        [JsonProperty("is_hs")]
        public string Is_hs { get; set; } = string.Empty;

        /// <summary>
        /// 上市状态 L上市 D退市 P暂停上市，默认是L
        /// </summary>
        [JsonProperty("list_status")]
        public string List_status { get; set; } = string.Empty;

        /// <summary>
        /// 交易所 SSE上交所 SZSE深交所 BSE北交所
        /// </summary>
        [JsonProperty("exchange")]
        public string? Exchange { get; set; } = string.Empty;

        /// <summary>
        /// TS股票代码
        /// </summary>
        [JsonProperty("ts_code")]
        public string Ts_Code { get; set; } = string.Empty;

        /// <summary>
        /// 市场类别 （主板/创业板/科创板/CDR/北交所）
        /// </summary>
        [JsonProperty("market")]
        public string? Market { get; set; } = string.Empty;
    }
}
