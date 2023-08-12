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
        DbGrainExchangeEntities db = new DbGrainExchangeEntities();
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

        public ActionResult DeleteUser(int id)
        {
            var f = db.tblUser.Find(id);
            db.tblUser.Remove(f);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CallUser(int id)
        {
            var f = db.tblUser.Find(id);

            //Rolleri taşı

            ViewBag.Rols = new SelectList(db.tblRol.ToList(), "Id", "Name");

            return View(f);

            
        }
        public ActionResult EditUser(tblUser f)
        {
           
            if (ModelState.IsValid)
            {
                var user = db.tblUser.Find(f.Id);

                if (user != null)
                {
                    user.FirstName = f.FirstName;
                    user.LastName = f.LastName;
                    user.Username = f.Username;
                    user.Password = f.Password;
                    user.tblRolId = f.tblRolId;

                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }
            return RedirectToAction("Index");
        }
    }
}