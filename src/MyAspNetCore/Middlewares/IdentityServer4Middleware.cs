using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCore.Middlewares
{
    public class IdentityServer4Middleware
    {
        private readonly RequestDelegate _next;
        private string _identityServerOrigin;
        public IdentityServer4Middleware(RequestDelegate next, string identityServerOrigin)
        {
            _next = next;
            _identityServerOrigin = identityServerOrigin;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.SetIdentityServerOrigin(_identityServerOrigin);
            await _next(context);
        }
    }
}
