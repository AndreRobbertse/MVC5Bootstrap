//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Bootstrap
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestSiteWorkingSite
    {
        public long TestSiteWorkingSiteID { get; set; }
        public string Name { get; set; }
        public int TestSiteID { get; set; }
        public Nullable<bool> Active { get; set; }
        public long CreatedByID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public long ModifiedByID { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual TestSite TestSite { get; set; }
    }
}
