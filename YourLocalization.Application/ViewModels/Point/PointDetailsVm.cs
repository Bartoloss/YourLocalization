using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Mapping;
using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application.ViewModels.Point
{
    public class PointDetailsVm : IMapFrom<YourLocalization.Domain.Model.Point>
    {
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
