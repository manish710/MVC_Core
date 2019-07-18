using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_DemoApp.MiddleWare
{
    public class DemoMiddleware
    {
        private readonly RequestDelegate next;

        public DemoMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.WriteAsync("Inside Demo Middleware\n<br/>").Wait();
            await next(context);
            context.Response.WriteAsync("<br/>\nBack to Demo Middleware").Wait();
        }
    }
}
