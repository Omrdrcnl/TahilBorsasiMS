using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TahilBorsaMS.Models.Views
{
    public class V_Bos
    {
        public int EntryId { get; set; }
        public int FarmerId { get; set; }
        public string IdentityNo { get; set; }
        public int NutritionalValue { get; set; }
        public DateTime DateTime { get; set; }
    }
}