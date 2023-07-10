using Subtype = YourLocalization.Domain.Model.Subtype;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Domain.Interface
{
    public interface ISubtypeRepository
    {
        void DeleteSubtype(int typeId);

        int AddSubtype(Subtype type);

        IQueryable<Subtype> GetAllSubtypes();

        Type? GetTypeForSubtype(int subtypeId);
        
        Subtype? GetSubtypeById(int typeId);

        void UpdateSubtype(Subtype type);
    }
}