using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLocalization.Domain.Model
{
    public class Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }

        public virtual Type Type { get; set; }
        public ICollection<PointTag> PointTags { get; set; }
    }
}
