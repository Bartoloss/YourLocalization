using AutoMapper;
using FluentValidation;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application.ViewModels.Point
{
    public class NewPointVm : IMapFrom<YourLocalization.Domain.Model.Point>
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
            profile.CreateMap<NewPointVm, YourLocalization.Domain.Model.Point>();
        }
    }

    public class NewPointValidation : AbstractValidator<NewPointVm>
    {
        public NewPointValidation()
        {

        }
    }
}