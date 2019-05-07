using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface IIssueService
    {
        Task CreateIssueAsync(IssueCreateItem item);

        Task DeleteIssueTypeAsync(Guid id);

        Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId);

        Task<IssueTypeListItem> GetIssueTypeAsync(Guid id);

        Task<IEnumerable<IssueTypeListItem>> GetIssueTypeListItemsAsync();

        Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync();

        Task InsertIssueTypeAsync(IssueTypeListItem issue);

        Task UpdateIssueTypeAsync(IssueTypeListItem issue);
    }
}