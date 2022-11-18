using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 北交所板块每日行情
    /// </summary>
    [Table("Daily_BJS")]
    public class Daily_BJS_Entity : DailyBasicEntity
    {
    }
}
