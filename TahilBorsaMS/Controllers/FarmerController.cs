using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Controllers;

namespace TahilBorsaMS.Controllers
{
    public class FarmerController : Controller
    {
        DbGrainExchangeEntities db = new DbGrainExchangeEntities();
        // GET: Farmer
        public ActionResult Farmer()
        {
            var value = db.tblFarmer.ToList();
            return View(value);
        }
    }
}