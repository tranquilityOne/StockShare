using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Core.Configuration
{
    /// <summary>
    /// TuShareOptions
    /// </summary>
    public class TuShareOptions
    {
        /// <summary>
        /// ApiKey
        /// </summary>
        public string ApiKey { get; set; } = default!;

        /// <summary>
        /// BaseApi
        /// </summary>
        public string BaseApi { get; set; } = default!;
    }
}
