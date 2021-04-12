using Microsoft.Extensions.DependencyInjection;
using MyCore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoreTest
{
    public class DependencyInjectionManagerTest
    {
        private readonly IServiceCollection _service;
        private readonly IDependencyInjectionManager _manager;

        public DependencyInjectionManagerTest()
        {
            _service = new ServiceCollection();
            _manager = new DependencyInjectionManager(_service);
        }

        public async Task LoadAssemblies_Should_Load()
        {
        }
    }
}
