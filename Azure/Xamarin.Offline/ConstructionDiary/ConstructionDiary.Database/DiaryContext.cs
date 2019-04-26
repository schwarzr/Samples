using ConstructionDiary.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Database
{
    public class DiaryContext : DbContext
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
    }
}