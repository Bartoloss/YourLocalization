using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLocalization.Application.ViewModels.Address
{
    public class ListAddressesForViewVm
    {
        public List<AddressForViewVm> Addresses { get; set; }
        public int Count { get; set; }
    }
}
