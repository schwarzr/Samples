using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfo>> GetAllUserInfosAsync();
    }
}