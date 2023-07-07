using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Domain.Model;

namespace YourLocalization.Web.Controllers
{
    public class PointController : Controller
    {
        private readonly IPointService _pointService;
        private readonly ITypeService _typeService;

        public PointController(IPointService pointService, ITypeService typeService)
        {
            _pointService = pointService;
            _typeService = typeService;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("points")]
        public IActionResult Index()
        {
            var model = _pointService.GetAllPointsForList(2, 1, "");
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

        //[Authorize(Roles = "User, Admin")]
        //[HttpGet("points")]
        //public IActionResult ViewUserPoints()
        //{
        //    string username = HttpContext.User.FindFirstValue("username"); //poprawić
        //    var model = _pointService.GetUserPointsForList(username,2, 1, "");
        //    return View(model);
        //}

        //[Authorize(Roles = "User, Admin")]
        //[HttpPost("points")]
        //public IActionResult ViewUserPoints(string username, int pageSize, int? pageNo, string searchString)
        //{
        //    if (!pageNo.HasValue)
        //    {
        //        pageNo = 1;
        //    }
        //    if (searchString is null)
        //    {
        //        searchString = String.Empty;
        //    }

        //    var model = _pointService.GetUserPointsForList(username, pageSize, pageNo.Value, searchString);
        //    return View(model);
        //}


        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult AddPoint()
        {
            var newPointVm = new NewPointVm();
            newPointVm.Types = _typeService.GetAllTypesToDropDownList();
            return View(newPointVm);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public IActionResult AddPoint(NewPointVm model)
        {
            int id = _pointService.AddPoint(model);
            return RedirectToAction("Index");
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