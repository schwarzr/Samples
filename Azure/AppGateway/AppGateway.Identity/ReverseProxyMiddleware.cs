using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AppGateway.Identity
{
    public class ReverseProxyMiddleware
    {
        private readonly RequestDelegate _next;

        public ReverseProxyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if (ctx.Request.Headers.TryGetValue("x-original-host", out var host))
            {
                ctx.Request.Host = new HostString(host);
            }
            else if (ctx.Request.Headers.TryGetValue("x-forwared-host", out host))
            {
                ctx.Request.Host = new HostString(host);
            }

            if (ctx.Request.Headers.TryGetValue("x-forwarded-proto", out var proto))
            {
                ctx.Request.Scheme = proto;
            }

            if (ctx.Request.Headers.TryGetValue("x-forwarded-pathbase", out var pathBase))
            {
                ctx.Request.PathBase = new PathString(pathBase);
            }


            await _next(ctx);
        }
    }
}