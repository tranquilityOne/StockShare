using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Services
{
    /// <summary>
    /// IStockBasicService
    /// </summary>
    public interface IStockBasicService
    {
        /// <summary>
        /// Sync basics stock list infors
        /// </summary>
        public Task SyncStockBasicInfo();
    }
}
