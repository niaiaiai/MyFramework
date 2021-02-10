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
        private IDbContextTransaction _transaction;
        private UnitOfWorkOptions _options;

        public UnitOfWork(TContext context, IOptions<UnitOfWorkOptions> options)
        {
            _context = context;
            _context.Database.AutoTransactionsEnabled = options.Value.IsAutoTransactions;
            _options = options.Value;
        }

        public virtual async Task<IDbContextTransaction> BeginAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
            return _transaction;
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
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                    }
                }
            }
            this.disposed = true;
        }

        //public virtual IRepository<Entity> GetRepository<Entity>() where Entity : class
        //{
        //    //return _provider.GetService(typeof(IRepository<Entity>)) as IRepository<Entity>;
        //    return new GenericRepository<Entity>(_context);
        //}

        //public virtual IRepository<Entity, Key> GetRepository<Entity, Key>() where Entity : class
        //{
        //    //return _provider.GetService(typeof(IRepository<Entity, Key>)) as IRepository<Entity, Key>;
        //    return new GenericRepository<Entity, Key>(_context);
        //}

        public virtual async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async virtual ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
    }
}
