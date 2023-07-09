using YourLocalization.Application.ViewModels.Point;

namespace YourLocalization.Application.Interfaces
{
    public interface IPointService
    {
        ListPointForListVm GetAllPointsForList(int pageSize, int pageNo, string searchString);

        ListPointForListVm GetUserPointsForList(string username, int pageSize, int pageNo, string searchString);

        int AddPoint(NewPointVm point);

        PointDetailsVm GetPointDetails(int pointId);

        NewPointVm GetPointForEdit(int id);

        void UpdatePoint(NewPointVm model);

        void DeletePoint(int id);
    }
}