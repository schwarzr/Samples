using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ef.DeepDive.Database;
using Ef.DeepDive.Database.Context;
using Ef.DeepDive.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ef.Config.Jobs
{
    public class Demo4
    {
        public async Task ProcessAsync()
        {
            var factory = new LoggerFactory();
            //factory.AddConsole(LogLevel.Information);

            var builder = new DbContextOptionsBuilder<EventContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=AdcSample3; Integrated Security=True;")
                .UseLoggerFactory(factory);

            List<Speaker> speakers;

            // SQL Batch Processor
            using (var db = new EventContext(builder.Options))
            {
                await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();

                speakers = Data.CreateSpeakers(10).ToList();
                await db.Speakers.AddRangeAsync(speakers);
                await db.SaveChangesAsync();

                using (new Measure())
                {
                    await db.Sessions.AddRangeAsync(Data.CreateSessions(speakers, 100000));
                    await db.SaveChangesAsync();
                }
            }

            builder = new DbContextOptionsBuilder<EventContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=AdcSample3; Integrated Security=True;")
                .AddBulk()
                .UseLoggerFactory(factory);

            // Bulk Batch Processor
            using (var db = new EventContext(builder.Options))
            {
                using (new Measure())
                {
                    await db.Sessions.AddRangeAsync(Data.CreateSessions(speakers, 100000));
                    await db.SaveChangesAsync();
                }
            }


            // Raw Bulk
            using (var db = new EventContext(builder.Options))
            {
                using (new Measure())
                {
                    await db.BulkInsertAsync(Data.CreateSessions(speakers, 100000), p => p.PropagateValues(false));
                }
            }
        }
    }
}
