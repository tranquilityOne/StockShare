using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 科创板每日行情
    /// </summary>
    [Table("Daily_KCB")]
    public class Daily_KCB_Entity : DailyBasicEntity
    {
    }
}
