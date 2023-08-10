using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;


namespace TahilBorsaMS.Controllers
{

    [Table("tblUser")]
    public class UserController : Controller
    {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();
        // GET: User
        public ActionResult Index()
        {
            var list = db.tblUser.ToList();

            return View(list);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            List<SelectListItem> list = (from f in db.tblRol.ToList()
                                         select new SelectListItem
                                         {
                                             Text = f.Name,
                                             Value = f.Id.ToString(),
                                         }).ToList();
            ViewBag.Rol = list;

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(tblUser t)
        {
            db.tblUser.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallUser()
        {
            var list = db.tblUser.ToList();

            return View(list);
        }
        public ActionResult DeleteUser()
        {
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
        }
    }
}