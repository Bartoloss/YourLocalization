using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.Services;

namespace YourLocalization.Application.ViewModels.Point
{
    public class NewPointVm : IMapFrom<YourLocalization.Domain.Model.Point>
    {
        private readonly TypeService _typeService;

        public NewPointVm(TypeService typeService)
        {
            _typeService = typeService;
        }
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        private SelectList _TypeSelectList { get; set; }
        public SelectList TypeSelectList
        {
            get
            {
                if (_TypeSelectList != null)
                    return _TypeSelectList;
                return new SelectList(_typeService.GetAllTypesToDropDownList());
            }
            set
            {
                _TypeSelectList = value;
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPointVm, YourLocalization.Domain.Model.Point>().ReverseMap();
        }
    }

    public class NewPointValidation : AbstractValidator<NewPointVm>
    {
        public NewPointValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.Street).MaximumLength(50);
            RuleFor(x => x.BuildingNumber).NotEmpty();
            RuleFor(x => x.BuildingNumber).MaximumLength(5);
            RuleFor(x => x.ZipCode).NotEmpty();
            RuleFor(x => x.ZipCode).Length(6);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).MaximumLength(50);
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Country).MaximumLength(50);
        }
    }
}