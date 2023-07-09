using AutoMapper;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.Type
{
    public class TypeForListVm : IMapFrom<YourLocalization.Domain.Model.Type>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.Type, TypeForListVm>();
        }
    }
}