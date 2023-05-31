using AutoMapper;
using FluentValidation;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.User
{
    public class NewUserVm : IMapFrom<YourLocalization.Domain.Model.User>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewUserVm, YourLocalization.Domain.Model.User>();
        }
    }

    public class NewUserValidation : AbstractValidator<NewUserVm>
    {
        public NewUserValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(20);
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).MaximumLength(60);
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).MaximumLength(60);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.PhoneNumber).Length(9);
        }
    }
}