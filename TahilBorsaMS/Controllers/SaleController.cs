using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaMS.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        DbGrainExchangeEntities3 db = new DbGrainExchangeEntities3 ();
        public ActionResult Index()
        {
            var lab = db.tblSale.Where(x=> x.Process==false).ToList();
            //var lab = db.tblLabData.Where(x=> x.Process==true).ToList();

            return View(lab);
        }
        public ActionResult Saled()
        {
            var lab = db.tblSale.Where(x => x.Process == true).ToList();

            return View(lab);
        }

       
        public ActionResult CallSale(int id)
        {
            var k = db.tblSale.Find (id);
            return View(k);

        }
        public ActionResult EnterSale(tblSale s)
        {
            var value = db.tblSale.Find (s.Id);

            value.EntryProductId = s.EntryProductId;
            value.BasePrice = s.BasePrice;
            value.ActualPrice = s.ActualPrice;
            value.TradesmanId = s.TradesmanId;
            value.Date = s.Date;
            value.Process = true;

            db.SaveChanges ();

            return RedirectToAction("Index");
        }

    }
}