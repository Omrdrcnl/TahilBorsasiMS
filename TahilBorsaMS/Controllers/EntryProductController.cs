using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using PagedList.Mvc;
namespace TahilBorsaMS.Controllers
{
    public class EntryProductController : Controller
    {
        DbGrainExchangeEntities3 db = new DbGrainExchangeEntities3();
        // GET: EntryProduct
        public ActionResult Index()
        {
            ViewBag.ProductList = new SelectList(db.tblProductName.ToList(),"Id","Name");
            //List<SelectListItem> list = (from k in db.tblProductName.ToList() select new SelectListItem
            //{
            //    Text = k.Name,
            //    Value = k.Id.ToString(),
            //}).ToList();
            //ViewBag.ProducList = list;
            return View();
        }
        public ActionResult AddEntryProduct(tblEntryProduct p)
        {
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