using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAzure.RestContract.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GlobalAzure.RestContract.Sqlite
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoContext>
    {
        public ToDoContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ToDoContext>()
                                .UseSqlite("Data Source=.;Initial Catalog=ToDo;Integrated Security=True;",
                                p => p.MigrationsAssembly("GlobalAzure.RestContract.Sqlite"));

            return new ToDoContext(builder.Options);
        }
    }
}
