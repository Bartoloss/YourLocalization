using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application.Interfaces
{
    public interface IUserService
    {
        ListUserForListVm GetAllUsersForList(int pageSize, int pageNo, string searchString);

        int AddUser(NewUserVm user);

        UserDetailsVm GetUserDetails(string customerId);
    }
}