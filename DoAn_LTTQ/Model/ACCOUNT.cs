//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn_LTTQ.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            this.INPUT_INFOR = new HashSet<INPUT_INFOR>();
            this.OUTPUT_INFOR = new HashSet<OUTPUT_INFOR>();
        }
    
        public int ACCOUNT_ID { get; set; }
        public string ACCOUNT_USERNAME { get; set; }
        public Nullable<int> ID_USER { get; set; }
        public string ACCOUNT_PASSWORD { get; set; }
        public Nullable<System.DateTime> DATE_CREATED { get; set; }
    
        public virtual USER_ USER_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INPUT_INFOR> INPUT_INFOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTPUT_INFOR> OUTPUT_INFOR { get; set; }
    }
}
