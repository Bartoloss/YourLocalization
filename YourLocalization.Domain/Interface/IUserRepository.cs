using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Domain.Model;

namespace YourLocalization.Domain.Interface
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllActiveUsers();
        User GetUser(string userId);  
    }
}
