using AutoMapper;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.Point
{
    public class PointDetailsVm : IMapFrom<YourLocalization.Domain.Model.Point>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<YourLocalization.Domain.Model.Point, PointDetailsVm>();
        }
    }
}