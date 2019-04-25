using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api.Contract
{
    [RestRoute("api/user")]
    public interface IUserController
    {
        [RestGet]
        Task<IEnumerable<UserInfo>> GetAllUserInfosAsync();
    }
}