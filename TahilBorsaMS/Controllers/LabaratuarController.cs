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
        DbGrainExchangeEntities3 db = new DbGrainExchangeEntities3();

        public ActionResult Index() 
        {
            IQueryable<tblEntryProduct> data = db.tblEntryProduct.Where(x => x.Process == true);
            
            return View(data.ToList());
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
            var pro = db.tblEntryProduct.Find(l.EntryProductId);
            if (pro != null)
            {
                pro.Process = false;
                db.SaveChanges();
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult LabDataList(string e)
        {
            IQueryable<tblLabData> k = db.tblLabData.Where(x => x.Process == false);

            if (!string.IsNullOrEmpty(e))
            {
                k = k.Where(x => x.tblEntryProduct.tblFarmer.IdentityNo.Contains(e));
            }

            return View(k.ToList());
        }

    }
}