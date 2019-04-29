﻿using System;
using System.Linq;
using ConstructionDiary.Api;
using ConstructionDiary.AspNetCore.Mvc;
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

namespace ConstructionDiary.Web
{
    public class Startup
    {
        public const string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ConstructionDiary; Integrated Security=True;";

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

            app.UseSync();

            app.UseMvc();

            app.UseSwagger();
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
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApiExplorer()
                .AddApplicationPart(typeof(EmployeeController).Assembly)
                .AddJsonFormatters(options => options.ContractResolver = new CamelCasePropertyNamesContractResolver());

            //var toRemove = services.Where(p => p.ServiceType == typeof(IActionDescriptorProvider)).ToList();
            //toRemove.ForEach(p => services.Remove(p));
            services.AddSingleton<IApplicationModelProvider, ContractModelProvider>();

            //services.AddSingleton<IActionDescriptorProvider, ContractDescriptorProvider>();

            services.AddSwaggerDocument();

            services.AddSyncEndpoint((builder, sp) => builder.AddEntityFrameworkCore<SqlDiaryContext>().UseSqlServer(ConnectionString));
            services.AddSyncScenario<ProjectFilterScenario>(Constants.ScenarioId, "Project Filter");

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IOfflineService, OfflineService>();

            services.AddDbContext<DiaryContext>(builder => builder.UseSqlServer(ConnectionString));
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
                    }
                }
            }
        }
    }
}