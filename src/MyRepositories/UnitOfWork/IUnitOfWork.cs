using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace MyRepositories.UnitOfWork
{

    public interface IUnitOfWork : IAsyncDisposable
    {
        //public IRepository<Entity, Key> GetRepository<Entity, Key>() where Entity : class;
        //public IRepository<Entity> GetRepository<Entity>() where Entity : class;

        Task<int> SaveChangesAsync();

        public Task<IDbContextTransaction> BeginAsync();

        public DbContext Context { get; }

        public Task CommitAsync();
    }
}
