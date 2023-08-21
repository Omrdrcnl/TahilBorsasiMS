using Microsoft.AspNetCore.Mvc;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Code;
using TahilBorsaJqeryAjax.Models;

namespace TahilBorsaJqeryAjax.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult GirisYap(LoginModel model)
        {

            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.UserName, model.Password);

            bool success = result.success;

            if (success)
            {
                Repo.Session.UserName = model.UserName;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string)result.rol;

                return RedirectToAction("Panel", "Admin");
            }
            else
            {

                ViewBag.LoginError = (string)result.message;
                return View("Login");
            }
        }
        public IActionResult Logout()
        {
            // Kullanıcı oturumunu sonlandır
            HttpContext.Session.Clear();

            // Çıkış işlemi tamamlandığında ana sayfaya yönlendir
            return RedirectToAction("Index", "Home");
        }
    }
}
