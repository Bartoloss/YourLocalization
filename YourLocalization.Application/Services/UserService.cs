using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUserRepository userRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor;
        }

        public string AddUser(NewUserVm newUserVm)
        {
            User newUser = _mapper.Map<User>(newUserVm);
            newUser.IsActive = true;
            string id = _userRepo.AddUser(newUser);
            return id;
        }

        public ListUserForListVm GetAllUsersForList(int pageSize, int pageNo, string searchString)
        {
            List<UserForListVm> users = _userRepo.GetAllActiveUsers().Where(p => p.UserName.StartsWith(searchString))
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

            foreach (Address address in user.Addresses)
            {
                AddressForListVm newAddress = new AddressForListVm()
                {
                    Id = address.Id,
                    NameAddress = address.Name,
                    Street = address.Street,
                    BuildingNumber = address.BuildingNumber,
                    FlatNumber = address.FlatNumber,
                    ZipCode = address.ZipCode,
                    City = address.City,
                    Country = address.Country
                };
                userVm.Addresses.Add(newAddress);
            }
            userVm.AmountOfAddresses = userVm.Addresses.Count;

            return userVm;
        }

        public string GetUserId()
        {
            return _contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}