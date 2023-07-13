using Microsoft.AspNetCore.Mvc;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Address;

namespace YourLocalization.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        public AddressController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userId = _userService.GetUserId();
            var model = _addressService.GetUserAdressesForView(userId);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAddress ()
        {
            var newAddressVm = new NewAddressVm();
            newAddressVm.UserId = _userService.GetUserId();
            return View(newAddressVm);
        }

        [HttpPost]
        public IActionResult AddAddress (NewAddressVm model)
        {
            int id = _addressService.AddAddress(model);
            return RedirectToAction("Index");
        }
    }
}
