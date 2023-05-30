using Microsoft.EntityFrameworkCore;
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

        public string AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public IQueryable<User> GetAllActiveUsers()
        {
            return _context.Users.Where(p => p.IsActive);
        }

        public User GetUser(string userId)
        {
            return _context.Users.Include(x => x.Addresses).First(p => p.Id == userId);
        }
    }
}