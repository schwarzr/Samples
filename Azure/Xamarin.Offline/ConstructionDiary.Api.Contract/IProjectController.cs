using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/project")]
    public interface IProjectController
    {
        [RestGet("search/{name}")]
        Task<ProjectInfo> GetProjectByNameAsync(string name);

        [RestGet("all")]
        Task<IEnumerable<ProjectInfo>> GetProjectsAsync();
    }
}