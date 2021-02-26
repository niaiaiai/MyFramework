using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCore.Application
{
    public abstract class ApplicationInitialization : IApplicationInitialization
    {
        public void Configure(ApplicationInitializationContext context)
        {
            //var app = context.ServiceProvider.GetApplicationBuilder();
            //var env = serviceProvider.GetEnvironment();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
