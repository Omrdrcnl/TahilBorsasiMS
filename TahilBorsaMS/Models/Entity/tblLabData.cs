//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TahilBorsaMS.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLabData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLabData()
        {
            this.tblSale = new HashSet<tblSale>();
        }
    
        public int Id { get; set; }
        public Nullable<int> EntryProductId { get; set; }
        public Nullable<int> NutritionalValue { get; set; }
        public Nullable<bool> Process { get; set; }
    
        public virtual tblEntryProduct tblEntryProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSale> tblSale { get; set; }
    }
}
