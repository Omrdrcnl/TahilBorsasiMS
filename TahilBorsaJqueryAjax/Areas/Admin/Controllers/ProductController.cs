using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult CallProduct()
        {
            return View();
        }
    }
}
