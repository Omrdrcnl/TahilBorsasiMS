using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity; //databasi dahil ediyoruz

namespace TahilBorsaMS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5(); //Entity framework kullanarak değişkene atama yapma
        public ActionResult Index()
        {
            var values = db.tblProduct.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AddProduct(tblProduct p)
        {
            db.tblProduct.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var p = db.tblProduct.Find(id);
            db.tblProduct.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallProduct(int id)
        {
            var p = db.tblProduct.Find(id);
            return View(p);
        }
        public ActionResult EditProduct(tblProduct p)
        {
            var product = db.tblProduct.Find(p.Id);
            product.Id= p.Id;
            product.Name = p.Name;
            product.Information = p.Information;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}