using YourLocalization.Application.ViewModels.Type;

namespace YourLocalization.Application.ViewModels.Point
{
    public class ListPointForListVm
    {
        public List<PointForListVm> Points { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }

    }
}