using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Client
{
    public class AreaControllerClient : RestClient<IAreaController>, IAreaController
    {
        public AreaControllerClient(RestOptions options)
            : base(options)
        {
        }

        public Task<IEnumerable<AreaInfo>> GetAreaInfosAsync(Guid projectId)
        {
            return CallAsync(p => p.GetAreaInfosAsync(projectId));
        }
    }
}