using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application.Interfaces
{
    public interface IUserService
    {
        ListUserForListVm GetAllUsersForList();
        int AddUser(NewUserVm user);
        UserDetailsVm GetUserDetails(int customerId);
    }
}
