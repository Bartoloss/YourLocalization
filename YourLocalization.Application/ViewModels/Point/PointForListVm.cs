using AutoMapper;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.ViewModels.Type;

namespace YourLocalization.Application.ViewModels.Point
{
    public class PointForListVm : IMapFrom<YourLocalization.Domain.Model.Point>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public TypeDetailsVM TypeDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.Point, PointForListVm>();
        }
    }
}