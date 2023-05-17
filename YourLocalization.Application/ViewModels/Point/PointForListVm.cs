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
