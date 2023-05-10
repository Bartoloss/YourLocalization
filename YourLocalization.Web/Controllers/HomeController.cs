using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourLocalization.Application.Interfaces;
using YourLocalization.Web.Models;

namespace YourLocalization.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPointService _pointService;

        public HomeController(ILogger<HomeController> logger, IPointService pointService)
        {
            _logger = logger;
            _pointService = pointService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}