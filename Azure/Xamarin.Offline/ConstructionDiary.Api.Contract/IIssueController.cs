using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/issue")]
    public interface IIssueController
    {
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

        [RestPost]
        Task InsertIssueAsync([BodyMember] IssueCreateItem issue);

        [RestPost("type")]
        Task InsertIssueTypeAsync([BodyMember] IssueTypeListItem issue);

        [RestPut("type")]
        Task UpdateIssueTypeAsync([BodyMember] IssueTypeListItem issue);
    }
}