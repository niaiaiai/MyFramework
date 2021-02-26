using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyAspNetCore.DefaultStartup
{
    public class DefaultConfigure : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                //var env = app.ApplicationServices.GetService<IWebHostEnvironment>();
                //if (env.IsDevelopment())
                //{
                    app.UseDeveloperExceptionPage();
                //}
                next(app);
            };
        }
    }
}
