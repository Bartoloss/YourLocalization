﻿using AutoMapper;
using FluentValidation;
using YourLocalization.Application.Mapping;

namespace YourLocalization.Application.ViewModels.Point
{
    public class NewPointVm : IMapFrom<YourLocalization.Domain.Model.Point>
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int SubtypeId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<YourLocalization.Domain.Model.Type> Types { get; set; }
        public List<YourLocalization.Domain.Model.Subtype> Subtypes { get; set; }

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