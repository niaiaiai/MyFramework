using Microsoft.Extensions.DependencyInjection;

namespace MyCore.DependencyInjection
{
    public interface IDefaultConfigureServices
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        IServiceCollection ConfigureServices(IServiceCollection services);
    }
}
