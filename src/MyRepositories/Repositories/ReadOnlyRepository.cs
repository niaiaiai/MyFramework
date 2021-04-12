using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyRepositories.Repositories
{
    public abstract class ReadOnlyRepository<Entity> : IReadOnlyRepository<Entity> where Entity : class
    {
        public DbSet<Entity> query { get; }

        protected ReadOnlyRepository(DbSet<Entity> dbSet)
        {
            query = dbSet;
        }

        public virtual Task<Entity> GetAsync([NotNull] Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, object>> include = null)
        {
            return include == null ?
                query.Where(predicate).FirstOrDefaultAsync() :
                query.Where(predicate).Include(include).FirstOrDefaultAsync();
        }

        public virtual Task<IQueryable<Entity>> GetListAsync(Expression<Func<Entity, bool>> predicate = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, Expression<Func<Entity, object>> include = null)
        {
            IQueryable<Entity> result = query;

            if (predicate != null)
            {
                result = result.Where(predicate);
            }
            if (include != null)
            {
                result = result.Include(include);
            }
            if (orderBy != null)
            {
                result = orderBy(result);
            }
            return Task.FromResult(result);
        }
    }

    public abstract class ReadOnlyRepository<Entity, Key> : ReadOnlyRepository<Entity>, IReadOnlyRepository<Entity, Key> where Entity : class
    {
        protected ReadOnlyRepository(DbSet<Entity> dbSet) : base(dbSet) { }

        public abstract Task<Entity> GetAsync(Key id);
    }
}
