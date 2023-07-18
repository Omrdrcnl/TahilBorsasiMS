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
        DbTahilEntities db = new DbTahilEntities(); //Entity framework kullanarak değişkene atama yapma
        public ActionResult Index()
        {
            var values = db.tblProductName.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AddProduct(tblProductName p)
        {
            db.tblProductName.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var p = db.tblProductName.Find(id);
            db.tblProductName.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallProduct(int id)
        {
            var p = db.tblProductName.Find(id);
            return View(p);
        }
        public ActionResult EditProduct(tblProductName p)
        {
            var product = db.tblProductName.Find(p.Id);
            product.Id= p.Id;
            product.Name = p.Name;
            product.Information = p.Information;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}