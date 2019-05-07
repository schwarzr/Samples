using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Database;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Web
{
    public class SqlDiaryContext : DiaryContext
    {
        public SqlDiaryContext(DbContextOptions<SqlDiaryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddSqlServerChangeTracking(this.Database);
        }
    }
}