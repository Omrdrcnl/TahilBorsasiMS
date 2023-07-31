﻿using System;
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
        DbGrainExchangeEntities4 db = new DbGrainExchangeEntities4 ();
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

            value.tblEntryProductId = s.tblEntryProductId;
            value.BasePrice = s.BasePrice;
            value.ActualPrice = s.ActualPrice;
            value.tblTradesmanId = s.tblTradesmanId;
            value.Date = s.Date;
            value.Process = true;

            db.SaveChanges ();

            return RedirectToAction("Index");
        }

    }
}