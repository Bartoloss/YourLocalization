using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.ViewModels.Address;
using YourLocalization.Application.ViewModels.Point;

namespace YourLocalization.Application.Interfaces
{
    public interface IAddressService
    {
        ListAddressesForViewVm GetUserAdressesForView(string userId);

        int AddAddress(NewAddressVm newAddressVm);

        NewAddressVm GetAddressForEdit(int id);

        void UpdateAddress(NewAddressVm updateAddressVm);

        void DeleteAddress(int id);
    }
}
