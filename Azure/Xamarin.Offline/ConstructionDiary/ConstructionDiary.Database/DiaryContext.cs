using ConstructionDiary.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Database
{
    public class DiaryContext : DbContext
    {
        public DiaryContext(DbContextOptions<DiaryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}