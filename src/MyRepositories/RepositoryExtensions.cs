
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyRepositories
{
    public static class RepositoryExtensions
    {
        public static Task<IPageResult<Entity>> GetListToPageAsync<Entity>(
            this DbSet<Entity> query,
            int index,
            int pageSize = 10,
            Expression<Func<Entity, bool>> predicate = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            Expression<Func<Entity, object>> include = null) where Entity : class
        {
            var result = query.AsQueryable();
            if (predicate != null)
            {
                result = result.Where(predicate);
            }
            if (orderBy != null)
            {
                result = orderBy(result);
            }
            if (include != null)
            {
                result = result.Include(include);
            }

            IPageResult<Entity> pageResult = new PageResult<Entity>
            {
                Total = result.Count(),
                Data = result.Skip(index * pageSize).Take(pageSize)
            };
            return Task.FromResult(pageResult);
        }
    }
}
