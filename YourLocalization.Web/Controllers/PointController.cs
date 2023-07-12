using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Point;

namespace YourLocalization.Web.Controllers
{
    public class PointController : Controller
    {
        private readonly IPointService _pointService;
        private readonly ITypeService _typeService;
        private readonly ISubtypeService _subtypeService;

        public PointController(IPointService pointService, ITypeService typeService, ISubtypeService subtypeService)
        {
            _pointService = pointService;
            _typeService = typeService;
            _subtypeService = subtypeService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("points")]
        public IActionResult Index()
        {
            var model = _pointService.GetAllPointsForList(10, 1, "");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("points")]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _pointService.GetAllPointsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("userpoints")]
        public IActionResult ViewUserPoints()
        {
            string name = HttpContext.User.Identity.Name; 
            var model = _pointService.GetUserPointsForList(name, 10, 1, "");
            return View(model);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost("userpoints")]
        public IActionResult ViewUserPoints(string name, int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _pointService.GetUserPointsForList(name, pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult AddPoint()
        {
            var newPointVm = new NewPointVm();
            newPointVm.Types = _typeService.GetAllTypesToDropDownList();
            newPointVm.Subtypes = _subtypeService.GetAllSubtypesToDropDownList();
            return View(newPointVm);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public IActionResult AddPoint(NewPointVm model)
        {
            int id = _pointService.AddPoint(model);
            return RedirectToAction("ViewUserPoints");
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("point/details/{pointId}")]
        public IActionResult ViewPoint(int pointId)
        {
            var pointModel = _pointService.GetPointDetails(pointId);
            return View(pointModel);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult EditPoint(int id)
        {
            NewPointVm point = _pointService.GetPointForEdit(id);
            point.Types = _typeService.GetAllTypesToDropDownList();
            return View(point);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public IActionResult EditPoint(NewPointVm model)
        {
            _pointService.UpdatePoint(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User, Admin")]
        public IActionResult DeletePoint(int id)
        {
            _pointService.DeletePoint(id);
            return RedirectToAction("Index");
        }
    }
}