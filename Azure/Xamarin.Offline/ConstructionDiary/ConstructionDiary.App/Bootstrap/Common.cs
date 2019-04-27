using System;
using System.Collections.Generic;
using System.Text;
using ConstructionDiary.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App.Bootstrap
{
    public class Common
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            return services
                        .AddSingleton<ApplicationViewModel>()
                        .AddSingleton<INavigationController, AppNavigationController>()
                        .AddSingleton<ICurrentProjectService, CurrentProjectService>()
                        .AddTransient<MenuViewModel>()
                        .AddTransient<DashboardViewModel>()
                        .AddTransient<AreasViewModel>()
                        .AddTransient<CreateIssueViewModel>();
        }
    }
}