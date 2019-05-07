using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api
{
    public class ProjectController : IProjectController
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            this._service = service;
        }

        public Task<ProjectInfo> GetProjectByNameAsync(string name)
        {
            return _service.GetProjectByNameAsync(name);
        }

        public Task<IEnumerable<ProjectInfo>> GetProjectsAsync()
        {
            return _service.GetProjectsAsync();
        }
    }
}