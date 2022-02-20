using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Codeworx.Rest;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    [RestRoute("api/employee")]
    public interface IEmployeeService
    {
        [RestDelete("{id}")]
        Task DeleteAsync(Guid id);

        [RestGet("{projectId}/all")]
        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId);

        [RestGet("{id}")]
        Task<EmployeeListItem> GetEmployeeListItemAsync(Guid id);

        [RestGet("{projectId}/list")]
        Task<IEnumerable<EmployeeListItem>> GetEmployeeListItemsAsync(Guid projectId);

        [RestPost("{projectId}")]
        Task InsertAsync(Guid projectId, [BodyMember] EmployeeListItem item);

        [RestPut]
        Task UpdateAsync([BodyMember] EmployeeListItem item);
    }
}