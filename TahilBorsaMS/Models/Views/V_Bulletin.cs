using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    [Table("V_Bulletin")]
    public class V_Bulletin
    {

        public string ProductName { get; set; }
        public decimal ActualPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? BasePrice { get; set; }
        public DateTime Date { get; set; }
        public string Photo { get; set; }
    }
}