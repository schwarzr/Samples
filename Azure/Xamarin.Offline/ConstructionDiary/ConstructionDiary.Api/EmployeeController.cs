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

        public async Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId)
        {
            return await _employeeService.GetEmployeeInfos(projectId);
        }
    }
}