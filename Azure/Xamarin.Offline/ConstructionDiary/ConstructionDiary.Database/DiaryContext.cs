using System.Linq;
using Codeworx.Synchronization.EntityFrameworkCore;
using Codeworx.Synchronization.Model;
using Codeworx.Synchronization.Queryable;
using ConstructionDiary.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Database
{
    public class DiaryContext : SyncableDbContext

    {
        public DiaryContext(DbContextOptions<DiaryContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<IssueAttachment> IssueAttachments { get; set; }

        public DbSet<Issue> Issues { get; set; }

        public DbSet<IssueType> IssueTypes { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var nav in item.GetNavigations())
                {
                    nav.ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }
    }
}