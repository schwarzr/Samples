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
        [RestGet("{projectId}/create")]
        Task<IssueCreateData> GetIssueCreateAsync(Guid projectId);

        [RestGet("{projectId}/list")]
        Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId);

        [RestGet("types")]
        Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync();

        [RestPost]
        Task InsertIssueAsync([BodyMember] IssueCreateItem issue);
    }
}