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
using Microsoft.Extensions.Options;

namespace ConstructionDiary.App.Bootstrap
{
    public class Remote
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            return Common.Register(services)
                            .AddScoped(sp =>
                            {
                                var options = sp.GetRequiredService<IOptionsSnapshot<AppOptions>>();
                                return new RestOptions(options.Value.ServerUrl);
                            })
                            .AddConnectedLocal<ICountryController, CountryControllerClient>()
                            .AddConnectedLocal<IProjectController, ProjectControllerClient>()
                            .AddConnectedLocal<IAreaController, AreaControllerClient>()
                            .AddConnectedLocal<IIssueController, IssueControllerClient>()
                            .AddConnectedService<IOfflineController>()
                            .AddConnectedLocal<IOfflineController, OfflineControllerClient>()
                            .AddTransient<OnlineStateViewModel>()
                            .AddTransient<IStateViewModel>(p => p.GetRequiredService<OnlineStateViewModel>());
        }
    }
}