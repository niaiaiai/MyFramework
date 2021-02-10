using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRepositories.UnitOfWork;

namespace MyRepositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork<Context>(this IServiceCollection services) where Context : DbContext
        {
            services.Configure<UnitOfWorkOptions>(options =>
            {
                options.IsAutoTransactions = true;
            });
            //services.AddDefaultRepository();
            services.AddScoped<IUnitOfWork, UnitOfWork<Context>>();
            return services;
        }

        //public static IServiceCollection AddDefaultRepository(this IServiceCollection services)
        //{
        //    services.AddScoped(typeof(IReadOnlyRepository<>), typeof(GenericRepository<,>));
        //    services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<,>));
        //    services.AddScoped(typeof(IReadOnlyRepository<,>), typeof(GenericRepository<,,>));
        //    services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,,>));
        //    return services;
        //}

        //public static IServiceCollection AddDefaultRepository<BaseEntityType, EntityTypePk>(this IServiceCollection services, Type entityType, Type repositoryImplementationType)
        //{
        //    //IReadOnlyRepository<Entity>
        //    var readOnlyRepositoryInterface = typeof(IReadOnlyRepository<>).MakeGenericType(entityType);
        //    if (readOnlyRepositoryInterface.IsAssignableFrom(repositoryImplementationType))
        //    {
        //        services.TryAddTransient(readOnlyRepositoryInterface, repositoryImplementationType);
        //    }

        //    //IRepository<Entity>
        //    var repositoryInterface = typeof(IRepository<>).MakeGenericType(entityType);
        //    if (repositoryInterface.IsAssignableFrom(repositoryImplementationType))
        //    {
        //        services.TryAddTransient(repositoryInterface, repositoryImplementationType);
        //    }

        //    var primaryKeyType = EntityHelper.FindPrimaryKeyType(entityType, typeof(EntityTypePk), typeof(BaseEntityType));
        //    if (primaryKeyType != null)
        //    {
        //        //IReadOnlyRepository<TEntity, TKey>
        //        var readOnlyRepositoryInterfaceWithPk = typeof(IReadOnlyRepository<,>).MakeGenericType(entityType, primaryKeyType);
        //        if (readOnlyRepositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
        //        {
        //            services.TryAddTransient(readOnlyRepositoryInterfaceWithPk, repositoryImplementationType);
        //        }

        //        //IRepository<TEntity, TKey>
        //        var repositoryInterfaceWithPk = typeof(IRepository<,>).MakeGenericType(entityType, primaryKeyType);
        //        if (repositoryInterfaceWithPk.IsAssignableFrom(repositoryImplementationType))
        //        {
        //            services.TryAddTransient(repositoryInterfaceWithPk, repositoryImplementationType);
        //        }
        //    }

        //    return services;
        //}
    }
}
