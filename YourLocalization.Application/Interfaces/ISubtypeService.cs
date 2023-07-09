using YourLocalization.Application.ViewModels.Subtype;
using YourLocalization.Application.ViewModels.Type;
using Subtype = YourLocalization.Domain.Model.Subtype;

namespace YourLocalization.Application.Interfaces
{
    public interface ISubtypeService
    {
        ListSubtypeForListVm GetAllSubtypeForList(int pageSize, int pageNo, string searchString);

        public List<Subtype> GetAllTypesToDropDownList();

        int AddSubtype(NewSubtypeVm subtype);
        
        NewSubtypeVm GetSubtypeForEdit(int id);

        void UpdateSubtype(NewSubtypeVm model);

        void DeleteSubtype(int id);
    }
}