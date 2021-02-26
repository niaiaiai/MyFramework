using Microsoft.Extensions.DependencyInjection;

namespace MyCore.DependencyInjection
{
    public class DefaultConfigureServices : IDefaultConfigureServices
    {

        public virtual IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services;
        }
    }
}
