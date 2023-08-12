using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Classes;
using TahilBorsa.Api.Code.Validation;

namespace TahilBorsaMS.Controllers
{
    [Authorize(Roles = "lab,admin")]
    public class LabaratuarController : Controller
    {
        DbGrainExchangeEntities db = new DbGrainExchangeEntities();

        public ActionResult Index()
        {
            IQueryable<tblEntryProduct> data = db.tblEntryProduct.Where(x => x.Process == false);

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
            var validator = new LabValidator();
            var validationResult = validator.Validate(l);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(l);
            }

            db.tblLabData.Add(l);
            var pro = db.tblEntryProduct.Find(l.tblEntryProductId);
            pro.Process = true;
            

            if (pro != null)
            {
                pro.Process = true;

                tblSale data = new tblSale()
                {
                    tblEntryProductId = (int)l.tblEntryProductId,
                    tblLabDataId = l.Id,
                    Process=false
                    
                    
                };

                db.tblSale.Add(data);
                db.SaveChanges();
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult LabDataList(string e)
        {
            IQueryable<tblLabData> k = db.tblLabData.Where(x => x.Process == true);

            if (!string.IsNullOrEmpty(e))
            {
                k = k.Where(x => x.tblEntryProduct.tblFarmer.IdentityNo.Contains(e));
            }

            return View(k.ToList());
        }

    }
}