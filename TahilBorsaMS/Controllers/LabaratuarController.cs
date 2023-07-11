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
        DbGrainExchangeEntities db = new DbGrainExchangeEntities();
        // GET: Labaratuar
        public ActionResult Index()
        {
            var lab = db.tblLabData.ToList();
            return View(lab);
        }
    }
}