using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application.Interfaces
{
    public interface IPointService
    {
        ListPointForListVm GetAllPointsForList(int pageSize, int pageNo, string searchString);
        int AddPoint(NewPointVm point);
        PointDetailsVm GetPointDetails(int pointId);
    }
}
