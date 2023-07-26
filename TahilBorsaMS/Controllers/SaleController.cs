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
            var lab = db.tblSale.ToList ();
            //var lab = db.tblLabData.Where(x=> x.Process==true).ToList();

            return View(lab);
        }

        public ActionResult EnterSale()
        {
            return View();
        }
        public ActionResult CallSale(int id)
        {
            var k = db.tblSale.Find (id);
            return View(k);

        }

    }
}