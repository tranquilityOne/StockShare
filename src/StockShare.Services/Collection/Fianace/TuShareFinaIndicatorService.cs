using EFCore.BulkExtensions;
using Microsoft.Extensions.Logging;
using StockShare.Data;
using StockShare.Data.Entities;
using StockShare.Data.Entities.Enum;
using StockShare.Services.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockShare.Services.Collection
{
    /// <summary>
    /// TuShareFinaIndicatorService
    /// </summary>
    public class TuShareFinaIndicatorService
    {
        private readonly ILogger<TuShareDailyQuotesService> _logger;
        private readonly TuShareApiRequestService _tuShareApiRequest;
        private readonly StockShareContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TuShareFinaIndicatorService"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="apiRequestService"></param>
        /// <param name="stockShare"></param>
        public TuShareFinaIndicatorService(ILogger<TuShareDailyQuotesService> logger,
            TuShareApiRequestService apiRequestService,
            StockShareContext stockShare)
        {
            _logger = logger;
            _tuShareApiRequest = apiRequestService;
            _dbContext = stockShare;
        }

        /// <summary>
        /// SyncFinaIndicator
        /// </summary>
        /// <param name="ts_Codes"></param>
        /// <param name="startDate">报告期开始日期</param>
        /// <param name="endDate">报告期结束日期</param>
        /// <param name="period">报告期(每个季度最后一天的日期,比如20171231表示年报)</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task SyncFinIndicatorAsync(IEnumerable<string> ts_Codes, string startDate, string endDate, string period)
        {
            int errorNum = 0, index = 0;
            foreach (var ts_code in ts_Codes)
            {
                var request = new TuShareFinaIndicatorRequest()
                {
                    Start_date = startDate,
                    TS_Code = ts_code,
                    End_date = endDate,
                    Period = period
                };

                try
                {
                    TuShareResponseModel? response = new TuShareResponseModel();
                    response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Fina_indicator_Api, TushareApiConstant.Fina_indicator_Api_Fields);

                    while (response == null || response.Code != "0")
                    {
                        Thread.Sleep(1000 * 10);
                        response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Fina_indicator_Api, TushareApiConstant.Fina_indicator_Api_Fields);
                    }

                    //if (response == null || response.Code != "0")
                    //{
                    //    Thread.Sleep(1000 * 60);
                    //    response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Fina_indicator_Api, TushareApiConstant.Fina_indicator_Api_Fields);
                    //}

                    var finIndicatorList = new List<FinanceIndicatorEntity>();
                    foreach (var item in response!.Data.Items)
                    {
                        var entity = new FinanceIndicatorEntity()
                        {
                            Ts_Code = ts_code,
                            Ann_date = item[1] ?? string.Empty,
                            End_date = item[2] ?? string.Empty,
                            Extra_item = decimal.Parse(item[3] ?? "0"),
                            Profit_dedt = decimal.Parse(item[4] ?? "0"),
                            Gross_margin = decimal.Parse(item[5] ?? "0"),
                            Op_income = decimal.Parse(item[6] ?? "0"),
                            Valuechange_income = decimal.Parse(item[7] ?? "0"),
                            Interst_income = decimal.Parse(item[8] ?? "0"),
                            Daa = decimal.Parse(item[9] ?? "0"),
                            Ebit = decimal.Parse(item[10] ?? "0"),
                            EbitDa = decimal.Parse(item[11] ?? "0"),
                            Fcff = decimal.Parse(item[12] ?? "0"),
                            Current_exint = decimal.Parse(item[13] ?? "0"),
                            Noncurrent_exint = decimal.Parse(item[14] ?? "0"),
                            Interestdebt = decimal.Parse(item[15] ?? "0"),
                            Netdebt = decimal.Parse(item[16] ?? "0"),
                            Tangible_asset = decimal.Parse(item[17] ?? "0"),
                            Invest_capital = decimal.Parse(item[18] ?? "0"),
                            Retained_earnings = decimal.Parse(item[19] ?? "0"),
                            Bps = decimal.Parse(item[20] ?? "0"),
                            Netprofit_margin = decimal.Parse(item[21] ?? "0"),
                            Grossprofit_margin = decimal.Parse(item[22] ?? "0"),
                            Cogs_of_sales = decimal.Parse(item[23] ?? "0"),
                            Expense_of_sales = decimal.Parse(item[24] ?? "0"),
                            Roe = decimal.Parse(item[25] ?? "0"),
                            Roe_waa = decimal.Parse(item[26] ?? "0"),
                            Roe_dt = decimal.Parse(item[27] ?? "0"),
                            Roe_yearly = decimal.Parse(item[28] ?? "0"),
                            Debt_to_assets = decimal.Parse(item[29] ?? "0"),
                            Rd_exp = decimal.Parse(item[30] ?? "0")
                        };
                        DateTime.TryParseExact(entity.End_date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDateTime);
                        switch (endDateTime.Month)
                        {
                            case 3:
                                entity.End_type = (int)ReportEndType.First;
                                break;
                            case 6:
                                entity.End_type = (int)ReportEndType.Second;
                                break;
                            case 9:
                                entity.End_type = (int)ReportEndType.Third;
                                break;
                            case 12:
                                entity.End_type = (int)ReportEndType.Fourth;
                                break;
                        }

                        finIndicatorList.Add(entity);
                    }

                    await _dbContext.BulkInsertOrUpdateAsync(finIndicatorList);
                    index++;
                }
                catch (Exception ex)
                {
                    errorNum++;
                    _logger.LogError($"Read finance indicator error,TS_Code = {ts_code}", ex);
                    if (errorNum > 5)
                    {
                        return;
                    }
                }
            }

            await _dbContext.StatsRecords.AddAsync(new StatsRecordEntity()
            {
                StartTradeDate = Convert.ToInt16(startDate),
                EndTradeDate = Convert.ToInt16(endDate),
                StatsRecordType = Data.Entities.Enum.StatsRecordType.FinanceIndicator,
                CreatedOn = DateTime.Now
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
