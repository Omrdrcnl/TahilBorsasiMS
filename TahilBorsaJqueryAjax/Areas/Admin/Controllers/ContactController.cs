using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Models;

namespace TahilBorsaJqeryAjax.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PartialView()
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.GetContact();

            List<ContactModel> contacts = new List<ContactModel>();
            bool success = result.success;
            if (success)
                contacts = result.data.ToObject<List<ContactModel>>();
            //ViewBag.Contact = result.data;


            int archiveCount = contacts.Count(c => c.Archive == true);
            int comeInCount = contacts.Count(c => c.Process == true);
            int deleteCount = contacts.Count(c => c.Deleted == true);
            int importantCount = contacts.Count(c => c.İmportant == true);
            int spamCount = contacts.Count(c => c.Spam == true);
            var model = new ContactNotification()
            {
                Archive = archiveCount,
                ComeIn = comeInCount,
                Delete = deleteCount,
                Important = importantCount,
                Spam = spamCount

            };

          

            return PartialView(model);
        }

        public IActionResult Deleted(ContactModel c)
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.GetDeleted();

            List<ContactModel> contacts = new List<ContactModel>();
            bool success = result.success;
            if (success)
                // ViewBag.Deleted = result.data;
                contacts = result.data.ToObject<List<ContactModel>>();

            return View(contacts);
        }

        public IActionResult Important()
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.GetImportant();
            List<ContactModel> contacts = new List<ContactModel>();

            bool success = result.success;
            if (success)
                ViewBag.Important = result.data;

            contacts = result.data.ToObject<List<ContactModel>>();

            return View(contacts);
        }

        public IActionResult Spam()
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.GetSpam();

            List<ContactModel> contacts = new List<ContactModel>();
            bool success = result.success;
            if (success)
                ViewBag.Spam = result.data;

            contacts = result.data.ToObject<List<ContactModel>>();

            return View(contacts);
        }

        public IActionResult Archive()
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.GetArchive();

            List<ContactModel> contacts = new List<ContactModel>();
            bool success = result.success;
            if (success)
                ViewBag.Archive = result.data;

                contacts = result.data.ToObject<List<ContactModel>>();
            return View(contacts);
        }


    }
}
