using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codeworx.Synchronization;
using Codeworx.Synchronization.Configuration;
using ConstructionDiary.Database.Entities;

namespace ConstructionDiary.Web
{
    public class Constants
    {
        static Constants()
        {
            ProjectParameter = new FilterParameter<Project, Guid>("Project Filter", new Guid("{58EEA45A-431E-4B42-8F4D-A17CC9D9CC05}"), p => p.Id, p => p.ProjectName);
        }

        public static FilterParameter<Guid> ProjectParameter { get; }

        public static Guid ScenarioId { get; } = Guid.Parse("{87D2E88E-461E-4824-86F4-A130D22C2E73}");
    }
}