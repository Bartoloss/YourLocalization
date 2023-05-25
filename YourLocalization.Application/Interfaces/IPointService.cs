using YourLocalization.Application.ViewModels.Point;

namespace YourLocalization.Application.Interfaces
{
    public interface IPointService
    {
        ListPointForListVm GetAllPointsForList(int pageSize, int pageNo, string searchString);

        int AddPoint(NewPointVm point);

        PointDetailsVm GetPointDetails(int pointId);
    }
}