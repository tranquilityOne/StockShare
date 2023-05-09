using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Data.Entities.Enum
{
    /// <summary>
    /// 财务报表类型
    /// </summary>
    public enum ReportEndType
    {
        /// <summary>
        /// Unkown
        /// </summary>
        Unkown = 0,

        /// <summary>
        /// 一季报
        /// </summary>
        First = 1,

        /// <summary>
        /// 中报
        /// </summary>
        Second = 2,

        /// <summary>
        /// 三季报
        /// </summary>
        Third = 3,

        /// <summary>
        /// 年报
        /// </summary>
        Fourth = 4
    }
}
