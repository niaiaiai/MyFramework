using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MyCore.DependencyInjection
{
    public class DependencyInjectionBase
    {
        public DependencyInjectionBase(IServiceCollection services)
        {
            //get assemblies
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var dlls = Directory.GetFiles(path).Where(f => Path.GetExtension(f) == ".dll");
            List<Assembly> assemblies = new();
            foreach (string dll in dlls)
            {
                assemblies.Add(Assembly.LoadFrom(dll));
            }
            assemblies = assemblies.Union(AppDomain.CurrentDomain.GetAssemblies()).ToList();

            //get types
            List<Type> types = new();
            foreach (Assembly assembly in assemblies)
            {
                types.AddRange(assembly.GetTypes().Where(t => t.IsClass && typeof(IDefaultConfigureServices).IsAssignableFrom(t)));
            }

            foreach (Type type in types)
            {
                services.AddScoped(typeof(IDefaultConfigureServices), type);
            }

            Init(services);
        }

        protected IServiceCollection Init(IServiceCollection services)
        {
            using (IServiceScope scope = services.BuildServiceProvider().GetService<IServiceScopeFactory>().CreateScope())
            {
                var configureProviders = scope.ServiceProvider.GetServices<IDefaultConfigureServices>();
                foreach (var provider in configureProviders)
                {
                    provider.ConfigureServices(services);
                }
            }
            return services;
        }
    }
}
