using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    [Table("V_Chart")]
    public class V_Chart
    {
        public int? EntryId { get; set; }
        public int? SaleId { get; set; }
        public string TrFirstName { get; set; }
        public string TrLastName { get; set; } 
        public string FrFirstName { get; set; }
        public string FrLastName { get; set; }
        public string ProductName { get; set; }
        public decimal ActualPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Date { get; set; }
    }
}