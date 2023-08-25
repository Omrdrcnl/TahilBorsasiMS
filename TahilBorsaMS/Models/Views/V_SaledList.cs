using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    [Table("V_SaledList")]
    public class V_SaledList
    {
        public int SaleId { get; set; }
        public int EntryId { get; set; }
        public int labId { get; set; }
        public int TradesmanId { get; set; }
        public int FarmerId { get; set; }
        public string FarmerFirstName { get; set; }
        public string FarmerLastName { get; set; }
        public string FarmerIdentityNo { get; set; }
        public string TrFirstName { get; set; }
        public string TrLastName { get; set; }
        public string ProductName { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal BasePrice { get; set; }
        public int NutritionalValue { get; set; }
        public int Quantity { get; set; }
      
    }
}