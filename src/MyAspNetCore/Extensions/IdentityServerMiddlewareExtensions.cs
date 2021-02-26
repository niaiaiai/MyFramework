using Microsoft.AspNetCore.Builder;
using MyAspNetCore.Middlewares;

namespace MyAspNetCore.Extensions
{
    public static class IdentityServerMiddlewareExtensions
    {
        public static IApplicationBuilder UserIdentityServerOrigin(this IApplicationBuilder app, string identityServerOrigin)
        {
            return app.UseMiddleware<IdentityServer4Middleware>(identityServerOrigin);
        }
    }
}
