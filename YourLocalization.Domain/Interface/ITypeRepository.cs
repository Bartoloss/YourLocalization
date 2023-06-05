using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Domain.Model;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Domain.Interface
{
    public interface ITypeRepository
    {
        void DeleteType(int typeId);

        int AddType(Type type);

        IQueryable<Type> GetAllTypes();

        Type? GetTypeById(int typeId);

        void UpdateType(Type type);
    }
}
