using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 中小板每日行情
    /// </summary>
    [Table("Daily_ZXB")]
    public class Daily_ZXB_Entity : DailyEntity
    {
    }
}
