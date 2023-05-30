﻿using Microsoft.AspNetCore.Mvc;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.User;

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
            var model = _pointService.GetAllPointsForList(2, 1, "");
            return View(model);
        }

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

        [HttpGet]
        public IActionResult AddPoint() 
        {
            return View(new NewPointVm());
        }

        [HttpPost]
        public IActionResult AddPoint(NewPointVm model)
        {
            int id = _pointService.AddPoint(model);
            return RedirectToAction("Index");
        }


        [HttpGet("point/details/{pointId}")]
        public IActionResult ViewPoint(int pointId)
        {
            var pointModel = _pointService.GetPointDetails(pointId);
            return View(pointModel);
        }
    }
}