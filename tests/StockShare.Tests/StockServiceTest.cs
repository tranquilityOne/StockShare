using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockShare.Services;
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
        public void TestTuSharePost_Daily()
        {
            var response = _tuShareWebService.PostAsync(
               new TuShareDailyRequest()
               {
                   Start_Date = "20220708",
                   End_Date = "20220708",
                   TS_Code = "603626.SH"
               }, "daily", string.Empty).Result;
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
            _dailyQuotesService.SyncDailyQuotes().Wait();
            Assert.IsTrue(true);
        }
    }
}
