using Microsoft.AspNetCore.Mvc;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;

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

        public IActionResult ViewPoint(int pointId)
        {
            var pointModel = _pointService.GetPointDetails(pointId);
            return View(pointModel);
        }
    }
}
