using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyRepositories.Repositories
{
    public interface IRepository<Entity> : IReadOnlyRepository<Entity> where Entity : class
    {
        Task InsertAsync(IEnumerable<Entity> entities);
        Task InsertAsync(Entity entity);

        Task UpdateAsync(IEnumerable<Entity> entities);
        Task UpdateAsync(Entity entity);

        Task DeleteAsync(IEnumerable<Entity> entities);
        Task DeleteAsync(Entity entity);

        Task DeleteAsync(Expression<Func<Entity, bool>> predicate);
    }

    public interface IRepository<Entity, Key> : IRepository<Entity>, IReadOnlyRepository<Entity, Key> where Entity : class
    {
        Task DeleteAsync(Key id);
    }
}
