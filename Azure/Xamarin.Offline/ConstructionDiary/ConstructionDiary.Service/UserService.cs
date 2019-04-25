using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Contract;
using ConstructionDiary.Database;
using ConstructionDiary.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.Service
{
    public class UserService : IUserService
    {
        private readonly DiaryContext _context;

        public UserService(DiaryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserInfo>> GetAllUserInfosAsync()
        {
            var query = _context.Users.Select(p => new UserInfo
            {
                Id = p.Id,
                DisplayName = p.FirstName != null || p.LastName != null ? p.FirstName + " " + p.LastName + "(" + p.Login + ")" : p.Login
            });

            var data = await query.ToListAsync();

            return data;
        }
    }
}