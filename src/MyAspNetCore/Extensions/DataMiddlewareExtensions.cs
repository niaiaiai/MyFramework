using Microsoft.AspNetCore.Builder;
using MyAspNetCore.Middlewares.DataInitMiddlewares;

namespace MyAspNetCore.Extensions
{
    public static class DataMiddlewareExtensions
    {
        public static IApplicationBuilder UseDataInit(this IApplicationBuilder app)
        {
            app.UseMiddleware<DataInitMiddleware>(app);
            return app;
        }
    }
}
