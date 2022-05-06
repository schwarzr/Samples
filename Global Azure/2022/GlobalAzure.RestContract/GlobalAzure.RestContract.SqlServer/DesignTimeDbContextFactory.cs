using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAzure.RestContract.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GlobalAzure.RestContract.SqlServer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoContext>
    {
        public ToDoContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ToDoContext>()
                                .UseSqlServer("Data Source=.;Initial Catalog=ToDo;Integrated Security=True;",
                                p => p.MigrationsAssembly("GlobalAzure.RestContract.SqlServer"));

            return new ToDoContext(builder.Options);
        }
    }
}
