using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLocalization.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Point> Points { get; set; }
    }
}
