using AutoMapper;
using AutoMapper.QueryableExtensions;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;

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

        public int AddPoint(NewPointVm point)
        {
            throw new NotImplementedException();
        }

        public ListPointForListVm GetAllPointsForList(int pageSize, int pageNo, string searchString)
        {
            List<PointForListVm> points = _pointRepo.GetAllPoints().Where(p => p.Name.StartsWith(searchString))
               .ProjectTo<PointForListVm>(_mapper.ConfigurationProvider).ToList();
            List<PointForListVm> pointsToShow = points.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListPointForListVm pointsForList = new ListPointForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Points = pointsToShow,
                Count = points.Count
            };
            return pointsForList;
        }

        public PointDetailsVm GetPointDetails(int pointId)
        {
            Point? point = _pointRepo.GetPointById(pointId);
            PointDetailsVm pointVm = _mapper.Map<PointDetailsVm>(point);
            return pointVm;
        }
    }
}