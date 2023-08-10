using Microsoft.AspNetCore.Mvc;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LabaratuarController : Controller
    {
        public IActionResult Index()
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
