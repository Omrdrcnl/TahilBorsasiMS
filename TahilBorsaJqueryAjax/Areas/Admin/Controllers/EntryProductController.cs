using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Filters;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Code.Validation;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthActionFilter(Rol = "admin,person")]

    public class EntryProductController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EntryProductModel model)
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


            EntryProductRestClient client = new EntryProductRestClient();

            dynamic result = client.AddEntryProduct(model.FarmerId, 
                model.DateTime, model.ProductId);

            bool success = result.success;

            if (success)
            {
                ViewBag.SuccessEntry = "İşlem Başarıyla Gerçekleşti";
                return View();
            }
            else
            {
                ViewBag.EntryProductError = (string)result.message;
                return View();
            }
        }

        public IActionResult EntryProductList()
        {
            return View();
        }
    }
}
