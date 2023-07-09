using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.ViewModels.Type;

namespace YourLocalization.Application.ViewModels.Subtype
{
    public class ListSubtypeForListVm
    {
        public List<SubtypeForListVm> Subtypes { get; set; }
        public List<YourLocalization.Domain.Model.Type> Types { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
