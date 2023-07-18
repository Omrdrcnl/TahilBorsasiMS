using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Controllers;
using System.Data.Entity.Validation;

namespace TahilBorsaMS.Controllers
{
    public class FarmerController : Controller
    {
        DbGrainExchangeEntities2 db = new DbGrainExchangeEntities2();
        // GET: Farmer
        public ActionResult Index()
        {
            var value = db.tblFarmer.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddFarmer()
        {
            List<SelectListItem> list = (from f in db.tblCity.ToList()
                                         select new SelectListItem
                                         {
                                             Text = f.Name,
                                             Value = f.Id.ToString(),
                                         }).ToList();
            ViewBag.Farmer = list;

            List<SelectListItem> listD = (from f in db.tblDistrict.ToList()
                                          select new SelectListItem
                                          {
                                              Text = f.Name,
                                              Value = f.Id.ToString(),

                                          }).ToList();
            ViewBag.City = listD;

            return View();
        }

        [HttpPost]
        public ActionResult AddFarmer(tblFarmer farmer)
        {
            if (ModelState.IsValid)
            {
              
                //Adres nesnesi olusturup bilgileri adres tablosuna gönderiyoruz
                tblAddress address = new tblAddress
                {
                    CityId= farmer.tblAddress.tblDistrict.tblCity.Id,
                    NeighborhoodName = farmer.tblAddress.NeighborhoodName,
                    DistrictId = farmer.tblAddress.tblDistrict.Id,
                    FullAddress = farmer.tblAddress.FullAddress
                };

                farmer.tblAddress = address;

                
                db.tblFarmer.Add(farmer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

           
            ViewBag.CityList = new SelectList(db.tblCity.ToList(), "Id", "Name");
            ViewBag.DistrictList = new SelectList(db.tblDistrict.ToList(), "Id", "Name");

            return View(farmer);
        }





        public ActionResult DeleteFarmer(int id)
        {
            var f = db.tblFarmer.Find(id);
            db.tblFarmer.Remove(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallFarmer(int id)
        {
            var f = db.tblFarmer.Find(id);


            return View(f);
        }
        public ActionResult EditFarmer(tblFarmer f)
        {
            var farmer = db.tblFarmer.Find(f.Id);
            farmer.FirstName = f.FirstName;
            farmer.LastName = f.LastName;
            farmer.BirthDate = f.BirthDate;
            farmer.Contact = f.Contact;

            farmer.AddressID = f.AddressID;
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw;
            }


        }
    }
}