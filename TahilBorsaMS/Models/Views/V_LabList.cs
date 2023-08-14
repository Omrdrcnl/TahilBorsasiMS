using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    [Table("V_LabList")]

    public class V_LabList
    {
        public int? EntryProductId { get; set; }
        public int? FarmerId { get; set; }
        public string ProductName { get; set; }
        public DateTime DateTime { get; set; }
        public string FarmerFirstName { get; set; }
        public string FarmerLastName { get; set; }
    }
}