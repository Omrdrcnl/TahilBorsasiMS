using Microsoft.AspNetCore.Mvc;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Filters;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Code.Validation;
using static TahilBorsaMS.Models.Classes.Enums;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    [AuthActionFilter(Rol = "admin,person")]

    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SaleModel s)
        {
            var validator = new SaleValidator();
            var validationResult = validator.Validate(s);


            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    TempData["ErrorMessagesSale"] = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                }


                return View(s);
            }
            SaleRestClient client = new SaleRestClient();

            dynamic result = client.EnterSale(s.LabId, s.TradesmanId, s.EntryId, s.SaleId, 
                s.Date, s.ActualPrice, s.BasePrice, s.Quantity);

            bool success = result.success;

            if (success)
            {
                ViewBag.SuccessSale = "İşlem Başarıyla Gerçekleşti";
                return View();
            }
            else
            {
                ViewBag.ErrorSale = (string)result.message;
                return View();
            }

        }

        public IActionResult Saled()
        {
            return View();
        }
    }
}
