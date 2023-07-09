using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.Subtype
{
    public class NewSubtypeVm : IMapFrom<YourLocalization.Domain.Model.Subtype>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public List<YourLocalization.Domain.Model.Type> Types { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewSubtypeVm, YourLocalization.Domain.Model.Subtype>().ReverseMap();
        }
    }

    public class NewSubtypeValidation : AbstractValidator<NewSubtypeVm>
    {
        public NewSubtypeValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.TypeId).NotEmpty();
        }
    }
}
