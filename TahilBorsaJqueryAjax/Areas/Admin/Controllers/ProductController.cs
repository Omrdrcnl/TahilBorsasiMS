using Microsoft.AspNetCore.Mvc;
using static TahilBorsaMS.Models.Classes.Enums;
using TahilBorsaJqeryAjax.Code.Filters;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]

    [AuthActionFilter(Rol = "admin,person")]

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
