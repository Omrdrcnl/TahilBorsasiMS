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
    
    public partial class tblTradesman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTradesman()
        {
            this.tblSaleTrades = new HashSet<tblSaleTrades>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNo { get; set; }
        public string Contact { get; set; }
        public Nullable<int> AddressId { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
    
        public virtual tblAddress tblAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleTrades> tblSaleTrades { get; set; }
        public virtual tblTradesman tblTradesman1 { get; set; }
        public virtual tblTradesman tblTradesman2 { get; set; }
    }
}
