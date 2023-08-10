using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CallSale()
        {
            return View();
        }
        public IActionResult Saled()
        {
            return View();
        }
    }
}
