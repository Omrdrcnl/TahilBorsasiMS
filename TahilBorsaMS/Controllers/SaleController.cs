using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsa.Api.Code.Validation;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaMS.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5 ();
        public ActionResult Index()
        {
            var lab = db.tblSale.Where(x=> x.Process==false).ToList();
            //var lab = db.tblLabData.Where(x=> x.Process==true).ToList();

            return View(lab);
        }
        public ActionResult Saled(string e)
        {
            IQueryable<tblSale> lab = db.tblSale.Where(x => x.Process == true);


            if (!string.IsNullOrEmpty(e))
            {
                lab = lab.Where(x => x.tblLabData.tblEntryProduct.tblFarmer.IdentityNo.Contains(e));
            }

            return View(lab.ToList());
        }

       
        public ActionResult CallSale(int id)
        {
            var k = db.tblSale.Find (id);
            return View(k);

        }
        public ActionResult UpdateSale(tblSale s)
        {
            var validator = new SaleValidator();
            var validationResult = validator.Validate(s);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View("CallSale",s);
            }

            var value = db.tblSale.Find (s.Id);

            value.tblEntryProductId = s.tblEntryProductId;
            value.BasePrice = s.BasePrice;
            value.ActualPrice = s.ActualPrice;
            value.Quantity = s.Quantity;
            value.Amount = s.ActualPrice * s.Quantity;
            value.tblTradesmanId = s.tblTradesmanId;
            value.Date = s.Date;
            value.Process = true;

            db.SaveChanges ();

            return RedirectToAction("Index");
        }

    }
}