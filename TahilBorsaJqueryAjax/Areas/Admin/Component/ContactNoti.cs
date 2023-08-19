using Microsoft.AspNetCore.Mvc;
using TahilBorsaJqeryAjax.Areas.Admin.Model;
using TahilBorsaJqeryAjax.Code.Rest;
using TahilBorsaJqeryAjax.Models;

namespace TahilBorsaJqeryAjax.Areas.Admin.Component
{
    public class ContactNoti: ViewComponent
    {
        public IViewComponentResult Invoke()
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

            return View(model);
        }
    }
}
