using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLocalization.Domain.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? LogoPic { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AddressDetail> Adresses { get; set; }
    }
}
