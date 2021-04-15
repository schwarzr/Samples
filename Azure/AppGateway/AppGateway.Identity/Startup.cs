using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codeworx.Identity.AspNetCore;
using Codeworx.Identity.Configuration;
using Codeworx.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AppGateway.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddCodeworxIdentity(Configuration)
                .UseDbContext(p => p.UseSqlite("Data Source=identity.sqlite",
                                        x => x.MigrationsAssembly("Codeworx.Identity.EntityFrameworkCore.Migrations.Sqlite")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<IdentityOptions> identityOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(p => p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCodeworxIdentity(identityOptions.Value);
        }
    }
}
