using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.AspNetCore.Client;

namespace ConstructionDiary.Api.Client
{
    public class OfflineControllerClient : RestClient<IOfflineController>, IOfflineController
    {
        public OfflineControllerClient(RestOptions options) : base(options)
        {
        }

        public Task<byte[]> GetOfflineDBAsync(Guid projectId)
        {
            return CallAsync(p => p.GetOfflineDBAsync(projectId));
        }
    }
}