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

        public async Task DeleteAsync(Guid id)
        {
            var dbItem = await _context.Employees.FirstAsync(p => p.Id == id);
            _context.Employees.Remove(dbItem);

            await _context.SaveChangesAsync();
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

        public async Task<EmployeeListItem> GetEmployeeListItemAsync(Guid id)
        {
            var data = await _context.Employees
                .Where(p => p.Id == id)
                .Select(p => new EmployeeListItem
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Created = p.Created,
                    IsDisabled = p.IsDisabled
                })
                .FirstAsync();

            return data;
        }

        public async Task<IEnumerable<EmployeeListItem>> GetEmployeeListItemsAsync(Guid projectId)
        {
            var data = await _context.Employees
                .Where(p => p.ProjectId == projectId)
                .Select(p => new EmployeeListItem
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Created = p.Created,
                    IsDisabled = p.IsDisabled
                })
                .ToListAsync();

            return data;
        }

        public async Task InsertAsync(Guid projectId, EmployeeListItem item)
        {
            _context.Employees.Add(new Database.Entities.Employee
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Created = DateTime.Now,
                ProjectId = projectId
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeListItem item)
        {
            var dbItem = await _context.Employees.FirstAsync(p => p.Id == item.Id);

            dbItem.FirstName = item.FirstName;
            dbItem.LastName = item.LastName;

            await _context.SaveChangesAsync();
        }
    }
}