using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCore.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IDependencyInjectionManager Create(this IServiceCollection services)
        {
            return new DependencyInjectionManager(services);
        }
    }
}
