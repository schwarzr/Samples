using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Rest;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    [RestRoute("api/project")]
    public interface IProjectService
    {
        [RestGet("search/{name}")]
        Task<ProjectInfo> GetProjectByNameAsync(string name);

        [RestGet("all")]
        Task<IEnumerable<ProjectInfo>> GetProjectsAsync();
    }
}