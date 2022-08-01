using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockShare.Data.Entities
{
    [Table("Stock")]
    public class StockEntity : EntityBase
    {
        /// <summary>
        /// TS 代码
        /// </summary>
        [Column(TypeName ="nvarchar(50)")]
        public string TS_Code { get; set; } = default!;

        /// <summary>
        /// 股票代码
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Symbol { get; set; } = default!;

        /// <summary>
        /// 股票名称
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        /// <summary>
        /// 地域
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string? Area { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string? Industry { get; set; }

        /// <summary>
        /// 股票全程
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string? FullName { get; set; }

        /// <summary>
        /// 英文全称
        /// </summary>
        [Column(TypeName = "nvarchar(200)")]
        public string? EnName { get; set; }

        /// <summary>
        /// 拼音缩写
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string? CnSpell { get; set; }

        /// <summary>
        /// 市场类型 （主板/创业板/科创板/CDR）
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string? Market { get; set; }

        /// <summary>
        /// 上市状态  L上市 D退市 P暂停上市
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string? List_Status { get; set; }

        /// <summary>
        /// 上市日期
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string? List_Date { get; set; }

        /// <summary>
        /// 退市日期
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string? Delist_Date { get; set; }

        /// <summary>
        /// 是否沪股通,N否 H沪股通 S深股通
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string? IS_HS { get; set; }
    }
}
