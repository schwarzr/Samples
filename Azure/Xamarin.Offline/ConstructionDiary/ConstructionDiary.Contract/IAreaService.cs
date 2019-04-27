using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface IAreaService
    {
        Task<IEnumerable<AreaInfo>> GetAreaInfosAsync();
    }
}