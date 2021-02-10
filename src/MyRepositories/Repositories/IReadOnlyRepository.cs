using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyRepositories.Repositories
{
    public interface IReadOnlyRepository<Entity> where Entity : class
    {
        Task<IQueryable<Entity>> GetListAsync(
            Expression<Func<Entity, bool>> predicate = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            Expression<Func<Entity, object>> include = null);

        Task<Entity> GetAsync(
            Expression<Func<Entity, bool>> predicate = null,
            Expression<Func<Entity, object>> include = null);
    }

    public interface IReadOnlyRepository<Entity, Key> : IReadOnlyRepository<Entity> where Entity : class
    {
        Task<Entity> GetAsync(Key id);
    }
}
