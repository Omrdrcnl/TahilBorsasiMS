using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Api.Code.Validation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EntryProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(tblEntryProduct model)
        {
            var validator = new EntryProductValidator();
            var validationResult = validator.Validate(model);

            if(!ModelState.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }


                return View(model);
            }
            return View();
        }

        public IActionResult EntryProductList()
        {
            return View();
        }
    }
}
