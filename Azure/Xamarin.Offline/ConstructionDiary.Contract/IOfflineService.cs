using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionDiary.Contract
{
    public interface IOfflineService
    {
        Task<byte[]> GetOfflineDBAsync(Guid projectId);
    }
}