using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api
{
    public class IssueController : IIssueController
    {
        private readonly IEmployeeService _employeeService;

        private readonly IIssueService _service;

        public IssueController(IIssueService service, IEmployeeService employeeService)
        {
            this._service = service;
            this._employeeService = employeeService;
        }

        public async Task<IssueCreateData> GetIssueCreateAsync(Guid projectId)
        {
            var result = new IssueCreateData();
            result.Employees = await _employeeService.GetEmployeeInfos(projectId);
            result.IssueTypes = await _service.GetIssueTypesAsync();

            return result;
        }

        public Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId)
        {
            return _service.GetIssuesAsync(projectId);
        }

        public Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync()
        {
            return _service.GetIssueTypesAsync();
        }

        public Task InsertIssueAsync(IssueCreateItem issue)
        {
            return _service.CreateIssueAsync(issue);
        }
    }
}