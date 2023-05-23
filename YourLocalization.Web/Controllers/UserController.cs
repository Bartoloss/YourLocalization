using Microsoft.AspNetCore.Mvc;
using YourLocalization.Application.Interfaces;

namespace YourLocalization.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult Index()
        {
            var model = _userService.GetAllUsersForList(2, 1, "");
            return View(model);
        }

        [HttpPost("users")]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _userService.GetAllUsersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }


        [HttpGet]
        public IActionResult AddUser() //metoda ta będzie zwracać pusty formularz który użytkownik będzie musiał wypełnić
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddCustomer(UserModel model)
        //{
        //    var id = userService.AddCustomer(model);
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult AddNewAddressForClient(int userId)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddNewAddressForClient(AddressModel model)
        //{
        //    return View();
        //}

        [HttpGet("users/{userId}")]
        public IActionResult ViewUser(string userId)
        {
            var userModel = _userService.GetUserDetails(userId);
            return View(userModel);
        }
    }
}
