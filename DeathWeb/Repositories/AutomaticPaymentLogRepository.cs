using DeathWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DeathWeb.Repositories
{
    public class AutomaticPaymentLogRepository
    {
        private static DeathDataEntities db = new DeathDataEntities();


        public static List<AutomaticPaymentLog> GetAllIncludingVirtual()
        {
            return db.AutomaticPaymentLogs
                .Include(a => a.AutomaticPayment)
                .ToList();
        }

        public static List<AutomaticPaymentLog> GetAllByAutomaticPaymentID(int paymentID)
        {
            return db.AutomaticPaymentLogs
                .Where(a => a.FK_AutomaticPaymentID == paymentID)
                .ToList();
        }

        public static List<AutomaticPaymentLog> GetAllByAutomaticPaymentIDs(List<int> paymentIDs)
        {
            var hasPaymentIDs = paymentIDs.Any();


            return db.AutomaticPaymentLogs
                .Where(a => !hasPaymentIDs || paymentIDs.Contains(a.FK_AutomaticPaymentID.Value))
                .ToList();
        }

    }
}