using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/offline")]
    public interface IOfflineController
    {
        [RestGet("db")]
        Task<byte[]> GetOfflineDBAsync(Guid projectId);
    }
}