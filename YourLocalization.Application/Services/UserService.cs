using AutoMapper;
using AutoMapper.QueryableExtensions;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.User;
using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;

namespace YourLocalization.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public int AddUser(NewUserVm user)
        {
            throw new NotImplementedException();
        }

        public ListUserForListVm GetAllUsersForList(int pageSize, int pageNo, string searchString)
        {
            List<UserForListVm> users = _userRepo.GetAllActiveUsers().Where(p => p.FirstName.StartsWith(searchString) || p.LastName.StartsWith(searchString) || p.UserName.StartsWith(searchString))
                .ProjectTo<UserForListVm>(_mapper.ConfigurationProvider).ToList();
            List<UserForListVm> usersToShow = users.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListUserForListVm usersForList = new ListUserForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Users = usersToShow,
                Count = users.Count
            };
            return usersForList;
        }

        public UserDetailsVm GetUserDetails(string userId)
        {
            User user = _userRepo.GetUser(userId);
            UserDetailsVm userVm = _mapper.Map<UserDetailsVm>(user);

            userVm.Addresses = new List<AddressForListVm>();

            foreach (AddressDetail address in user.Adresses)
            {
                AddressForListVm newAddress = new AddressForListVm()
                {
                    Id = address.Id,
                    NameAddress = address.NameAddress,
                    Street = address.Street,
                    BuildingNumber = address.BuildingNumber,
                    FlatNumber = address.FlatNumber,
                    ZipCode = address.ZipCode,
                    City = address.City,
                    Country = address.Country
                };
                userVm.Addresses.Add(newAddress);
            }
            return userVm;
        }
    }
}