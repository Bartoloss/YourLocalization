using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Point;

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
