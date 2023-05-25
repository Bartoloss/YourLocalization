using AutoMapper;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.Point
{
    public class PointForListVm : IMapFrom<YourLocalization.Domain.Model.Point>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.Point, PointForListVm>();
        }
    }
}