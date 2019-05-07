using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api
{
    public class AreaController : IAreaController
    {
        private readonly IAreaService _service;

        public AreaController(IAreaService service)
        {
            this._service = service;
        }

        public Task<IEnumerable<AreaInfo>> GetAreaInfosAsync(Guid projectId)
        {
            return _service.GetAreaInfosAsync(projectId);
        }
    }
}