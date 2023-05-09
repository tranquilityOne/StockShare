using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using StockShare.Data;
using StockShare.Data.Entities;
using StockShare.Data.Entities.Enum;
using StockShare.Services;
using StockShare.Services.Collection;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockShare.HostedServices
{
    /// <summary>
    /// The default implement of <see cref="IHostedService"/>.
    /// </summary>
    public class SyncHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly TimeSpan _timerPeriod = TimeSpan.FromMinutes(1);
        private Timer _timer = default!;
        private ILogger<SyncHostedService> _logger;
        private static bool executeFlag = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncHostedService"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceScopeFactory"></param>
        public SyncHostedService(
            ILogger<SyncHostedService> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        /// <inheritdoc/>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, 0, Timeout.Infinite);
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information($"{nameof(SyncHostedService)} is stopping.");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            try
            {
                // once a day
                if (DateTime.Now.Hour == 12)
                {
                    if (!executeFlag)
                    {
                        executeFlag = true;
                        await ExecuteSyncFinaIndicator();
                    }
                }
                else
                {
                    executeFlag = false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to run job in current period.");
            }
            finally
            {
                _timer?.Change(Convert.ToInt32(_timerPeriod.TotalMilliseconds), Timeout.Infinite);
            }
        }

        private async Task ExecuteSyncFinaIndicator()
        {
            var serviceScope = _serviceScopeFactory.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<StockShareContext>();
            _logger.LogInformation("Begin sync finance indicator..");
            var tuShareFinaIndicatorService = serviceScope.ServiceProvider.GetRequiredService<TuShareFinaIndicatorService>();
            var stocks = await dbContext.Stocks.Select(p => p.TS_Code).ToListAsync();
            var currentStasRecord = await dbContext.StatsRecords.Where(p => p.StatsRecordType == StatsRecordType.FinanceIndicator)
                .OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            string startDate = "20120101", endDate = DateTime.Now.ToString("yyyyMMdd");
            if (currentStasRecord != null)
            {
                 startDate = DateTime.ParseExact(currentStasRecord.EndTradeDate.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture)
                    .AddDays(1).ToString("yyyyMMdd");
            }

            await tuShareFinaIndicatorService.SyncFinIndicatorAsync(stocks, startDate, endDate, string.Empty);
            _logger.LogInformation("End sync finance indicator..");
        }
    }
}
