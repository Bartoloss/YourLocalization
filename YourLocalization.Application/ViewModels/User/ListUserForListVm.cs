using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLocalization.Application.ViewModels.User
{
    public class ListUserForListVm
    {
        public List<UserForListVm> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PagePize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
