using AutoMapper;
using FluentValidation;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.Type
{
    public class NewTypeVm : IMapFrom<YourLocalization.Domain.Model.Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewTypeVm, YourLocalization.Domain.Model.Type>().ReverseMap();
        }
    }

    public class NewTypeValidation : AbstractValidator<NewTypeVm>
    {
        public NewTypeValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}