using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if (ctx.Request.Headers.ContainsKey("x-lang"))
            {
                var cultureCode = ctx.Request.Headers["x-lang"].First();
                var ci = CultureInfo.GetCultureInfo(cultureCode);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }
            else
            {
                var path = ctx.Request.Path.Value.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var cultureCode = path.First();
                var ci = CultureInfo.GetCultureInfo(cultureCode);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;

                ctx.Request.Path = "/" + string.Join("/", path.Skip(1));

            }


            await _next(ctx);

        }
    }
}