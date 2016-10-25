using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseIntegration.Ediweb.Filters
{
    public class PassthroughBasicAuthentication : BasicAuthenticationAttribute
    {
        protected async override Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.UserData,password)
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, "basic"));
        }
    }
}