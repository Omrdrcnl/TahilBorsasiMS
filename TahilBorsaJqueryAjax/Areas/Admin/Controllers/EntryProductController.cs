using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EntryProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EntryProductList()
        {
            return View();
        }
    }
}
