using Subtype = YourLocalization.Domain.Model.Subtype;

namespace YourLocalization.Domain.Interface
{
    public interface ISubtypeRepository
    {
        void DeleteSubtype(int typeId);

        int AddSubtype(Subtype type);

        IQueryable<Subtype> GetAllSubtypes();

        Subtype? GetSubtypeById(int typeId);

        void UpdateSubtype(Subtype type);
    }
}