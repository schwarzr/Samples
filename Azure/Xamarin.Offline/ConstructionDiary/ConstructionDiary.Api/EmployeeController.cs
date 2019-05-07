using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api
{
    public class EmployeeController : IEmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        public Task DeleteAsync(Guid id)
        {
            return _employeeService.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId)
        {
            return await _employeeService.GetEmployeeInfos(projectId);
        }

        public Task<EmployeeListItem> GetEmployeeListItemAsync(Guid id)
        {
            return _employeeService.GetEmployeeListItemAsync(id);
        }

        public Task<IEnumerable<EmployeeListItem>> GetEmployeeListItemsAsync(Guid projectId)
        {
            return _employeeService.GetEmployeeListItemsAsync(projectId);
        }

        public Task InsertAsync(Guid projectId, EmployeeListItem item)
        {
            return _employeeService.InsertAsync(projectId, item);
        }

        public Task UpdateAsync(EmployeeListItem item)
        {
            return _employeeService.UpdateAsync(item);
        }
    }
}