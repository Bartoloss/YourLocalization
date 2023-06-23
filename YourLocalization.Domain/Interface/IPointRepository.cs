using YourLocalization.Domain.Model;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Domain.Interface
{
    public interface IPointRepository
    {
        void DeletePoint(int pointId);

        int AddPoint(Point point);

        IQueryable<Point> GetsPointsByTypeId(int typeId);

        IQueryable<Point> GetAllPoints();

        IQueryable<Point> GetUserPoints(string username);

        Point? GetPointById(int pointId);

        IQueryable<Tag> GetAllTags();

        IQueryable<Type> GetAllTypes();

        void UpdatePoint(Point point);
    }
}