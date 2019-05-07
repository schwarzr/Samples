using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codeworx.Synchronization.Configuration;
using ConstructionDiary.Database.Entities;

namespace ConstructionDiary.Web
{
    public class ProjectFilterScenario : ISyncScenario
    {
        public void ApplySetup(IModelConfigurationBuilder provider)
        {
            provider.Entity<Project>(
                p => p.Filter(x => x.Id, Constants.ProjectParameter)
                );
        }
    }
}