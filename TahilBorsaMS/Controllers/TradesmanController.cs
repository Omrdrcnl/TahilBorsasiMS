using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaMS.Controllers
{
    public class TradesmanController : Controller
    {
        DbGrainExchangeEntities db = new DbGrainExchangeEntities();
        // GET: Tradesman
        public ActionResult Index()
        {
            var t = db.tblTradesman.ToList();
            return View(t);
        }
    }
}