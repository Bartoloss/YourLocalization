using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Domain.Model;

namespace YourLocalization.Application.Interfaces
{
    public interface IPointService
    {
        ListPointForListVm GetAllPointsForList(int pageSize, int pageNo, string searchString);

        int AddPoint(NewPointVm point);

        PointDetailsVm GetPointDetails(int pointId);

        NewPointVm GetPointForEdit(int id);

        void UpdatePoint(NewPointVm model);

        void DeletePoint(int id);
    }
}