using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Synchronization;
using Codeworx.Synchronization.Configuration;
using Codeworx.Synchronization.Provider;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.Service
{
    public class OfflineService : IOfflineService

    {
        private readonly IConfiguration _configuration;

        private readonly IServiceProvider _provider;

        public OfflineService(IServiceProvider provider, IConfiguration configuration)
        {
            this._provider = provider;
            this._configuration = configuration;
        }

        public async Task<byte[]> GetOfflineDBAsync(Guid projectId)
        {
            var temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            var context = new DbContextOptionsBuilder<DiaryContext>();
            context.UseSqlite($"Filename={temp}", p => p.AddChangeTracking());

            using (var ctx = new DiaryContext(context.Options))
            {
                ctx.Database.EnsureCreated();
            }

            var builder = new SyncBuilder();
            builder.Target(p => p.AddEntityFrameworkCore<DiaryContext>().UseSqlServer(_configuration.GetConnectionString("DiaryContext")))
                .Source(p => p.AddEntityFrameworkCore<DiaryContext>().UseSqlite($"Filename={temp}"));

            using (var sync = builder.Build(_provider))
            {
                var modelProvider = sync.TargetSyncProvider as ISyncConfigurationProvider;

                var sourceId = await sync.SourceSyncProvider.GetPeerIdAsync();

                await modelProvider.EnsureRemotePeerAsync(sourceId, p => p.Name = $"xamarin dev {sourceId}");
                await modelProvider.SetScenarioAsync(sourceId, Constants.ScenarioId);

                await modelProvider.SaveParameterConfigurationAsync(
                    sourceId,
                    new[]{new FilterParameterConfiguration
                    {
                        ParameterId = Constants.ProjectParameter.ParameterId,
                        Values = { Codeworx.Synchronization.ChangeProperty.Create<Guid>(projectId) }
                    }
                    });
                await sync.RunAsync();

                using (var fs = new FileStream(temp, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    await fs.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}