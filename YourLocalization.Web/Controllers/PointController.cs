using Microsoft.AspNetCore.Mvc;
using YourLocalization.Application.Interfaces;

namespace YourLocalization.Web.Controllers
{
    public class PointController : Controller
    {
        private readonly IPointService _pointService;
        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        public IActionResult Index()
        {
            var model = _pointService.GetAllPointsForList();
            return View(model);
        }
        
    }
}
