using System.Collections.Generic;

namespace Fengchao.Gallery.Logging
{
    /// <summary>
    /// public class GalleryLogger : ILogger    
    /// </summary>
    public class LoggingOption
    {
        /// <summary>
        /// 是否启用graylog推送日�?
        /// </summary>
        public bool EnableGraylogPush { get; set; }

        /// <summary>
        /// debug模式输出变量
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// graylog地址 [建议不要配置，自动load环境变量，配置在.env中]
        /// </summary>
        public string? GraylogEndPointAddress { get; set; }

        /// <summary>
        /// custom enriches 
        /// </summary>
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
