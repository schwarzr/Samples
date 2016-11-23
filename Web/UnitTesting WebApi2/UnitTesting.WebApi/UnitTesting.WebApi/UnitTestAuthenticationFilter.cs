using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace UnitTesting.WebApi
{
    public class UnitTestAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var claims = new[] {
                    new Claim(ClaimTypes.Name,"UnitTestUser"),
                    new Claim(ClaimTypes.Role,"Admin"),
            };
            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "basic"));

            return Task.CompletedTask;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}