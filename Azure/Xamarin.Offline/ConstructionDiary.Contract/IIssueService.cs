using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Rest;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    [RestRoute("api/issue")]
    public interface IIssueService
    {
        [RestPost]
        Task CreateIssueAsync(IssueCreateItem item);

        [RestDelete("type/{id}")]
        Task DeleteIssueTypeAsync(Guid id);

        [RestGet("{projectId}/create")]
        Task<IssueCreateData> GetIssueCreateAsync(Guid projectId);

        [RestGet("{projectId}/list")]
        Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId);

        [RestGet("types/{id}")]
        Task<IssueTypeListItem> GetIssueTypeAsync(Guid id);

        [RestGet("types/list")]
        Task<IEnumerable<IssueTypeListItem>> GetIssueTypeListItemsAsync();

        [RestGet("types")]
        Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync();

        [RestPost("type")]
        Task InsertIssueTypeAsync([BodyMember] IssueTypeListItem issue);

        [RestPut("type")]
        Task UpdateIssueTypeAsync([BodyMember] IssueTypeListItem issue);
    }
}