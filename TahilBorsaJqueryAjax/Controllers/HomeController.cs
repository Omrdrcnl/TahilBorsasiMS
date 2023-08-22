using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using TahilBorsaJqeryAjax.Code;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaMS.Models.Entity;
using TahilBorsaR.Models;

namespace TahilBorsaR.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact() => View();

        public IActionResult SendMessage(tblContact model)
        {
            ContactRestClient client = new ContactRestClient();
            dynamic result = client.Contact(model.Id, model.Name, model.Subject, model.Message,
                model.Mail, model.Important, model.Archive, model.Deleted, model.Spam, model.Process);

            bool success = result.success;

            if (success)
            {

                Repo.Session.Mail = model.Mail;

                Repo.Session.Name = model.Name;

                ViewBag.ContactSuccess = "Mesaj Gönderme İşlemi Başarılı";

                return RedirectToAction("Contact", "Home");
            }
            else
            {
                ViewBag.ContactError = (string)result.message;
                return View("Contact");
            }

        }


        public IActionResult How()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}