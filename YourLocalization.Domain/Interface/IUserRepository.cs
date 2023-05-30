using YourLocalization.Domain.Model;

namespace YourLocalization.Domain.Interface
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllActiveUsers();

        User? GetUser(string userId);

        string AddUser(User user);
    }
}