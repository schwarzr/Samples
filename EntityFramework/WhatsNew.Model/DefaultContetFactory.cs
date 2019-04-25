using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WhatsNew.Model
{
    public class DefaultContetFactory : IDbContextFactory<SampleContext>
    {
        public SampleContext Create(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source=.;Integrated Security=True;InitialCatalog=WhatsNew;");

            return new SampleContext(builder.Options);
        }
    }
}