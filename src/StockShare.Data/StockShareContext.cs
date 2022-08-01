using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockShare.Data.Entities;

namespace StockShare.Data
{
    /// <summary>
    /// StockShareContext
    /// </summary>
    public partial class StockShareContext : DbContext
    {
        public StockShareContext(DbContextOptions<StockShareContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildEntityBaseColumns(modelBuilder);
            OnBusinessModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc/>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            // should be called at the last step
            UpdateOperationTime();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <inheritdoc/>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            // should be called at the last step
            UpdateOperationTime();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void BuildEntityBaseColumns(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(EntityBase).IsAssignableFrom(e.ClrType));

            foreach (var entityType in entityTypes)
            {
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(EntityBase.CreatedOn))
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp");
                modelBuilder
                    .Entity(entityType.ClrType)
                    .Property(nameof(EntityBase.LatestUpdatedOn))
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp");
            }
        }

        private void UpdateOperationTime()
        {
            var currentDateTime = DateTime.Now;

            var addedEntries = ChangeTracker
                .Entries<EntityBase>()
                .Where(entry => entry.State == EntityState.Added);
            var modifiedEntries = ChangeTracker
                .Entries<EntityBase>()
                .Where(entry => entry.State == EntityState.Modified);

            foreach (var entry in addedEntries)
            {
                entry.Entity.CreatedOn = currentDateTime;
                entry.Entity.LatestUpdatedOn = currentDateTime;
            }

            foreach (var entry in modifiedEntries)
            {
                entry.Entity.LatestUpdatedOn = currentDateTime;
            }
        }
    }
}
