using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppGateway.Api
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
            services.AddControllers();
            services.AddAuthentication()
                .AddJwtBearer("JWT", p =>
                {
                    p.Audience = Configuration.GetValue<string>("Authentication:ClientId");
                    p.Authority = Configuration.GetValue<string>("Authentication:Authority");
                    p.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(p =>
            {
                p.AddPolicy("default", builder => builder.RequireAuthenticatedUser().AddAuthenticationSchemes("JWT"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(p => p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
