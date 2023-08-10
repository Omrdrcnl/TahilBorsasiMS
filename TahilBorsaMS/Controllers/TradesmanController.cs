using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaMS.Controllers
{
    public class TradesmanController : Controller
    {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();
        // GET: Tradesman
        public ActionResult Index(string f, int page = 1)
        {
            var value = db.tblTradesman.ToList().ToPagedList(page, 3);
            //indexten gelen string f degeriyle harf duyarlılığını kaldırarak arama işlemi yapma
            if (!string.IsNullOrEmpty(f))
            {
                f = f.ToLower();
                value = value.Where(p => p.FirstName.ToLower().Contains(f) || p.LastName.ToLower().Contains(f)).ToList().ToPagedList(page, 3);
            }

            return View(value);
        }
        [HttpGet]
        public ActionResult AddTradesman()
        {
            List<SelectListItem> list = (from f in db.tblCity.ToList()
                                         select new SelectListItem
                                         {
                                             Text = f.Name,
                                             Value = f.Id.ToString(),
                                         }).ToList();
            ViewBag.CityList = list;

            List<SelectListItem> listD = (from f in db.tblDistrict.ToList()
                                          select new SelectListItem
                                          {
                                              Text = f.Name,
                                              Value = f.Id.ToString(),

                                          }).ToList();
            ViewBag.District = listD;

            return View();
        }

        [HttpPost]
        public ActionResult AddTradesman(tblTradesman tradesman)
        {
            if (ModelState.IsValid)
            {

                //Adres nesnesi olusturup bilgileri adres tablosuna gönderiyoruz
                tblAddress address = new tblAddress
                {
                    tblCityId = tradesman.tblAddress.tblDistrict.tblCity.Id,
                    NeighborhoodName = tradesman.tblAddress.NeighborhoodName,
                    tblDistrictId = tradesman.tblAddress.tblDistrict.Id,
                    FullAddress = tradesman.tblAddress.FullAddress
                };

                tradesman.tblAddress = address;


                db.tblTradesman.Add(tradesman);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(tradesman);
        }





        public ActionResult DeleteTradesman(int id)
        {
            var f = db.tblTradesman.Find(id);
            db.tblTradesman.Remove(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CallTradesman(int id)
        {
            var f = db.tblTradesman.Find(id);

            //İL VE İLÇELERİ CALL SAYFASINA TAŞIMA

            ViewBag.CityList = new SelectList(db.tblCity.ToList(), "Id", "Name");
            ViewBag.DistrictList = new SelectList(db.tblDistrict.ToList(), "Id", "Name");

            return View(f);
        }


        public ActionResult EditTradesman(tblTradesman t)
        {
            if (ModelState.IsValid)
            {
                var tradesman = db.tblTradesman.Find(t.Id);

                if (tradesman != null)
                {
                    tradesman.FirstName = t.FirstName;
                    tradesman.LastName = t.LastName;
                    tradesman.IdentityNo = t.IdentityNo;
                    tradesman.Contact = t.Contact;

                    tblAddress address = new tblAddress
                    {
                        Id = t.tblAddress.Id,
                        tblCityId = t.tblAddress.tblCityId,
                        tblDistrictId = t.tblAddress.tblDistrictId,
                        FullAddress = t.tblAddress.FullAddress,
                        NeighborhoodName = t.tblAddress.NeighborhoodName,
                    };
                    tradesman.tblAddress = address;



                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }


            return RedirectToAction("Index");

        }
    }
}