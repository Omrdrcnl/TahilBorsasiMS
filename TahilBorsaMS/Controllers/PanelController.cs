using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Controllers;
using System.Collections;

namespace TahilBorsaMS.Controllers
{
    public class PanelController : Controller
    {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();
        // GET: Panel

        [Authorize]
        public ActionResult Index()
        {
            var tradesman = db.tblTradesman.Count();
            ViewBag.Tradesman = tradesman;

            var sale = db.tblSale.Count();
            ViewBag.Sale = sale;

            var saleAmount = db.tblSale.Sum(x =>x.Amount);
            ViewBag.SaleAmount = saleAmount;

            var saleQuantity = db.tblSale.Sum(x => x.Quantity);
            ViewBag.SaleQuantity = saleQuantity;

            //Ürüne Göre Toplam İşlem Gören Miktarlar
            ArrayList quantityLis = new ArrayList();

            var saleByPro = db.tblSale.GroupBy(x=>x.tblEntryProduct.tblProduct.Name)
                .Select( group => new
                {
                    Product = group.Key,
                    Quantity = group.Sum(s => s.Quantity)
                }).ToDictionary(x => x.Quantity, x =>x.Product);
            //arraya veri at
            var saleByProId = db.tblSale.GroupBy(x => x.tblEntryProduct.tblProductId)
             .Select(group => new
             {
                 Product = group.Key,
                 Quantity = group.Sum(s => s.Amount)
             }).ToDictionary(x => quantityLis.Add(x.Quantity), x => x.Product);

            ViewBag.Qp = saleByPro;
            ViewBag.Q = quantityLis;

            //Aylara göre satışların gruplandırılması

            ArrayList amounts = new ArrayList();
            var salesByMonth = db.tblSale.GroupBy(s => s.Date.Value.Month)
             .Select(group => new
             {
                 Month = group.Key,
                 Amount = group.Sum(s => s.Amount)
             })
             .ToDictionary(x => x.Month, x => amounts.Add(x.Amount));

            ViewBag.Amounts =amounts;

            //Aylık ürünlere göre Fiyat Değişim tablosu/Grafiği

   
            var priceByMonth = db.tblSale.GroupBy(s => new { s.Date.Value.Month, s.tblEntryProduct.tblProduct.Name })
             .Select(group => new
             {
                 Product = group.Key.Name,
                 Month = group.Key,
                 Price = group.Max(s => s.ActualPrice)
             })
             .ToDictionary(x => new { x.Month, x.Product }, x => x.Price);

            ViewBag.Price = priceByMonth;

            //Aylara göre Fiyat Grafiği

            return View("Index");
        }
    }
}