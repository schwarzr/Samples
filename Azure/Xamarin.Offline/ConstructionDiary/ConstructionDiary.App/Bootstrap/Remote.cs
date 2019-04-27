using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConstructionDiary.Api;
using ConstructionDiary.Api.Client;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.App.ViewModels;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App.Bootstrap
{
    public class Remote
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            return Common.Register(services)
                            .AddSingleton(new RestOptions("http://192.168.8.100:5001/"))
                            .AddScoped<ICountryController, CountryControllerClient>()
                            .AddScoped<IProjectController, ProjectControllerClient>()
                            .AddScoped<IAreaController, AreaControllerClient>()
                            .AddScoped<IIssueController, IssueControllerClient>()
                            .AddScoped<IOfflineController, OfflineControllerClient>()
                            .AddTransient<OnlineStateViewModel>()
                            .AddTransient<IStateViewModel>(p => p.GetRequiredService<OnlineStateViewModel>());
        }
    }
}