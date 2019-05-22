using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ef.DeepDive.Database;
using Ef.DeepDive.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Ef.Config.Jobs
{
    public class Demo3
    {
        public async Task ProcessAsync()
        {
            using (var db = new EventContext())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}
