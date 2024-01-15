using DeathWeb.Models;
using DeathWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeathWeb.ViewModels.Home
{
    


    public class HomeViewModel
    {
        private DeathDataEntities db = new DeathDataEntities();

        public List<AutomaticPayment> AutomaticPayments { get; set; }
        //public List<GeneratedPayment> GeneratedPayments { get; set; }



        /*
         * Get AutomaticPayments Where IsPaid == false
         * Group By FK_AccountID
         * 
         * 
         */ 
         



        //public HomeViewModel(DeathDataEntities db)
        //{
        //    AutomaticPayments = AutomaticPaymentRepository.GetAllAPs();

        //}


        //public List<GeneratedPayment> GetGeneratedAPList(List<AutomaticPayment> automaticPayments)
        //{
        //    var now = DateTime.Now;




        //}

        //public static GeneratedPayment GetGeneratedAPItem(AutomaticPayment automaticPayment, DateTime priorDueDate)
        //{
        //    var generatedPayment = new GeneratedPayment();

        //    generatedPayment.ID = automaticPayment.ID;
        //    generatedPayment.FK_AccountID = automaticPayment.FK_AccountID.Value;
        //    generatedPayment.FK_FrequencyID = automaticPayment.FK_FrequencyID.Value;
        //    generatedPayment.FK_CategoryID = automaticPayment.FK_CategoryID.Value;
        //    generatedPayment.Name = automaticPayment.Name;
        //    generatedPayment.Amount = automaticPayment.Amount.Value;
        //    generatedPayment.isPaid = false;

        //    switch (automaticPayment.FK_FrequencyID)
        //    {
        //        case 1:
        //            generatedPayment.DueDate = priorDueDate.AddDays(1);
        //            break;
        //        case 2:
        //            generatedPayment.DueDate = priorDueDate.AddDays(7);
        //            break;
        //        case 3:
        //            generatedPayment.DueDate = priorDueDate.AddDays(14);
        //            break;
        //        case 4:
        //            generatedPayment.DueDate = priorDueDate.AddMonths(1);
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }



}