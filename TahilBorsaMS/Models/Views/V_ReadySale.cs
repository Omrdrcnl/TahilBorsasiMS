using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    [Table("V_ReadySale")]

    public class V_ReadySale
    {
        public int EntryId { get; set; }
        public int FarmerId { get; set; }
        public int SaleId { get; set; }
        public int LabId { get; set; }
        public string FarmerFirstName { get; set; }
        public string FarmerLastName { get; set; }
        public string FarmerIdentityNo { get; set; }
        public string ProductName { get; set; }
        public int NutritionalValue { get; set; }
        public bool Process { get; set; }

    }
}