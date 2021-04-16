using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codeworx.Identity.Cryptography;
using Codeworx.Identity.EntityFrameworkCore;
using Codeworx.Identity.EntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppGateway.Identity.Extensions
{
    public static class AppGatewayIdentityHostExtensions
    {
        public static async Task InitialiizeAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var contex = scope.ServiceProvider.GetRequiredService<CodeworxIdentityDbContext>();

                var pending = await contex.Database.GetPendingMigrationsAsync();
                if (pending.Any())
                {
                    await contex.Database.MigrateAsync();
                    var hashing = scope.ServiceProvider.GetRequiredService<IHashingProvider>();

                    contex.ClientConfigurations.Add(new ClientConfiguration
                    {
                        Id = Guid.Parse("e43d7097-55e4-4369-9650-124601197dc6"),
                        ClientType = Codeworx.Identity.Model.ClientType.UserAgent,
                        ValidRedirectUrls = {
                            new ValidRedirectUrl { Url = "https://localhost:5001/" },
                            new ValidRedirectUrl { Url = "https://demo.codeworx.eu/" },
                            new ValidRedirectUrl { Url = "http://demo.codeworx.eu/" },
                            new ValidRedirectUrl { Url = "https://demo2.codeworx.eu/" },
                            new ValidRedirectUrl { Url = "http://demo2.codeworx.eu/" },
                            new ValidRedirectUrl { Url = "https://codeworx-demo-view.azurewebsites.net/"}
                        }
                    });

                    contex.Users.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        PasswordHash = hashing.Create("admin")
                    });


                    contex.AuthenticationProviders.Add(new AuthenticationProvider
                    {
                        Name = "Forms",
                        EndpointType = "forms",

                    });

                    await contex.SaveChangesAsync();
                }
            }
        }
    }

}
