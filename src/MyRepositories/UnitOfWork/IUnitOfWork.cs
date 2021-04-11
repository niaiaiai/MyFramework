using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace MyRepositories.UnitOfWork
{

    public interface IUnitOfWork : IAsyncDisposable
    {

        Task<int> SaveChangesAsync();

        public DbContext Context { get; }
    }
}
