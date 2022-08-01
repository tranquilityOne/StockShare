using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 上海交易所每日行情
    /// </summary>
    [Table("Daily_ZB")]
    public class Daily_ZB_Entity : DailyEntity
    {
    }
}
