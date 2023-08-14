using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    [Table("V_EntryProductList")]

    public class V_EntryProductList
    {
        public int? EntryProductId { get; set; }
        public int? FarmerId { get; set; }
        public int? ProductId { get; set; }
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public DateTime? DateTime { get; set; }
        public string FarmerName { get; set; }
        public string FarmerLastName { get; set; }
        public bool? Process { get; set; }
    }
}