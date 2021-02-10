using Microsoft.EntityFrameworkCore;
using MyEntity.Audit;
using System.Linq;
using System.Linq.Expressions;

namespace MyEntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddSoftDelete(this ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().Where(e => typeof(ISoftDelete).IsAssignableFrom(e.ClrType));
            foreach (var entityType in entityTypes)
            {
                //Create the query filter
                var parameter = Expression.Parameter(entityType.ClrType);

                //EF.Property<bool>(post, "IsDeleted")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(nameof(ISoftDelete.IsDeleted)));

                // EF.Property<bool>(post, "IsDeleted") == false
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                // post => EF.Property<bool>(post, "IsDeleted") == false
                var lambdaExpression = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambdaExpression);
            }
            return modelBuilder;
        }
    }
}
