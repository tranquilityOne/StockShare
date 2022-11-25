using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
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
    /// TuShareStockService
    /// </summary>
    public class TuShareStockBasicService : IStockBasicService
    {
        private const string Stock_Basic_Fields = "ts_code,symbol,name,area,industry,fullname,enname,cnspell,market,list_status,list_date,delist_date,is_hs";
        private const string Stock_Basic_Api = "stock_basic";

        private readonly ILogger<TuShareStockBasicService> _logger;
        private readonly TuShareApiRequestService _tuShareWebService;
        private readonly StockShareContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TuShareStockBasicService"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="tuShareWebService"></param>
        /// <param name="dbContext"></param>
        public TuShareStockBasicService(ILogger<TuShareStockBasicService> logger,
            TuShareApiRequestService tuShareWebService,
            StockShareContext dbContext)
        {
            _logger = logger;
            _tuShareWebService = tuShareWebService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// SyncStockBasicInfo
        /// </summary>
        public async Task SyncStockBasicInfo()
        {
            var response = await _tuShareWebService.PostAsync(new TuShareStockBasicRequest()
            {
                List_status = "L"
            }, Stock_Basic_Api, Stock_Basic_Fields);

            if (response != null && response.Code == "0")
            {
                var saveEntities = ParseStockBasicEntity(response.Data);
                int insertPageSize = 100, index = 0, errorNum = 0;
                var total = saveEntities.Count();

                while (insertPageSize * index < total)
                {
                    try
                    {
                        var insertConcatSql = string.Empty;
                        var currentItems = saveEntities.Skip(insertPageSize * index).Take(insertPageSize);
                        foreach (var item in currentItems)
                        {
                            insertConcatSql += $@"
('{item.TS_Code}','{item.Symbol}',N'{item.Name}',N'{item.Area}',N'{item.Industry}',N'{item.FullName}',""{item.EnName}"",'{item.CnSpell}',N'{item.Market}',
N'{item.List_Status}','{item.List_Date}','{item.Delist_Date}',N'{item.IS_HS}',current_timestamp()),";
                        }

                        var sql = @$"
insert into stock(TS_Code, Symbol, Name, Area, Industry, FullName, EnName, CnSpell, Market, List_Status,List_Date, Delist_Date, IS_HS, CreatedOn)
values {insertConcatSql.TrimEnd(',')} as new
on duplicate key update
Name = new.Name,Industry = new.Industry,FullName = new.FullName,EnName = new.EnName,CnSpell = new.CnSpell,
List_Status = new.List_Status,List_Date=new.List_Date,Delist_Date = new.Delist_Date,IS_HS = new.IS_HS;";

                        await _dbContext.Database.GetDbConnection().ExecuteAsync(sql);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Insert stock data error {ex}", ex);
                        if (errorNum > 5)
                        {
                            return;
                        }

                        errorNum++;
                    }
                    finally
                    {
                        index++;
                    }
                }
            }

            IEnumerable<StockEntity> ParseStockBasicEntity(DataModel data)
            {
                // parse to model
                var saveEntities = new List<StockEntity>();
                foreach (var item in data.Items)
                {
                    saveEntities.Add(new StockEntity()
                    {
                        TS_Code = item[0] ?? string.Empty,
                        Symbol = item[1] ?? string.Empty,
                        Name = item[2] ?? string.Empty,
                        Area = item[3] ?? string.Empty,
                        Industry = item[4] ?? string.Empty,
                        FullName = item[5] ?? string.Empty,
                        EnName = item[6] ?? string.Empty,
                        CnSpell = item[7] ?? string.Empty,
                        Market = item[8] ?? string.Empty,
                        List_Status = item[9] ?? string.Empty,
                        List_Date = item[10] ?? string.Empty,
                        Delist_Date = item[11] ?? string.Empty,
                        IS_HS = item[12] ?? string.Empty
                    });
                }

                return saveEntities;
            }
        }
    }
}
