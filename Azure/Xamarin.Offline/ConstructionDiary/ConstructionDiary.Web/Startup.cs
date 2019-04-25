using System;
using ConstructionDiary.Api;
using ConstructionDiary.AspNetCore.Mvc;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace ConstructionDiary.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApplicationPart(typeof(UserController).Assembly)
                .AddJsonFormatters(options => options.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddSingleton<IActionDescriptorProvider, ContractDescriptorProvider>();

            services.AddScoped<IUserService, UserService>();
            services.AddDbContext<DiaryContext>(builder => builder.UseSqlServer("Data Source=.;Initial Catalog=ConstructionDiary; Integrated Security=True;"));

            if (_env.IsDevelopment())
            {
                using (var sp = services.BuildServiceProvider())
                {
                    var ctx = sp.GetRequiredService<DiaryContext>();
                    if (ctx.Database.EnsureCreated())
                    {
                        ctx.Users.Add(new Database.Entities.User { Id = Guid.NewGuid(), FirstName = "Raphael", LastName = "Schwarz", Created = DateTime.Now, Login = "raphael@codeworx.at" });

                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}