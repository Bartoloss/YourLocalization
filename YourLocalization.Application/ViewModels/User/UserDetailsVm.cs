using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Mapping;
using YourLocalization.Domain.Model;

namespace YourLocalization.Application.ViewModels.User
{
    public class UserDetailsVm : IMapFrom<YourLocalization.Domain.Model.User>
    {
        public int Id { get; set; }
        public string FirstAndLastName { get; set; }
        public string Email { get; set; }
        public List<AddressForListVm> Addresses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.User, UserDetailsVm>()
                .ForMember(s => s.FirstAndLastName, opt => opt.MapFrom(d => d.FirstName + " " + d.LastName))
                .ForMember(s => s.Addresses, opt => opt.Ignore());
            
        }
    }
}
