using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface IProjectService
    {
        Task<ProjectInfo> GetProjectByNameAsync(string name);

        Task<IEnumerable<ProjectInfo>> GetProjectsAsync();
    }
}