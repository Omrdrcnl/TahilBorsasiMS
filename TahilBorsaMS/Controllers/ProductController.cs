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
        DbGrainExchangeEntities db = new DbGrainExchangeEntities(); //Entity framework kullanarak değişkene atama yapma
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
            return View();
        }
    }
}