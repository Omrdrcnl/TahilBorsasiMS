using Microsoft.AspNetCore.Mvc;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Code.Validation;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TradesmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Index(TradesmanModel f)
        {
            var validator = new TradesmanValidator();
            var validationResult = validator.Validate(f);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    TempData["ErrorMessages"] = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                return View();
            }

            TradesmanRestClient client = new TradesmanRestClient();
            dynamic result = client.AddTradesman(f.Id,f.FirstName, f.LastName, f.IdentityNo, f.Contact, f.BirthDate, f.AddressId,
                f.FullAddress , f.tblCityId, f.tblDistrictId, f.NeighborhoodName);

            bool success = result.success;

            if (success)
            {
                ViewBag.SuccessTradesman = "İşlem Başarıyla Gerçekleşti";
                return View();
            }
            else
            {
                ViewBag.TradesmanError = (string)result.message;
                return View();
            }

           
        }
        public IActionResult CallTradesman()
        {
            return View();
        }
    }
}
