//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeathWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AutomaticPaymentLog
    {
        public int ID { get; set; }
        public Nullable<int> FK_AutomaticPaymentID { get; set; }
        public System.DateTime TransactionDate { get; set; }
    
        public virtual AutomaticPayment AutomaticPayment { get; set; }
    }
}
