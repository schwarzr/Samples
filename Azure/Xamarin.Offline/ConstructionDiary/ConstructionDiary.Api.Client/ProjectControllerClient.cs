using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Client
{
    public class ProjectControllerClient : RestClient<IProjectController>, IProjectController
    {
        public ProjectControllerClient(RestOptions options)
            : base(options)
        {
        }

        public Task<ProjectInfo> GetProjectByNameAsync(string name)
        {
            return CallAsync(p => p.GetProjectByNameAsync(name));
        }

        public Task<IEnumerable<ProjectInfo>> GetProjectsAsync()
        {
            return CallAsync(p => p.GetProjectsAsync());
        }
    }
}