using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 创业板每日行情
    /// </summary>
    [Table("Daily_CYB")]
    public class Daily_CYB_Entity : DailyBasicEntity
    {
    }
}
