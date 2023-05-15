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
        public IActionResult Index()
        {
            //utworzyć widok dla tej akcji
            //w widoku będzie tabela z userów
            //panel do filtrowania userów
            //przygotować dane
            //przekazać filtry do serwisu
            //serwis musi przygotować dane
            //serwis musi zwrócić dane do controlera w odpowiednim formacie

            var model = _userService.GetAllUsersForList();
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

        public IActionResult ViewUser(string userId)
        {
            var userModel = _userService.GetUserDetails(userId);
            return View(userModel);
        }
    }
}
