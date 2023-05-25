using AutoMapper;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.User
{
    public class UserForListVm : IMapFrom<YourLocalization.Domain.Model.User>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.User, UserForListVm>();
        }
    }
}