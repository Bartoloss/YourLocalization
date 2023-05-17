using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;

namespace YourLocalization.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<User> GetAllActiveUsers()
        {
            return _context.Users.Where(p => p.IsActive);
        }

        public User GetUser(string userId)
        {
            return _context.Users.First(p => p.Id == userId);
        }

    }
}
