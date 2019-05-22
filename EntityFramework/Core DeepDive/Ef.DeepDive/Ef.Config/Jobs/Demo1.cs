using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ef.DeepDive.Database;
using Ef.DeepDive.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ef.Config.Jobs
{
    public class Demo1
    {
        public async Task ProcessAsync()
        {
            using (var db = new EventContext())
            {
                await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();

                var speakers = Data.CreateSpeakers(10).ToList();
                await db.Speakers.AddRangeAsync(speakers);
                await db.SaveChangesAsync();

                using (new Measure())
                {
                    await db.Sessions.AddRangeAsync(Data.CreateSessions(speakers, 1000));
                    await db.SaveChangesAsync();
                }
            }

            var factory = new LoggerFactory();
            factory.AddConsole(LogLevel.Information);

            var builder = new DbContextOptionsBuilder<EventContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=AdcSample; Integrated Security=True;")
                .UseLoggerFactory(factory);

            using (var db = new EventContext(builder.Options))
            {
                await db.Speakers.CountAsync();

                using (new Measure())
                {
                    var data = await db.Speakers.Include(p => p.Sessions).ToListAsync();

                    Console.WriteLine($"got {data.Count} speaker");

                    var s = data.First();
                    db.Entry(s)
                        .Property("IsDeleted").CurrentValue = true;

                    await db.SaveChangesAsync();
                }
            }

            using (var db = new EventContext(builder.Options))
            {
                var count = await db.Speakers.CountAsync();

                Console.WriteLine($"SpeakerCount {count}");
            }
        }
    }
}
