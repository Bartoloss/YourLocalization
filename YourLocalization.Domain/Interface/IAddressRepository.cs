using YourLocalization.Domain.Model;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Domain.Interface
{
    public interface IAddressRepository
    {
        void DeleteAddress(int addressId);

        int AddAddress(Address address);

        IQueryable<Address> GetUserAddress(string userId);

        Address? GetAddressById(int addressId);

        void UpdateAddress(Address address);

    }
}