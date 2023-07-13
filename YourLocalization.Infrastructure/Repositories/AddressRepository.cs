using System.Drawing;
using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Infrastructure.Repositoriees
{
    public class AddressRepository : IAddressRepository
    {
        private readonly Context _context;

        public AddressRepository(Context context)
        {
            _context = context;
        }

        public int AddAddress(Address address)
        {
            _context.Add(address);
            _context.SaveChanges();
            return address.Id;
        }

        public void DeleteAddress(int addressId)
        {
            Address? address = _context.AddressDetails.Find(addressId);
            if (address != null)
            {
                _context.AddressDetails.Remove(address);
                _context.SaveChanges();
            }
        }

        public Address? GetAddressById(int addressId)
        {
            return _context.AddressDetails.FirstOrDefault(i => i.Id == addressId);
        }

        public IQueryable<Address> GetUserAddress(string userId)
        {
            return _context.AddressDetails.Where(i => i.UserId == userId);
        }

        public void UpdateAddress(Address address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("Name").IsModified = true;
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("BuildingNumber").IsModified = true;
            _context.Entry(address).Property("FlatNumber").IsModified = true;
            _context.Entry(address).Property("ZipCode").IsModified = true;
            _context.Entry(address).Property("City").IsModified = true;
            _context.Entry(address).Property("Country").IsModified = true;
            _context.SaveChanges();
        }
    }
}