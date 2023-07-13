using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Address;
using YourLocalization.Application.ViewModels.User;
using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;

namespace YourLocalization.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IMapper _mapper;
        public int AddAddress(NewAddressVm newAddressVm)
        {
            Address newAddress = _mapper.Map<Address>(newAddressVm);
            int id = _addressRepo.AddAddress(newAddress);
            return id;
        }

        public void DeleteAddress(int id)
        {
            _addressRepo.DeleteAddress(id);
        }

        public NewAddressVm GetAddressForEdit(int id)
        {
            Address address = _addressRepo.GetAddressById(id);
            NewAddressVm addressVm = _mapper.Map<NewAddressVm>(address);
            return addressVm;
        }

        public ListAddressesForViewVm GetUserAdressesForView(string userId)
        {
            List<AddressForViewVm> addresses = _addressRepo.GetUserAddress(userId)
                .ProjectTo<AddressForViewVm>(_mapper.ConfigurationProvider).ToList();
            ListAddressesForViewVm addressesToView = new ListAddressesForViewVm()
            {
                Addresses=addresses,
                Count=addresses.Count
            };
            return addressesToView;
        }

        public void UpdateAddress(NewAddressVm updateAddressVm)
        {
            Address address = _mapper.Map<Address>(updateAddressVm);
            _addressRepo.UpdateAddress(address);
        }

    }
}
