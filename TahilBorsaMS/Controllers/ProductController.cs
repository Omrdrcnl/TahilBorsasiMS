﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsa.Api.Code.Validation;
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
            var validator = new ProductValidator();
            var validationResult = validator.Validate(p);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(p);
            }

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

            var validator = new ProductValidator();
            var validationResult = validator.Validate(p);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return RedirectToAction("CallProduct", p);
            }

            product.Id= p.Id;
            product.Name = p.Name;
            product.Information = p.Information;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}