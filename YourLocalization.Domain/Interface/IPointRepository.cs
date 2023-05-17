using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        Point? GetItemById(int pointId);

        IQueryable<Tag> GetAllTags();

        IQueryable<Type> GetAllTypes();
        
    }
}
