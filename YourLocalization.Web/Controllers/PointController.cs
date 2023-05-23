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

        [HttpGet("points")]
        public IActionResult Index()
        {
            var model = _pointService.GetAllPointsForList();
            return View(model);
        }

        [HttpGet("points/{pointId}")]
        public IActionResult ViewPoint(int pointId)
        {
            var pointModel = _pointService.GetPointDetails(pointId);
            return View(pointModel);
        }
    }
}
