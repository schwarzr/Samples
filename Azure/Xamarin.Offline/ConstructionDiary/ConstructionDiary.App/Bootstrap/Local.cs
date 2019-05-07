using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Codeworx.Synchronization.Configuration;
using ConstructionDiary.Api;
using ConstructionDiary.Api.Client;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.App.ViewModels;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConstructionDiary.App.Bootstrap
{
    public class Local
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "diary.sqlite");

            var connectionString = $"Filename={path}";

            services = Common.Register(services)
                .AddConnectedLocal<ICountryController, CountryController>()
                .AddScoped<ICountryService, CountryService>()
                .AddConnectedLocal<IProjectController, ProjectController>()
                .AddScoped<IProjectService, ProjectService>()
                .AddConnectedLocal<IAreaController, AreaController>()
                .AddScoped<IAreaService, AreaService>()
                .AddConnectedLocal<IIssueController, IssueController>()
                .AddScoped<IIssueService, IssueService>()
                .AddConnectedLocal<IEmployeeController, EmployeeController>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddTransient<OfflineStateViewModel>()
                .AddTransient<IStateViewModel>(p => p.GetRequiredService<OfflineStateViewModel>())
                .AddDbContext<DiaryContext>(p => p.UseSqlite(connectionString, options => options.AddChangeTracking()))
                ;

            services
                .AddSync()
                .Source(p => p.AddEntityFrameworkCore<DiaryContext>().UseSqlite(connectionString, options => options.AddChangeTracking()))
                .Target((p, sp) => p.AddRest(sp.GetRequiredService<IOptions<AppOptions>>().Value.ServerUrl + "sync"));

            return services;
        }
    }
}