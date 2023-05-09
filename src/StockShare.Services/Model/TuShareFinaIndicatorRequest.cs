using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Services.Model
{
    /// <summary>
    /// TuShareFinaIndicatorRequest
    /// </summary>
    public class TuShareFinaIndicatorRequest
    {
        /// <summary>
        /// TS股票代码
        /// </summary>
        [JsonProperty("ts_code")]
        public string TS_Code { get; set; } = string.Empty;

        /// <summary>
        /// 公告日期
        /// </summary>
        [JsonProperty("ann_date")]
        public string Ann_date { get; set; } = string.Empty;

        /// <summary>
        /// 报告期开始日期
        /// </summary>
        [JsonProperty("start_date")]
        public string Start_date { get; set; } = string.Empty;

        /// <summary>
        /// 报告期结束日期
        /// </summary>
        [JsonProperty("end_date")]
        public string End_date { get; set; } = string.Empty;

        /// <summary>
        /// 报告期(每个季度最后一天的日期,比如20171231表示年报)
        /// </summary>
        [JsonProperty("period")]
        public string Period { get; set; } = string.Empty;
    }
}
