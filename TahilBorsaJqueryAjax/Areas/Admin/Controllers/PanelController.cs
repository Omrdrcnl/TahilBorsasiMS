using Microsoft.AspNetCore.Mvc;
using static TahilBorsaMS.Models.Classes.Enums;
using TahilBorsaJqeryAjax.Code.Filters;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthActionFilter]

    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
