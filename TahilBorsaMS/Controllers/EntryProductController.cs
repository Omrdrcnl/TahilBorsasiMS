using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using PagedList.Mvc;
using TahilBorsa.Api.Code.Validation;

namespace TahilBorsaMS.Controllers
{
    public class EntryProductController : Controller
    {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();
        // GET: EntryProduct
        public ActionResult Index(tblEntryProduct p)
        {
            ViewBag.ProductList = new SelectList(db.tblProduct.ToList(),"Id","Name");
            //Burada tempdatayı indexe gönderiyoruz
            if (TempData.ContainsKey("ValidationErrors"))
            {
                ModelState.Merge((ModelStateDictionary)TempData["ValidationErrors"]);
            }

            return View(p);
        }
        public ActionResult AddEntryProduct(tblEntryProduct p)
        {
            var validator = new EntryProductValidator();
            var validationResult = validator.Validate(p);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                //farklı bir sayfada çalıştıgımız için hata mesajını tempdataya taşıyor bunuda indexte karsılayacagız.
                TempData["ValidationErrors"] = ModelState;

                return RedirectToAction("Index",p);
            }

            db.tblEntryProduct.Add(p);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EntryProductList(string e)
        {
            IQueryable<tblEntryProduct> k = db.tblEntryProduct.Where(x => x.Process == false);

            if (!string.IsNullOrEmpty(e))
            {
                k = k.Where(x => x.tblFarmer.IdentityNo.Contains(e));
            }

            return View(k.ToList());
        }

    }
}