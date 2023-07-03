using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourLocalization.Application.Interfaces;
using YourLocalization.Web.Models;

namespace YourLocalization.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SelectRegister()
        {
            //YourLocalization.Web.Models.Content RegisterObject;
            //List <YourLocalization.Web.Models.Content> Register = new List<Content>();

            //RegisterObject = new Content();
            //RegisterObject.Title = "User Register";
            //RegisterObject.Text = "Do you want to report the location of a shop, hairdresser or other place that you think is missing in your area?";
            //RegisterObject.Img = "https://www.pngkit.com/png/detail/115-1150342_user-avatar-icon-iconos-de-mujeres-a-color.png";
            //Register.Add(RegisterObject);

            //RegisterObject = new Content();
            //YourLocalization.Web.Models.Content CustomerRegister = new Content();
            //RegisterObject.Title = "Customer Register";
            //RegisterObject.Text = "Or would you like to see where the community needs your business?";
            //RegisterObject.Img = "https://static.vecteezy.com/system/resources/previews/000/439/863/original/vector-users-icon.jpg";
            //Register.Add(RegisterObject);

            return View();
        }

        public IActionResult Logout()
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