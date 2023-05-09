using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Services
{
    /// <summary>
    /// Inteface of dailyquotes
    /// </summary>
    public interface IDailyQuotesService
    {
        /// <summary>
        /// Sync Daily Quotes
        /// </summary>
        public Task SyncDailyQuotesAsync(IEnumerable<string> ts_Codes, string startDate, string endDate);
    }
}
