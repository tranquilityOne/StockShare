using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StockShare.Core.Configuration;
using StockShare.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Services
{
    /// <summary>
    /// TuShareWebService
    /// url: https://tushare.pro/document/1?doc_id=130
    /// </summary>
    public class TuShareApiRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<TuShareOptions> _tuShareOptions;
        private readonly ILogger<TuShareApiRequestService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TuShareApiRequestService"/> class.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public TuShareApiRequestService(IHttpClientFactory httpClientFactory,
            IOptions<TuShareOptions> options,
            ILogger<TuShareApiRequestService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _tuShareOptions = options;
            _logger = logger;
        }

        /// <summary>
        /// Post async
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="paramModel"></param>
        /// <param name="apiName"></param>
        /// <param name="fields"></param>
        public async Task<TuShareResponseModel?> PostAsync<T>(T paramModel, string apiName, string fields)
        {
            var requestModel = new TuShareRequestBaseModel<T>()
            {
                ApiName = apiName,
                ApiParams = paramModel,
                Fields = fields,
                Token = _tuShareOptions.Value.ApiKey
            };

            try
            {
                var sendJsonStr = JsonConvert.SerializeObject(requestModel);
                var requestContent = new StringContent(sendJsonStr, Encoding.UTF8, "application/json");
                var httpClient = _httpClientFactory.CreateClient();
                using var response = await httpClient.PostAsync(_tuShareOptions.Value.BaseApi, requestContent);
                response.EnsureSuccessStatusCode();
                var resultStr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TuShareResponseModel>(resultStr);
            }
            catch (Exception ex)
            {
                _logger.LogError("PostAsync error", ex);
            }

            return null;
        }
    }
}
