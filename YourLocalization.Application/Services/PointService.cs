using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.User;
using YourLocalization.Domain.Interface;

namespace YourLocalization.Application.Services
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepo;
        private readonly IMapper _mapper;

        public PointService(IPointRepository pointRepo, IMapper mapper)
        {
            _pointRepo = pointRepo;
            _mapper = mapper;
        }


        public int AddPoint(NewPointVm user)
        {
            throw new NotImplementedException();
        }

        public ListPointForListVm GetAllPointsForList()
        {
            List<PointForListVm> points = _pointRepo.GetAllPoints()
               .ProjectTo<PointForListVm>(_mapper.ConfigurationProvider).ToList();
            ListPointForListVm pointsForList = new ListPointForListVm()
            {
                Points = points,
                Count = points.Count
            };
            return pointsForList;
        }

        public PointDetailsVm GetPointDetails(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
