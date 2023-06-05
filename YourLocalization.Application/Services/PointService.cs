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

        public int AddPoint(NewPointVm newPointVm)
        {
            Point newPoint = _mapper.Map<Point>(newPointVm);
            int id = _pointRepo.AddPoint(newPoint);
            return id;
        }

        public void DeletePoint(int id)
        {
            _pointRepo.DeletePoint(id);
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

        public NewPointVm GetPointForEdit(int id)
        {
            Point point = _pointRepo.GetPointById(id);
            NewPointVm pointVm = _mapper.Map<NewPointVm>(point);
            return pointVm;
        }

        public void UpdatePoint(NewPointVm updatePointVm)
        {
            Point point = _mapper.Map<Point>(updatePointVm);
            _pointRepo.UpdatePoint(point);
        }
    }
}