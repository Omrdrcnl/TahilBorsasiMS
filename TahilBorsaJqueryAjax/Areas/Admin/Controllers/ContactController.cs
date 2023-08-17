using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialView()
        {
            return PartialView();
        }

    }
}
