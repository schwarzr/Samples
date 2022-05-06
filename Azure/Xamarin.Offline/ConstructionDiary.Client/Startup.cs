using System;
using System.Collections.Generic;
using System.Text;
using Lucile.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: Lucile.Extensions.DependencyInjection.ServiceConfiguration(typeof(ConstructionDiary.Client.Startup))]

namespace ConstructionDiary.Client
{
    public class Startup : IServiceConfiguration
    {
        public void Configure(IServiceCollection services)
        {
            services.AddRestClient()
                .AddRestProxies(typeof(Startup).Assembly);
        }
    }
}