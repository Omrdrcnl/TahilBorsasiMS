using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Classes;
using System.Data.Entity;

namespace TahilBorsaMS.Controllers
{
    public class HomeController : Controller
    {
        DbGrainExchangeEntities db = new DbGrainExchangeEntities();
        public ActionResult Index(DateTime? selectedDate)
        {
            // Varsayılan olarak bugünkü tarihi kullanmak için:
            if (!selectedDate.HasValue)
            {
                selectedDate = DateTime.Today;
            }

            // Seçilen tarih için günün başlangıcı ve bitişi
            DateTime startDate = selectedDate.Value.Date;
            DateTime endDate = startDate.AddDays(1).AddTicks(-1);

            //Yeni bir sınıf olusturup value degerini oraya aktarıyoruz. Liste halınde de bunu viewde cekıyoruz.
            var groupedSales = db.tblSale
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .GroupBy(s => new { s.tblEntryProduct.tblProduct.Name, Date = DbFunctions.TruncateTime(s.Date), s.tblEntryProduct.tblProduct.Photo })
                .Select(group => new GroupedSaleViewModel
                {
                    ProductName = group.Key.Name,
                    SaleDate = (DateTime)group.Key.Date,
                    TotalQuantity = group.Sum(s => s.Quantity),
                    TotalActualPrice = group.Max(s => s.ActualPrice),
                    TotalBasePrice = group.Min(s => s.BasePrice),
                    Photo = group.Key.Photo
                })
                .ToList();

            ViewBag.SelectedDate = selectedDate;
            return View(groupedSales);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(tblContact c)
        {
            
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}