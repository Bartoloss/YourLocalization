using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Drawing;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.Type;
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
            Domain.Model.Point newPoint = _mapper.Map<Domain.Model.Point>(newPointVm);
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
            foreach (var item in points)
            {
                var pointType = _pointRepo.GetTypeForPoint(item.TypeId);
                item.TypeDetails = _mapper.Map<TypeDetailsVM>(pointType);
            }
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

        public ListPointForListVm GetUserPointsForList(string name, int pageSize, int pageNo, string searchString)
        {
            List<PointForListVm> points = _pointRepo.GetUserPoints(name).Where(p => p.Name.StartsWith(searchString))
               .ProjectTo<PointForListVm>(_mapper.ConfigurationProvider).ToList();
            foreach (var item in points)
            {
                var pointType = _pointRepo.GetTypeForPoint(item.TypeId);
                item.TypeDetails = _mapper.Map<TypeDetailsVM>(pointType);
            }
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
            Domain.Model.Point? point = _pointRepo.GetPointById(pointId);
            PointDetailsVm pointVm = _mapper.Map<PointDetailsVm>(point);
            var pointType = _pointRepo.GetTypeForPoint(point.TypeId);
            pointVm.TypeDetails = _mapper.Map<TypeDetailsVM>(pointType);
            return pointVm;
        }

        public NewPointVm GetPointForEdit(int id)
        {
            Domain.Model.Point point = _pointRepo.GetPointById(id);
            NewPointVm pointVm = _mapper.Map<NewPointVm>(point);
            return pointVm;
        }

        public void UpdatePoint(NewPointVm updatePointVm)
        {
            Domain.Model.Point point = _mapper.Map<Domain.Model.Point>(updatePointVm);
            _pointRepo.UpdatePoint(point);
        }
    }
}