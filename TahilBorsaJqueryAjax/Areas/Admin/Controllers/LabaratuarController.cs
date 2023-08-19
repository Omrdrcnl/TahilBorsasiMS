using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Code.Validation;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LabaratuarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LabaratuarModel l)
        {
            var validator = new LabValidator();
            var validationResult = validator.Validate(l);

            if (l.NutritionalValue > 100)
            {
                ViewBag.NatError = "Besin Değeri 100'den Büyük olamaz.";
                return View();
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    TempData["ErrorMessagesLab"] = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                }


                return View(l);
            }
            LabResClient client = new LabResClient();

            dynamic result = client.AddLab(l.EntryProductId, l.NutritionalValue);

            bool success = result.success;

            if (success)
            {
                ViewBag.SuccessLab = "İşlem Başarıyla Gerçekleşti";
                return View();
            }
            else
            {
                ViewBag.ErrorLab = (string)result.message;
                return View();
            }
        }

        public IActionResult EntryProductList()
        {
            return View();
        }

        public IActionResult AddLabData()
        {
            return View();
        }
        public IActionResult LabDataList()
        {
            return View();
        }
    }


}

