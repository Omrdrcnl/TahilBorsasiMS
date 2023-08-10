using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TradesmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddTradesman()
        {
            return View();
        }
        public IActionResult CallTradesman()
        {
            return View();
        }
    }
}
