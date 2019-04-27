using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Web;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Service
{
    public class OfflineService : IOfflineService

    {
        public async Task<byte[]> GetOfflineDBAsync(Guid projectId)
        {
            var temp = Path.GetTempFileName();
            var builder = new DbContextOptionsBuilder<DiaryContext>();

            builder.UseSqlite($"Filename={temp}");

            using (var ctx = new DiaryContext(builder.Options))
            {
                await ctx.Database.EnsureCreatedAsync();
                DataHelper.InsertData(ctx);
                await ctx.SaveChangesAsync();
            }

            using (var fs = new FileStream(temp, FileMode.Open, FileAccess.Read))
            using (var ms = new MemoryStream())
            {
                await fs.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}