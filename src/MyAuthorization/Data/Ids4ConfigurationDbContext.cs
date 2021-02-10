using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace MyAuthorization.Data
{
    public class Ids4ConfigurationDbContext : ConfigurationDbContext<Ids4ConfigurationDbContext>
    {
        public Ids4ConfigurationDbContext(DbContextOptions<Ids4ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ids4config");
            base.OnModelCreating(modelBuilder);
        }
    }
}
