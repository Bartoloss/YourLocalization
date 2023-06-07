using Microsoft.AspNetCore.Identity;

namespace YourLocalization.Domain.Model
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? LogoPic { get; set; }
        public bool IsActive { get; set; }
        public int? AmountOfAddresses { get; set; }

        public virtual ICollection<AddressDetail> Addresses { get; set; }
    }
}