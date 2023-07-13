using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.ViewModels.Point;

namespace YourLocalization.Application.ViewModels.Address
{
    public class AddressForViewVm : IMapFrom<YourLocalization.Domain.Model.Address>
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.Address, AddressForViewVm>();
        }
    }
}
