using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.Subtype;
using YourLocalization.Application.ViewModels.Type;
using YourLocalization.Domain.Model;

namespace YourLocalization.Web.Controllers
{
    public class SubtypeController : Controller
    {
        private readonly ISubtypeService _subtypeService;
        private readonly ITypeService _typeService;

        public SubtypeController(ISubtypeService subtypeService, ITypeService typeService)
        {
            _subtypeService = subtypeService;
            _typeService = typeService;
        }

        [HttpGet("subtypes")]
        public IActionResult Index()
        {
            var model = _subtypeService.GetAllSubtypeForList(9, 1, "");
            return View(model);
        }

        [HttpPost("subtypes")]
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

            var model = _subtypeService.GetAllSubtypeForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddSubtype()
        {
            var newSubtypeVm = new NewSubtypeVm();
            newSubtypeVm.Types = _typeService.GetAllTypesToDropDownList();
            return View(newSubtypeVm);
        }

        [HttpPost]
        public IActionResult AddSubtype(NewSubtypeVm model)
        {
            var id = _subtypeService.AddSubtype(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSubtype(int id)
        {
            NewSubtypeVm editSubtypeVm = _subtypeService.GetSubtypeForEdit(id);
            editSubtypeVm.Types = _typeService.GetAllTypesToDropDownList();
            return View(editSubtypeVm);
        }

        [HttpPost]
        public IActionResult EditSubtype(NewSubtypeVm model)
        {
            _subtypeService.UpdateSubtype(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSubtype(int id)
        {
            _subtypeService.DeleteSubtype(id);
            return RedirectToAction("Index");
        }
    }
}