using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Client
{
    public class IssueControllerClient : RestClient<IIssueController>, IIssueController
    {
        public IssueControllerClient(RestOptions options) : base(options)
        {
        }

        public Task<IssueCreateData> GetIssueCreateAsync(Guid projectId)
        {
            return CallAsync(p => p.GetIssueCreateAsync(projectId));
        }

        public Task<IEnumerable<IssueListItem>> GetIssuesAsync(Guid projectId)
        {
            return CallAsync(p => p.GetIssuesAsync(projectId));
        }

        public Task<IEnumerable<IssueTypeInfo>> GetIssueTypesAsync()
        {
            return CallAsync(p => p.GetIssueTypesAsync());
        }

        public Task InsertIssueAsync(IssueCreateItem issue)
        {
            return CallAsync(p => p.InsertIssueAsync(issue));
        }
    }
}