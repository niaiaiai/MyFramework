using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace MyRepositories.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        public DbContext Context { get => _context; }

        private bool disposed = false;

        private TContext _context;
        private UnitOfWorkOptions _options;

        public UnitOfWork(TContext context, IOptions<UnitOfWorkOptions> options)
        {
            _context = context;
            _context.Database.AutoTransactionsEnabled = options.Value.IsAutoTransactions;
            _options = options.Value;
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected async Task DisposeAsync(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_options.IsAutoCommit)
                    {
                        await SaveChangesAsync();
                    }
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public async virtual ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
    }
}
