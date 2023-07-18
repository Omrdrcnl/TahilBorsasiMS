using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaMS.Controllers
{
    public class LabaratuarController : Controller
    {
        DbTahilEntities db = new DbTahilEntities();

        public ActionResult Index() 
        {
            var data = db.tblLabData.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddLaBData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLaBData(tblLabData l)
        {
            db.tblLabData.Add(l);
            db.SaveChanges();
            return View();
        }
    }
}