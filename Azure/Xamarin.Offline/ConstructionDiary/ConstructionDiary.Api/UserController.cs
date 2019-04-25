using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.Api
{
    public class UserController : IUserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<IEnumerable<UserInfo>> GetAllUserInfosAsync()
        {
            return await _userService.GetAllUserInfosAsync();
        }
    }
}