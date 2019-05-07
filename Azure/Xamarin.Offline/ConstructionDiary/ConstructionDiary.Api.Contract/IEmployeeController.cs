using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/employee")]
    public interface IEmployeeController
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
        Task InsertAsync(Guid projectId, [BodyMember]EmployeeListItem item);

        [RestPut]
        Task UpdateAsync([BodyMember]EmployeeListItem item);
    }
}