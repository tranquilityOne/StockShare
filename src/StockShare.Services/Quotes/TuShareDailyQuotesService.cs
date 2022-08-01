using Dapper;
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
        private const string Daily_Api = "daily";

        private readonly ILogger<TuShareDailyQuotesService> _logger;
        private readonly TuShareApiRequestService _tuShareApiRequest;
        private readonly StockShareContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TuShareDailyQuotesService"/> class.
        /// </summary>
        public TuShareDailyQuotesService(ILogger<TuShareDailyQuotesService> logger,
            TuShareApiRequestService tuShareApiRequest,
            StockShareContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _tuShareApiRequest = tuShareApiRequest;
        }

        /// <summary>
        /// GetDailyQuotes
        /// </summary>
        public async Task SyncDailyQuotes()
        {
            var stockItems = await _dbContext.Stocks.Where(p => p.List_Status == "L").Skip(3444).ToListAsync();

            // api 限制返回5000笔交易记录
            DateTime startTradeDate = DateTime.Now.AddYears(-10), endTradeDate = DateTime.Now;
            var statsRecord = await _dbContext.QuotesStatsRecords.AsNoTracking().Where(p => p.QuotesStatsType == QuotesStatsType.Daily).OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (statsRecord != null)
            {
                startTradeDate = DateTime.ParseExact(statsRecord.StartTradeDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                endTradeDate = DateTime.ParseExact(statsRecord.EndTradeDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            }

            int postErrorNum = 0;

            foreach (var item in stockItems)
            {
                try
                {
                    var response = await _tuShareApiRequest.PostAsync(new TuShareDailyRequest()
                    {
                        TS_Code = item.TS_Code,
                        Start_Date = startTradeDate.ToString("yyyyMMdd"),
                        End_Date = endTradeDate.ToString("yyyyMMdd")
                    }, Daily_Api, string.Empty);

                    if (response != null && response.Code == "0")
                    {
                        await SaveDailyDataAsync(response, item);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("GetDailyQuotes error >> TsCode is {TS_Code},err : {@ex}", item.TS_Code, ex);
                    postErrorNum++;
                    if (postErrorNum > 10)
                    {
                        return;
                    }
                }

                _logger.LogInformation($"TSCode {item.TS_Code},{DateTime.Now}");
            }

            await _dbContext.QuotesStatsRecords.AddAsync(new QuotesStatsRecordEntity()
            {
                StartTradeDate = int.Parse(startTradeDate.ToString("yyyyMMdd")),
                EndTradeDate = int.Parse(endTradeDate.ToString("yyyyMMdd")),
                QuotesStatsType = QuotesStatsType.Daily
            });

            IEnumerable<DailyEntity> ParseDailyEntity(DataModel data)
            {
                var result = new List<DailyEntity>();
                foreach (var item in data.Items)
                {
                    result.Add(new DailyEntity()
                    {
                        TS_Code = item[0] ?? string.Empty,
                        Trade_Date = item[1] ?? string.Empty,
                        Open = float.Parse(item[2] ?? "0"),
                        High = float.Parse(item[3] ?? "0"),
                        Low = float.Parse(item[4] ?? "0"),
                        Close = float.Parse(item[5] ?? "0"),
                        Pre_Close = float.Parse(item[6] ?? "0"),
                        Change = float.Parse(item[7] ?? "0"),
                        Percentage_Change = float.Parse(item[8] ?? "0"),
                        Volume = float.Parse(item[9] ?? "0"),
                        Amount = float.Parse(item[10] ?? "0")
                    });
                }

                return result;
            }

            async Task SaveDailyDataAsync(TuShareResponseModel response, StockEntity stockEntity)
            {
                var saveEntities = ParseDailyEntity(response.Data);
                int insertPageSize = 200, index = 0, errorNum = 0;
                var total = saveEntities.Count();

                // save to different market db
                var tableName = string.Empty;
                switch (stockEntity.Market)
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
                }

                if (string.IsNullOrEmpty(tableName))
                {
                    return;
                }

                while (insertPageSize * index < total)
                {
                    try
                    {
                        var insertConcatSql = string.Empty;
                        var currentItems = saveEntities.Skip(insertPageSize * index).Take(insertPageSize);
                        foreach (var item in currentItems)
                        {
                            insertConcatSql += $@"(N'{item.TS_Code}','{item.Trade_Date}',{item.Open},{item.High},{item.Low},{item.Close},{item.Pre_Close},{item.Change}
,{item.Percentage_Change},{item.Volume},{item.Amount},current_timestamp()),";
                        }

                        var sql = @$"insert into {tableName}
(TS_Code, Trade_Date, `Open`, High, Low, `Close`, Pre_Close, `Change`, Percentage_Change, Volume, Amount, CreatedOn)
values {insertConcatSql.Trim(',')};";
                        await _dbContext.Database.GetDbConnection().ExecuteAsync(sql);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Insert daily data error {TS_Code},ex: {@ex}", stockEntity.TS_Code, ex);
                        errorNum++;
                        if (errorNum > 3)
                        {
                            return;
                        }
                    }
                    finally
                    {
                        index++;
                    }
                }
            }
        }
    }
}
