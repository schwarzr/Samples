using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Codeworx.Synchronization.Configuration;
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
                .AddConnectedService<ICountryService>()
                .AddConnectedService<IProjectService>()
                .AddConnectedService<IAreaService>()
                .AddConnectedService<IIssueService>()
                .AddConnectedService<IEmployeeService>()
                .AddConnectedLocal<ICountryService, CountryService>()
                .AddConnectedLocal<IProjectService, ProjectService>()
                .AddConnectedLocal<IAreaService, AreaService>()
                .AddConnectedLocal<IIssueService, IssueService>()
                .AddConnectedLocal<IEmployeeService, EmployeeService>()
                .AddScopeProxy()
                .AddTransient<OfflineStateViewModel>()
                .AddTransient<IStateViewModel>(p => p.GetRequiredService<OfflineStateViewModel>())
                .AddDbContext<DiaryContext>(p => p.UseSqlite(connectionString, options => options.AddChangeTracking()))
                ;

            services
                .AddSync()
                .Source(p => p.AddEntityFrameworkCore<DiaryContext>().UseSqlite(connectionString, options => options.AddChangeTracking()))
                .Target(p => p.AddRest(sp => new HttpClient { BaseAddress = new Uri(sp.GetRequiredService<IOptions<AppOptions>>().Value.ServerUrl + "sync") }));

            return services;
        }
    }
}