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
    
    public partial class SavingsGoal
    {
        public int ID { get; set; }
        public Nullable<int> FK_AccountID { get; set; }
        public string Name { get; set; }
        public decimal CurrentTotal { get; set; }
        public decimal GoalAmount { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<System.DateTime> ActualBuyPrice { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
