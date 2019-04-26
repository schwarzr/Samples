using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DiaryContext _context;

        public EmployeeService(DiaryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId)
        {
            var query = _context.Employees.Where(p => p.ProjectId == projectId).Select(p => new EmployeeInfo
            {
                Id = p.Id,
                DisplayName = p.FirstName + " " + p.LastName
            });

            var data = await query.ToListAsync();

            return data;
        }
    }
}