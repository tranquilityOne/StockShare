using Microsoft.EntityFrameworkCore;
using StockShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockShare.Data
{
    public partial class StockShareContext : DbContext
    {
        /// <summary>
        /// Members
        /// </summary>
        public DbSet<MemberEntity> Members => Set<MemberEntity>();

        /// <summary>
        /// Stocks
        /// </summary>
        public DbSet<StockEntity> Stocks => Set<StockEntity>();

        /// <summary>
        /// Daily_ZB
        /// </summary>
        public DbSet<Daily_ZB_Entity> Daily_ZB => Set<Daily_ZB_Entity>();

        /// <summary>
        /// Daily_CYB
        /// </summary>
        public DbSet<Daily_CYB_Entity> Daily_CYB => Set<Daily_CYB_Entity>();

        /// <summary>
        /// Daily_BJS
        /// </summary>
        public DbSet<Daily_BJS_Entity> Daily_BJS => Set<Daily_BJS_Entity>();

        /// <summary>
        /// Daily_KCB
        /// </summary>
        public DbSet<Daily_KCB_Entity> Daily_KCB => Set<Daily_KCB_Entity>();

        /// <summary>
        /// Daily_ZXB
        /// </summary>
        public DbSet<Daily_ZXB_Entity> Daily_ZXB => Set<Daily_ZXB_Entity>();

        /// <summary>
        /// QuotesStatsRecords
        /// </summary>
        public DbSet<StatsRecordEntity> StatsRecords => Set<StatsRecordEntity>();

        /// <summary>
        /// DailyBasic
        /// </summary>
        public DbSet<DailyBasicEntity> DailyBasic => Set<DailyBasicEntity>();

        public void OnBusinessModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasIndex(e => e.LoginName).IsUnique();
            });

            modelBuilder.Entity<StockEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasIndex(e => e.TS_Code).IsUnique();
                e.HasIndex(e => e.Symbol).IsUnique();
            });

            ModelBuilderDailyEntity<Daily_ZB_Entity>(modelBuilder);
            ModelBuilderDailyEntity<Daily_CYB_Entity>(modelBuilder);
            ModelBuilderDailyEntity<Daily_BJS_Entity>(modelBuilder);
            ModelBuilderDailyEntity<Daily_KCB_Entity>(modelBuilder);
            ModelBuilderDailyEntity<Daily_ZXB_Entity>(modelBuilder);

            modelBuilder.Entity<StatsRecordEntity>(e =>
            {
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<DailyBasicEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasIndex(e => new { e.Trade_Date, e.TS_Code }).IsUnique();
            });
        }

        private void ModelBuilderDailyEntity<T>(ModelBuilder modelBuilder)
            where T : DailyBasicEntity
        {
            modelBuilder.Entity<T>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasIndex(e => new { e.TS_Code, e.Trade_Date }).IsUnique();
                e.HasIndex(e => e.TS_Code);
                e.HasIndex(e => e.Trade_Date);
                e.HasIndex(e => e.Pct_Change);
                e.HasIndex(e => e.Volume);
                e.HasIndex(e => e.Amount);
            });
        }
    }
}
