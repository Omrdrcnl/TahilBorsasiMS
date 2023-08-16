using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Api.Code.Validation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FarmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFarmer()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult AddFarmer(tblFarmer f)
        {
            var validator = new FarmerValidator();
            var validationResult = validator.Validate(f);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult CallFarmer()
        {
            return View();
        }

    }
}
