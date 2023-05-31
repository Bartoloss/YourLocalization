using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Type;

namespace YourLocalization.Web.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }


        [HttpGet("types")]
        public IActionResult Index()
        {
            var model = _typeService.GetAllTypeForList(9, 1, "");
            return View(model);
        }

        [HttpPost("types")]
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

            var model = _typeService.GetAllTypeForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddType()
        {
            return View(new NewTypeVm());
        }

        [HttpPost]
        public IActionResult AddType(NewTypeVm model)
        {
            var id = _typeService.AddType(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditType(int id)
        {
            var type = _typeService.GetTypeForEdit(id);
            return View(type);
        }

        [HttpPost]
        public IActionResult EditType(NewTypeVm model)
        {
            _typeService.UpdateType(model);
            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteType(int id)
        {
            _typeService.DeleteType(id);
            return RedirectToAction("Index");
        }
    }
}
