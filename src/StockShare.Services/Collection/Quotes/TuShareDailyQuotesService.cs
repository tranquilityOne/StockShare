using AutoMapper;
using Dapper;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockShare.Core.Models;
using StockShare.Data;
using StockShare.Data.Entities;
using StockShare.Data.Entities.Enum;
using StockShare.Services.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Services
{
    /// <summary>
    /// Daily of TuShare resource
    /// </summary>
    public class TuShareDailyQuotesService : IDailyQuotesService
    {
        private readonly ILogger<TuShareDailyQuotesService> _logger;
        private readonly TuShareApiRequestService _tuShareApiRequest;
        private readonly StockShareContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TuShareDailyQuotesService"/> class.
        /// </summary>
        public TuShareDailyQuotesService(ILogger<TuShareDailyQuotesService> logger,
            TuShareApiRequestService tuShareApiRequest,
            StockShareContext dbContext,
            IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _tuShareApiRequest = tuShareApiRequest;
            _mapper = mapper;
        }

        /// <summary>
        /// GetDailyQuotes
        /// </summary>
        /// <param name="ts_Codes"></param>
        /// <param name="startDate">yyyyMMdd</param>
        /// <param name="endDate">yyyyMMdd</param>
        public async Task SyncDailyQuotes(IEnumerable<string> ts_Codes, string startDate, string endDate)
        {
            // api 限制返回5000笔交易记录
            //DateTime startTradeDate = DateTime.Now.AddYears(-10), endTradeDate = DateTime.Now;
            //var statsRecord = await _dbContext.StatsRecords.AsNoTracking().Where(p => p.StatsRecordType == StatsRecordType.DailyQuote).OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            //if (statsRecord != null)
            //{
            //    startTradeDate = DateTime.ParseExact(statsRecord.StartTradeDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            //    endTradeDate = DateTime.ParseExact(statsRecord.EndTradeDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            //}

            int postErrorNum = 0;
            var stockList = await _dbContext.Stocks.AsNoTracking().ToListAsync();
            if (ts_Codes.Any())
            {
                stockList = stockList.Where(s => ts_Codes.Any(p => p == s.TS_Code)).ToList();
            }

            foreach (var stock in stockList)
            {
                try
                {
                    var dailyQuoteList = new List<DailyBasicEntity>();
                    var requestParam = new TuShareDailyQuoteRequest()
                    {
                        TS_Code = stock.TS_Code,
                        Start_Date = startDate,
                        End_Date = endDate
                    };

                    await ParseDailyQuote(stock.TS_Code, dailyQuoteList, requestParam);

                    await ParseDailyAdjFactor(stock.TS_Code, dailyQuoteList, requestParam);

                    await ParseStockLimit(stock.TS_Code, dailyQuoteList, requestParam);

                    await ParseDailyBasic(stock.TS_Code, dailyQuoteList, requestParam);

                    await SaveDailyDataAsync(dailyQuoteList, stock.Market);
                }
                catch (Exception ex)
                {
                    _logger.LogError("GetDailyQuotes error >> TsCode is {TS_Code},err : {@ex}", stock.TS_Code, ex);
                    postErrorNum++;
                    if (postErrorNum > 10)
                    {
                        return;
                    }
                }
            }

            await _dbContext.StatsRecords.AddAsync(new StatsRecordEntity()
            {
                StartTradeDate = int.Parse(startDate),
                EndTradeDate = int.Parse(endDate),
                StatsRecordType = StatsRecordType.DailyQuote
            });

            // 日线行情
            async Task ParseDailyQuote(string ts_Code, List<DailyBasicEntity> dailyQuoteList, TuShareDailyQuoteRequest request)
            {
                var response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Daily_Api, TushareApiConstant.Daily_Api_Fields);

                if (response == null || response.Code != "0")
                {
                    return;
                }

                foreach (var item in response.Data.Items)
                {
                    dailyQuoteList.Add(new DailyBasicEntity()
                    {
                        TS_Code = item[0] ?? string.Empty,
                        Trade_Date = item[1] ?? string.Empty,
                        Open = decimal.Parse(item[2] ?? "0"),
                        High = decimal.Parse(item[3] ?? "0"),
                        Low = decimal.Parse(item[4] ?? "0"),
                        Close = decimal.Parse(item[5] ?? "0"),
                        Change = decimal.Parse(item[7] ?? "0"),
                        Pct_Change = decimal.Parse(item[8] ?? "0"),
                        Volume = decimal.Parse(item[9] ?? "0"),
                        Amount = decimal.Parse(item[10] ?? "0")
                    });
                }
            }

            // 每日复权因子
            async Task ParseDailyAdjFactor(string ts_Code, List<DailyBasicEntity> dailyQuoteList, TuShareDailyQuoteRequest request)
            {
                var response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Adj_Factor_Api, TushareApiConstant.Adj_Factor_Api_Fields);

                if (response == null || response.Code != "0")
                {
                    return;
                }

                foreach (var item in response.Data.Items)
                {
                    var currentItem = dailyQuoteList.FirstOrDefault(p => p.TS_Code == (item[0] ?? string.Empty) && p.Trade_Date == (item[1] ?? string.Empty));
                    if (currentItem != null)
                    {
                        currentItem.Adj_Factor = item[2] == null ? 0m : decimal.Parse(item[2]);
                    }
                }
            }

            // 每日涨/跌停价
            async Task ParseStockLimit(string ts_Code, List<DailyBasicEntity> dailyQuoteList, TuShareDailyQuoteRequest request)
            {
                var response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Stk_limit_Api, TushareApiConstant.Stk_limit_Api_Fields);
                if (response == null || response.Code != "0")
                {
                    return;
                }

                foreach (var item in response.Data.Items)
                {
                    var currentItem = dailyQuoteList.FirstOrDefault(p => p.TS_Code == (item[0] ?? string.Empty) && p.Trade_Date == (item[1] ?? string.Empty));
                    if (currentItem != null)
                    {
                        currentItem.Up_Limit = item[3] == null ? 0m : decimal.Parse(item[3]);
                        currentItem.Down_Limit = item[4] == null ? 0m : decimal.Parse(item[4]);
                    }
                }
            }

            // 每日基本指标
            async Task ParseDailyBasic(string ts_Code, List<DailyBasicEntity> dailyQuoteList, TuShareDailyQuoteRequest request)
            {
                var response = await _tuShareApiRequest.PostAsync(request, TushareApiConstant.Daily_Basic_Api, TushareApiConstant.Daily_Basic_Api_Fields);

                if (response == null || response.Code != "0")
                {
                    return;
                }

                foreach (var item in response.Data.Items)
                {
                    var currentItem = dailyQuoteList.FirstOrDefault(p => p.TS_Code == (item[0] ?? string.Empty) && p.Trade_Date == (item[1] ?? string.Empty));
                    if (currentItem != null)
                    {
                        currentItem.TurnOver_Rate = item[2] == null ? 0m : decimal.Parse(item[2]);
                        currentItem.TurnOver_Rate_Float = item[3] == null ? 0m : decimal.Parse(item[3]);
                        currentItem.Volume_Ratio = item[4] == null ? 0m : decimal.Parse(item[4]);
                        currentItem.PE = item[5] == null ? 0m : decimal.Parse(item[5]);
                        currentItem.PE_TTM = item[6] == null ? 0m : decimal.Parse(item[6]);
                        currentItem.PB = item[7] == null ? 0m : decimal.Parse(item[7]);
                        currentItem.PS = item[8] == null ? 0m : decimal.Parse(item[8]);
                        currentItem.PS_TTM = item[9] == null ? 0m : decimal.Parse(item[9]);
                        currentItem.DV_Ratio = item[10] == null ? 0m : decimal.Parse(item[10]);
                        currentItem.DV_Ratio_TTM = item[11] == null ? 0m : decimal.Parse(item[11]);
                        currentItem.Total_Share = item[12] == null ? 0m : decimal.Parse(item[12]);
                        currentItem.Float_Share = item[13] == null ? 0m : decimal.Parse(item[13]);
                        currentItem.Free_Share = item[14] == null ? 0m : decimal.Parse(item[14]);
                        currentItem.Total_MV = item[15] == null ? 0m : decimal.Parse(item[15]);
                        currentItem.Circ_MV = item[16] == null ? 0m : decimal.Parse(item[16]);
                    }
                }
            }

            async Task SaveDailyDataAsync(List<DailyBasicEntity> dailyQuoteList, string? stockMarket)
            {
                if (!dailyQuoteList.Any())
                {
                    return;
                }

                var tableName = string.Empty;
                switch (stockMarket)
                {
                    case "主板":
                        tableName = "daily_zb";
                        break;
                    case "创业板":
                        tableName = "daily_cyb";
                        break;
                    case "科创板":
                        tableName = "daily_kcb";
                        break;
                    case "中小板":
                        tableName = "daily_zxb";
                        break;
                    case "北交所":
                        tableName = "daily_bjs";
                        break;
                    default:
                        throw new ArgumentNullException($"stockMarket {stockMarket} not exists.");
                  }

                int insertPageSize = 100, index = 0;
                var total = dailyQuoteList.Count();
                while (insertPageSize * index < total)
                {
                    var insertConcatSql = string.Empty;
                    var currentItems = dailyQuoteList.Skip(insertPageSize * index).Take(insertPageSize);

                    foreach (var item in currentItems)
                    {
                        insertConcatSql += $@"
(CURRENT_TIMESTAMP, CURRENT_TIMESTAMP,'','{item.Trade_Date}','{item.TS_Code}',{item.Adj_Factor},
{item.Open},{item.Open_HFQ},{item.Open_QFQ},{item.High},{item.High_HFQ},{item.High_QFQ},{item.Low},{item.Low_QFQ},{item.Low_HFQ},{item.Close},{item.Close_QFQ},{item.Close_HFQ},
{item.Up_Limit},{item.Down_Limit},{item.Volume},{item.Amount},{item.Change},{item.Pct_Change},{item.TurnOver_Rate},{item.TurnOver_Rate_Float},{item.Volume_Ratio},
{item.PE},{item.PE_TTM},{item.PB},{item.PS},{item.PS_TTM},{item.DV_Ratio},{item.DV_Ratio_TTM},{item.Total_Share},{item.Float_Share},
{item.Free_Share},{item.Total_MV},{item.Circ_MV}),";
                    }

                    var sql = @$"INSERT INTO stockshare.{tableName} (CreatedOn, LatestUpdatedOn, Comment, Trade_Date, TS_Code, Adj_Factor, 
`Open`, Open_HFQ, Open_QFQ, High, High_HFQ, High_QFQ, Low, Low_QFQ, Low_HFQ, `Close`, Close_QFQ, Close_HFQ, 
Up_Limit, Down_Limit, Volume, Amount, `Change`, Pct_Change, TurnOver_Rate, TurnOver_Rate_Float, Volume_Ratio, 
PE, PE_TTM, PB, PS, PS_TTM, DV_Ratio, DV_Ratio_TTM, Total_Share, Float_Share, Free_Share, Total_MV, Circ_MV)
values {insertConcatSql.TrimEnd(',')} as new
on duplicate key update
Adj_Factor = new.Adj_Factor,`Open` = new.`Open`,Open_HFQ = new.Open_HFQ,Open_QFQ = new.Open_HFQ,High = new.High,High_HFQ = new.High_HFQ,
High_QFQ = new.High_QFQ,Low = new.Low,Low_QFQ = new.Low_QFQ,Low_HFQ = new.Low_HFQ,`Close` = new.`Close`,Close_QFQ = new.Close_QFQ,
Close_HFQ = new.Close_HFQ,Up_Limit = new.Up_Limit,Down_Limit = new.Down_Limit,Volume = new.Volume,Amount = new.Amount,`Change` = new.`Change`,
Pct_Change = new.Pct_Change,TurnOver_Rate = new.TurnOver_Rate,Volume_Ratio = new.Volume_Ratio,PE = new.PE,PE_TTM = new.PE_TTM,PB = new.PB,
PS = new.PS,PS_TTM = new.PS_TTM,DV_Ratio = new.DV_Ratio,DV_Ratio_TTM = new.DV_Ratio_TTM,Total_Share = new.Total_Share,Float_Share = new.Float_Share,
Free_Share = new.Free_Share,Total_MV = new.Total_MV,Circ_MV = new.Circ_MV;";

                    await _dbContext.Database.GetDbConnection().ExecuteAsync(sql);
                    index++;
                }
            }
        }
    }
}
