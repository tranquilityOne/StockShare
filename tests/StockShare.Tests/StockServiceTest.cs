using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockShare.Data;
using StockShare.Data.Entities;
using StockShare.Services;
using StockShare.Services.Collection;
using StockShare.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Tests
{
    /// <summary>
    /// StockServiceTest
    /// </summary>
    [TestClass]
    public class StockServiceTest
    {
        private readonly IStockBasicService _stockBasicService = default!;
        private readonly TuShareApiRequestService _tuShareWebService = default!;
        private readonly IDailyQuotesService _dailyQuotesService;
        private readonly StockShareContext _dbContext;
        private readonly TuShareFinaIndicatorService _taShareFinaIndicatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockServiceTest"/> class.
        /// </summary>
        public StockServiceTest()
        {
            var scopeFactory = TestsBase.ServiceProvider.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            _stockBasicService = scope.ServiceProvider.GetRequiredService<IStockBasicService>();
            _dailyQuotesService = scope.ServiceProvider.GetRequiredService<IDailyQuotesService>();
            _tuShareWebService = scope.ServiceProvider.GetRequiredService<TuShareApiRequestService>();
            _dbContext = scope.ServiceProvider.GetRequiredService<StockShareContext>();
            _taShareFinaIndicatorService = scope.ServiceProvider.GetRequiredService<TuShareFinaIndicatorService>();
        }

        /// <summary>
        /// TestTuSharePost_StockBasic
        /// </summary>
        [TestMethod]
        public void TestTuSharePost_StockBasic()
        {
            var response = _tuShareWebService.PostAsync(
                new TuShareStockBasicRequest()
                {
                }, "stock_basic", string.Empty).Result;
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// TestTuSharePost_Daily
        /// </summary>
        [TestMethod]
        public void TestTuSharePostDaily()
        {
            var response = _tuShareWebService.PostAsync(
               new TuShareDailyQuoteRequest()
               {
                   Start_Date = "20220531",
                   End_Date = "20220601",
                   TS_Code = "600941.SH"
               }, "daily", string.Empty).Result;
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// TestTuSharePostAdjFactor
        /// </summary>
        [TestMethod]
        public void TestTuSharePostAdjFactor()
        {
            var response = _tuShareWebService.PostAsync(
               new TuShareDailyQuoteRequest()
               {
                   Start_Date = "20220531",
                   End_Date = "20220601",
                   TS_Code = "600941.SH"
               }, TushareApiConstant.Adj_Factor_Api, string.Empty).Result;
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// TestTuSharePostDailyBasic
        /// </summary>
        [TestMethod]
        public void TestTuSharePostDailyBasic()
        {
            var response = _tuShareWebService.PostAsync(
               new TuShareDailyQuoteRequest()
               {
                   Start_Date = "20220531",
                   End_Date = "20220601",
                   TS_Code = "600941.SH"
               }, TushareApiConstant.Daily_Basic_Api, string.Empty).Result;
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// TestSyncStockBasicInfo
        /// </summary>
        [TestMethod]
        public void TestSyncStockBasicInfo()
        {
            _stockBasicService.AutoSyncStockBasicInfo().Wait();
            Assert.IsTrue(true);
        }

        /// <summary>
        /// TestSyncDailyQuotes
        /// </summary>
        [TestMethod]
        public void TestSyncDailyQuotes()
        {
            var listCodes = new List<string>();
            string startDate = "20230208", endDate = "20230209";
            _dailyQuotesService.SyncDailyQuotesAsync(listCodes, startDate, endDate).Wait();
            Assert.IsTrue(true);
        }

        /// <summary>
        /// TestSyncFiananceIndicator
        /// </summary>
        [TestMethod]
        public void TestSyncFiananceIndicator()
        {
            var listCodes = _dbContext.Stocks.Select(p => p.TS_Code).ToList();
            _taShareFinaIndicatorService.SyncFinIndicatorAsync(listCodes, "20220101", "20230401", string.Empty).Wait();
            Assert.IsTrue(true);
        }
    }
}
