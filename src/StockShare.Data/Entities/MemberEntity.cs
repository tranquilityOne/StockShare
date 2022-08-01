using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// MemberEntity
    /// </summary>
    [Table("Member")]
    public class MemberEntity : EntityBase
    {
        /// <summary>
        /// RealName
        /// </summary>
        [StringLength(50)]
        public string? RealName { get; set; }

        /// <summary>
        /// LoginName
        /// </summary>
        [StringLength(50)]
        public string LoginName { get; set; } = default!;

        /// <summary>
        /// Password
        /// </summary>
        [StringLength(50)]
        public string? Password { get; set; }

        /// <summary>
        /// MobileArea
        /// </summary>
        [StringLength(10)]
        public string? MobileArea { get; set; }

        /// <summary>
        /// Mobile
        /// </summary>
        [StringLength(20)]
        public string? Mobile { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// MemberType
        /// </summary>
        public int MemberType { get; set; }

        /// <summary>
        /// Memeber Level
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Avatar
        /// </summary>
        [StringLength(500)]
        public string? Avatar { get; set; }
    }
}
