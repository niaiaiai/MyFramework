using Microsoft.EntityFrameworkCore;
using MyEntity.Audit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyEntityFrameworkCore
{
    public abstract class DbContextBase<TDbContext> : DbContext where TDbContext : DbContext
    {
        public DbContextBase(DbContextOptions<TDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddSoftDelete();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess = true)
        {
            beforeSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            beforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void beforeSaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted when typeof(ISoftDelete).IsAssignableFrom(entry.Entity.GetType()):
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(ISoftDelete.IsDeleted)] = true;
                        break;
                    case EntityState.Added when typeof(ICreationTime).IsAssignableFrom(entry.Entity.GetType()):
                        entry.CurrentValues[nameof(ICreationTime.CreationTime)] = DateTime.Now;
                        break;
                    case EntityState.Modified when typeof(IModifyTime).IsAssignableFrom(entry.Entity.GetType()):
                        entry.CurrentValues[nameof(IModifyTime.ModifyTime)] = DateTime.Now;
                        break;
                }
            }
        }
    }
}
