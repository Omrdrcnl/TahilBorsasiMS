using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Controllers;
using System.Web.Security;
using System.Web.ModelBinding;
using TahilBorsa.Api.Code.Validation;

namespace TahilBorsaMS.Controllers
{
    public class LoginController : Controller
    {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(tblUser u)
        {
            var validator = new UserValidator();
            var validationResult = validator.Validate(u);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(u);
            }

            var k = db.tblUser.FirstOrDefault(x => x.Username == u.Username && x.Password == u.Password);

            if (k != null)
            {
                FormsAuthentication.SetAuthCookie(k.Username, false);
                Session["Username"] = k.Username.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }

        }
    }
}