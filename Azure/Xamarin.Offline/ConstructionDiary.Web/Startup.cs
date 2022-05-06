using System;
using System.Linq;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Codeworx.Synchronization.Configuration;
using Codeworx.Synchronization;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ConstructionDiary.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSync();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.Use(next => async (ctx) =>
            {
                await next(ctx);
                if (ctx.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    ctx.Request.Path = "/index.html";
                    await next(ctx);
                }
            });

            app.UseStaticFiles();

            app.UseEndpoints(map =>
            {
                map.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services
                .AddControllers()
                .AddRestContract()
                .AddApplicationPart(Assembly.Load(new AssemblyName("ConstructionDiary.Service")));

            services.AddOpenApiDocument();

            services.AddSyncEndpoint(builder => builder.AddEntityFrameworkCore<SqlDiaryContext>().UseSqlServer(Configuration.GetConnectionString("DiaryContext")));
            services.AddSyncScenario<ProjectFilterScenario>(Constants.ScenarioId, "Project Filter");

            services.AddPlugins(
                new Lucile.Configuration.Plugin.PluginOptions
                {
                    Assemblies = {
                        "ConstructionDiary.Service"
                    }
                });

            services.AddDbContext<DiaryContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("DiaryContext")));
            //services.AddDbContext<DiaryContext>(builder => builder.UseSqlite("Filename=c:\\Temp\\whatever.sqlite"));

            //services.AddDbContext<DiaryContext>(builder => builder.UseSqlServer("Data Source=.;Initial Catalog=ConstructionDiary; Integrated Security=True;"));

            if (_env.IsDevelopment())
            {
                using (var sp = services.BuildServiceProvider())
                {
                    var ctx = sp.GetRequiredService<DiaryContext>();
                    if (ctx.Database.EnsureCreated())
                    {
                        DataHelper.InsertData(ctx);

                        var statement = $"ALTER DATABASE [{ctx.Database.GetDbConnection().Database}] SET ALLOW_SNAPSHOT_ISOLATION ON";
                        ctx.Database.ExecuteSqlCommand(statement);
                    }
                }
            }
        }
    }
}