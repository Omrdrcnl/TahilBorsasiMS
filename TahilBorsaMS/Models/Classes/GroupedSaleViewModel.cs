using System;

namespace TahilBorsaMS.Controllers
{
    public class GroupedSaleViewModel
    {
        public string ProductName { get; set; }
        public DateTime SaleDate { get; set; }
        public int? TotalQuantity { get; set; }
        public decimal? TotalActualPrice { get; set; }
        public decimal? TotalBasePrice { get; set; }
        public string Photo { get; set; }
    }
}