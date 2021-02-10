using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace MyAuthorization.Data
{
    public class Ids4PersistedGrantDbContext : PersistedGrantDbContext<Ids4PersistedGrantDbContext>
    {
        public Ids4PersistedGrantDbContext(DbContextOptions<Ids4PersistedGrantDbContext> options, OperationalStoreOptions storeOptions)
            : base(options, storeOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ids4ops");
            base.OnModelCreating(modelBuilder);
        }
    }
}
