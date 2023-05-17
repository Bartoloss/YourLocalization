using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application.ViewModels.Point
{
    public class ListPointForListVm
    {
        public List<PointForListVm> Points { get; set; }
        public int Count { get; set; }
    }
}
