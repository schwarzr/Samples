using System;
using ConstructionDiary.App.ViewModels;
using ConstructionDiary.Client.Generated;
using ConstructionDiary.Contract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConstructionDiary.App.Bootstrap
{
    public class Remote
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            Common.Register(services)
                            .AddPlugins(new Lucile.Configuration.Plugin.PluginOptions
                            {
                                Assemblies = {
                                    "ConstructionDiary.Client"
                                }
                            })
                            .AddTransient<OnlineStateViewModel>()
                            .AddTransient<IStateViewModel>(p => p.GetRequiredService<OnlineStateViewModel>())
                            .AddRestClient()
                            .WithHttpClient((sp, client) => { client.BaseAddress = new Uri(sp.GetRequiredService<IOptions<AppOptions>>().Value.ServerUrl); });

            return services;
        }
    }
}