using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Core.Models
{
    /// <summary>
    /// TuShareResponseModel
    /// </summary>
    public class TuShareResponseModel
    {
        /// <summary>
        /// Code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = default!;

        /// <summary>
        /// Msg
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; } = default!;

        /// <summary>
        /// Data
        /// </summary>
        [JsonProperty("data")]
        public DataModel Data { get; set; } = default!;
    }

    /// <summary>
    /// DataModel
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// fields
        /// </summary>
        [JsonProperty("fields")]
        public string[] Fields { get; set; } = default!;

        /// <summary>
        /// Items
        /// </summary>
        [JsonProperty("items")]
        public string[][] Items { get; set; } = default!;
    }
}
