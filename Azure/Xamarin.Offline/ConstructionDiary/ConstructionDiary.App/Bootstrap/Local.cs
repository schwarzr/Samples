using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConstructionDiary.Api;
using ConstructionDiary.Api.Client;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.App.ViewModels;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App.Bootstrap
{
    public class Local
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "diary.sqlite");

            return Common.Register(services)
                .AddScoped<ICountryController, CountryController>()
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<IProjectController, ProjectController>()
                .AddScoped<IProjectService, ProjectService>()
                .AddScoped<IAreaController, AreaController>()
                .AddScoped<IAreaService, AreaService>()
                .AddScoped<IIssueController, IssueController>()
                .AddScoped<IIssueService, IssueService>()
                .AddScoped<IEmployeeController, EmployeeController>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddTransient<OfflineStateViewModel>()
                .AddTransient<IStateViewModel>(p => p.GetRequiredService<OfflineStateViewModel>())
                .AddDbContext<DiaryContext>(p => p.UseSqlite($"Filename={path}"));
        }
    }
}