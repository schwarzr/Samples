using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GlobalAzure.RestContract.Database
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<DoToEntry> ToDoEntries { get; set; }
    }
}
