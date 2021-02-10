using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyRepositories.Repositories
{
    public abstract class Repository<Context, Entity> : ReadOnlyRepository<Entity>, IRepository<Entity> where Entity : class where Context : DbContext
    {
        public Repository(Context context) : base(context.Set<Entity>()) { }

        public virtual Task DeleteAsync(IEnumerable<Entity> entities)
        {
            query.RemoveRange(entities);
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(Entity entity)
        {
            query.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Expression<Func<Entity, bool>> predicate)
        {
            IQueryable<Entity> entities = await GetListAsync(predicate);
            await DeleteAsync(entities.ToArray());
        }

        public virtual Task InsertAsync(IEnumerable<Entity> entities)
        {
            return query.AddRangeAsync(entities);
        }
        public virtual Task InsertAsync(Entity entity)
        {
            return query.AddAsync(entity).AsTask();
        }

        public virtual Task UpdateAsync(IEnumerable<Entity> entities)
        {
            query.UpdateRange(entities);
            return Task.CompletedTask;
        }
        public virtual Task UpdateAsync(Entity entity)
        {
            query.Update(entity);
            return Task.CompletedTask;
        }
    }

    public abstract class Repository<Context, Entity, Key> : Repository<Context, Entity>, IRepository<Entity, Key> where Entity : class where Context : DbContext
    {
        public Repository(Context context) : base(context) { }

        public virtual async Task DeleteAsync(Key id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                query.Remove(entity);
            }
        }

        public virtual Task<Entity> GetAsync(Key id)
        {
            return query.FindAsync(id).AsTask();
        }
    }
}
