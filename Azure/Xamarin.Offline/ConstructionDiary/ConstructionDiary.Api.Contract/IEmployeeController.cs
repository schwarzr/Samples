using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/employee")]
    public interface IEmployeeController
    {
        [RestGet("{projectId}/all")]
        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId);
    }
}