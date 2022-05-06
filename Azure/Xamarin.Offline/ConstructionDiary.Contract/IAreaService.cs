using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Rest;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    [RestRoute("api/area")]
    public interface IAreaService
    {
        [RestGet("{projectId}/infos")]
        Task<IEnumerable<AreaInfo>> GetAreaInfosAsync(Guid projectId);
    }
}