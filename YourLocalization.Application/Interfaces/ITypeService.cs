using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.Type;

namespace YourLocalization.Application.Interfaces
{
    public interface ITypeService
    {
        ListTypeForListVm GetAllTypeForList(int pageSize, int pageNo, string searchString);

        int AddType(NewTypeVm point);

        NewTypeVm GetTypeForEdit(int id);

        void UpdateType(NewTypeVm model);

        void DeleteType(int id);
    }
}
