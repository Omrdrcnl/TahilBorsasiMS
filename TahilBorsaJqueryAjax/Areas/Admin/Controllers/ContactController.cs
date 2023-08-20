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

        public IActionResult Process(ContactModel model)
        {
            ContactRestClient client = new ContactRestClient();
            dynamic result = client.Contact(model.Id, model.Name, model.Subject, model.Message,
                model.Mail, model.Important, model.Archive, model.Deleted, model.Spam, model.Process);

            bool success = result.success;

            if (success)
            {

                return RedirectToAction("Index", "Contact");
            }
            else
            {
                ViewBag.ContactError = (string)result.message;
                return View("Contact");
            }

        }


        public IActionResult Deleted(ContactModel c)
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.GetDeleted();

            List<ContactModel> contacts = new List<ContactModel>();
            bool success = result.success;
            if (success)
                
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
           

                contacts = result.data.ToObject<List<ContactModel>>();
            return View(contacts);
        }       
        
        public IActionResult ReadMessage(ContactModel model)
        {

            ContactRestClient client = new ContactRestClient();
            dynamic result = client.ReadMessage(model.Id);

            ContactModel contact = new ContactModel();
            bool success = result.success;
            if (success)
                ViewBag.Archive = result.data;

                contact = result.data.ToObject<ContactModel>();
            return View(contact);
        }


    }
}
