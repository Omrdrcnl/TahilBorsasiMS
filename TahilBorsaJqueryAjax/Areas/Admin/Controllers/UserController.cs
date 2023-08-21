using Microsoft.AspNetCore.Mvc;
using TahilBorsaJqeryAjax.Code.Filters;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthActionFilter(Rol ="admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
