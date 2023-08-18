using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using TahilBorsaJqeryAjax.Code.Validation;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Rest;

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
        public IActionResult AddFarmer(FarmerModel f)
        {
            var validator = new FarmerValidator();
            var validationResult = validator.Validate(f);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(f);
            }

            FarmerRestClient client = new FarmerRestClient();
            dynamic result = client.AddFarmer(f.FirstName, f.LastName, f.IdentityNo, f.Contact, f.BirthDate,
                f.FullAddress, f.tblCityId, f.tblDistrictId, f.NeighborhoodName);

            bool success = result.success;

            if (success)
            {
                return RedirectToAction("Index", "Farmer");
            }
            else
            {
                ViewBag.FarmerError = (string)result.message;
                return View("AddFarmer");
            }

           
        }

        public ActionResult CallFarmer()
        {
            return View();
        }

    }
}
