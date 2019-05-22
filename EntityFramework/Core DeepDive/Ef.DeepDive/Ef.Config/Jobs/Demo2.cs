using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ef.DeepDive.Database;
using Ef.DeepDive.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ef.Config.Jobs
{
    public class Demo2
    {
        public async Task ProcessAsync()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Information))
                .AddDbContext<EventContext>(p => p.UseSqlServer("Data Source =.; Initial Catalog = AdcSample; Integrated Security = True; "));

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EventContext>();

                var context2 = scope.ServiceProvider.GetRequiredService<EventContext>();
            }
        }
    }
}
