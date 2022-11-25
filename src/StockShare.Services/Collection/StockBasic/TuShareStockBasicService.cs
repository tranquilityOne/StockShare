using Dapper;
using EFCore.BulkExtensions;
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
using System.Collections.Specialized;
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
        /// AutoSyncStockBasicInfo
        /// </summary>
        public async Task AutoSyncStockBasicInfo()
        {
            var listStatus = new string[] { "D", "L", "P", };
            var saveStockEntities = new List<StockEntity>();
            foreach (var item in listStatus)
            {
                var rsp = await _tuShareWebService.PostAsync(new TuShareStockBasicRequest()
                {
                    List_status = item
                }, Stock_Basic_Api, Stock_Basic_Fields);
                if (rsp != null && rsp.Code == "0")
                {
                    if (rsp.Data.Items.Any())
                    {
                        saveStockEntities.AddRange(ParseStockBasicEntity(rsp.Data));
                    }
                }
            }

            if (saveStockEntities.Any())
            {
                var bulkConfig = new BulkConfig() { BatchSize = 500 };
                await _dbContext.BulkInsertOrUpdateAsync(saveStockEntities, bulkConfig);
                await _dbContext.BulkSaveChangesAsync();
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
                        IS_HS = item[12] ?? string.Empty,
                        CreatedOn = DateTime.Now
                    });
                }

                return saveEntities;
            }
        }

        /// <inheritdoc/>
        public Task CustomSyncStockBasicInfo(IEnumerable<string> ts_Codes)
        {
            throw new NotImplementedException();
        }
    }
}
