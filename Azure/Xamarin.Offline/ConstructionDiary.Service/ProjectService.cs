using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Service
{
    public class ProjectService : IProjectService
    {
        private readonly DiaryContext _context;

        public ProjectService(DiaryContext context)
        {
            this._context = context;
        }

        public async Task<ProjectInfo> GetProjectByNameAsync(string name)
        {
            var query = GetProjectInfoQuery();

            return await query.FirstOrDefaultAsync(p => p.DisplayString == name);
        }

        public async Task<IEnumerable<ProjectInfo>> GetProjectsAsync()
        {
            var query = GetProjectInfoQuery();

            var data = await query.ToListAsync();

            return data;
        }

        private IQueryable<ProjectInfo> GetProjectInfoQuery()
        {
            return _context.Projects.Select(p => new ProjectInfo { Id = p.Id, DisplayString = p.ProjectName });
        }
    }
}