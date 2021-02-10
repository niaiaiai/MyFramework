using Microsoft.AspNetCore.Builder;
using MyAuthorization.Middlewares.DataInitMiddlewares;

namespace MyAuthorization.Extensions
{
    public static class MiddlewaresExtensions
    {
        public static IApplicationBuilder UseDataInit(this IApplicationBuilder app)
        {
            app.UseMiddleware<DataInitMiddleware>(app);
            return app;
        }
    }
}
