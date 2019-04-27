using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/area")]
    public interface IAreaController
    {
        [RestGet("infos")]
        Task<IEnumerable<AreaInfo>> GetAreaInfosAsync();
    }
}