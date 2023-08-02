using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Controllers;
using System.Web.Security;

namespace TahilBorsaMS.Controllers
{
    public class LoginController : Controller
    {
        DbGrainExchangeEntities4 db = new DbGrainExchangeEntities4();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(tblUser u)
        {
            var k = db.tblUser.FirstOrDefault(x => x.Username == u.Username && x.Password == u.Password);

            if (k != null)
            {
                FormsAuthentication.SetAuthCookie(k.Username, false);
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }

        }
    }
}