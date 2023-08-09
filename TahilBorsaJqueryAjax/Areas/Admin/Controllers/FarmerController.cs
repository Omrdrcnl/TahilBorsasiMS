using Microsoft.AspNetCore.Mvc;

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
    }
}
