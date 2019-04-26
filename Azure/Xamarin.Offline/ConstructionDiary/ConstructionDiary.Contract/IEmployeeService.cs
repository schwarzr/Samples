using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId);
    }
}