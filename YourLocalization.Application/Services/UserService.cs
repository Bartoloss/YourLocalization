using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ListUserForListVm GetAllUsersForList()
        {
            List<UserForListVm> users = _userRepo.GetAllActiveUsers()
                .ProjectTo<UserForListVm>(_mapper.ConfigurationProvider).ToList();
            ListUserForListVm usersForList = new ListUserForListVm()
            {
                Users = users,
                Count = users.Count
            };
            return usersForList;
        }

        public UserDetailsVm GetUserDetails(int customerId)
        {
            User user = _userRepo.GetUser(customerId);
            UserDetailsVm userVm = _mapper.Map<UserDetailsVm>(user);
            
            userVm.Addresses = new List<AddressForListVm>();
            
            foreach(AddressDetail address in user.Adresses)
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
