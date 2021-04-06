using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCore.DependencyInjection
{
    public interface IDependencyInjectionManager
    {
        void LoadAssemblies(IServiceCollection services);

        IServiceCollection Initialize(IServiceCollection services);
    }
}
