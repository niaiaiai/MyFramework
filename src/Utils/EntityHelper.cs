using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Utils
{
    public static class EntityHelper
    {
        public static Type FindPrimaryKeyType([NotNull] Type entityType, [NotNull] Type entityTypePk, [NotNull] Type baseEntityType)
        {
            if (!baseEntityType.IsAssignableFrom(entityType))
            {
                throw new Exception(
                    $"Given {nameof(entityType)} is not an entity. It should implement {baseEntityType.AssemblyQualifiedName}!");
            }

            foreach (var interfaceType in entityType.GetTypeInfo().GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == entityTypePk)
                {
                    return interfaceType.GenericTypeArguments[0];
                }
            }

            return null;
        }
    }
}
