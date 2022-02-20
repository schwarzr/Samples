using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Codeworx.Rest;

namespace ConstructionDiary.Contract
{
    [RestRoute("api/offline")]
    public interface IOfflineService
    {
        [RestGet("db/{projectId}")]
        Task<byte[]> GetOfflineDBAsync(Guid projectId);
    }
}