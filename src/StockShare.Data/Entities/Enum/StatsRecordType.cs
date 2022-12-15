using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Data.Entities.Enum
{
    public enum StatsRecordType
    {
        /// <summary>
        /// Unkown
        /// </summary>
        Unkown = 0,

        /// <summary>
        /// Daily Quote
        /// </summary>
        DailyQuote = 1,

        /// <summary>
        /// Monthly
        /// </summary>
        Monthly = 2,

        /// <summary>
        /// Yearly
        /// </summary>
        Yearly = 3
    }
}
