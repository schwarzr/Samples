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

        Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId);

        Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync();
    }
}