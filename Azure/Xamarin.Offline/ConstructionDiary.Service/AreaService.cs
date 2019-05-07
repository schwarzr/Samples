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
    public class AreaService : IAreaService
    {
        private readonly DiaryContext _context;

        public AreaService(DiaryContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<AreaInfo>> GetAreaInfosAsync(Guid projectId)
        {
            var data = await _context.Areas.Where(p => p.ProjectId == projectId).Select(p => new AreaInfo { Id = p.Id, AreaName = p.AreaName }).ToListAsync();

            return data;
        }
    }
}