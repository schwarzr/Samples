using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;

namespace ConstructionDiary.Api
{
    public class OfflineController : IOfflineController
    {
        private readonly IOfflineService _service;

        public OfflineController(IOfflineService service)
        {
            _service = service;
        }

        public Task<byte[]> GetOfflineDBAsync(Guid projectId)
        {
            return _service.GetOfflineDBAsync(projectId);
        }
    }
}