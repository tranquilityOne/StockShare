using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Core.Models
{
    /// <summary>
    /// tushare request base model
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class TuShareRequestBaseModel<T>
    {
        /// <summary>
        /// api_name
        /// </summary>
        [JsonProperty("api_name")]
        public string ApiName { get; set; } = default!;

        /// <summary>
        /// token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; } = default!;

        /// <summary>
        /// api_params
        /// </summary>
        [JsonProperty("params")]
        public T ApiParams { get; set; } = default!;

        /// <summary>
        /// field
        /// </summary>
        [JsonProperty("fields")]
        public string? Fields { get; set; }
    }
}
