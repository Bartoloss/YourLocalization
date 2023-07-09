using AutoMapper;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.ViewModels.Type;
using YourLocalization.Domain.Model;

namespace YourLocalization.Application.ViewModels.Subtype
{
    public class SubtypeForListVm : IMapFrom<YourLocalization.Domain.Model.Subtype>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }
        public TypeDetailsVM TypeDetails { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.Subtype, SubtypeForListVm>();
        }
    }
}