using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface IEmployeeService
    {
        Task DeleteAsync(Guid id);

        Task<IEnumerable<EmployeeInfo>> GetEmployeeInfos(Guid projectId);

        Task<EmployeeListItem> GetEmployeeListItemAsync(Guid id);

        Task<IEnumerable<EmployeeListItem>> GetEmployeeListItemsAsync(Guid projectId);

        Task InsertAsync(Guid projectId, EmployeeListItem item);

        Task UpdateAsync(EmployeeListItem item);
    }
}