using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Middleware
{
    public class AngularLandingPageMiddleware
    {
        private readonly RequestDelegate _next;

        public AngularLandingPageMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {

            await _next(ctx);

            if (ctx.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                ctx.Request.Path = "/index.html";
                await _next(ctx);
            }
        }
    }
}