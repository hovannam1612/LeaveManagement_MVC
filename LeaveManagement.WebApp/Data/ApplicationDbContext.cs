using LeaveManagement.WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveHistory> LeaveHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //change identity table
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                    entityType.SetTableName(tableName.Substring(6));
            }
        }

        public override int SaveChanges()
        {
            BeforeSaveChange();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            BeforeSaveChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void BeforeSaveChange()
        {
            var entities = ChangeTracker.Entries();
            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;
                if (entity.Entity is IBaseEntity<Guid> asEntity)
                {
                    if (entity.State == EntityState.Added)
                    {
                        asEntity.CreatedOn = now;
                        asEntity.UpdatedOn = now;
                    }
                    if (entity.State == EntityState.Modified)
                    {
                        asEntity.UpdatedOn = now;
                    }
                }
            }
        }
    }
}