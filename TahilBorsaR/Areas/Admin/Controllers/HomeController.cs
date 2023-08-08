using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Farmers()
        {
            return View();
        }

        public IActionResult Tumsehirler()
        {
            return View();
        }
    }
}
