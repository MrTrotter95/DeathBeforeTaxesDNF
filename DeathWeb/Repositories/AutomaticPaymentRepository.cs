using DeathWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DeathWeb.Repositories
{
    public static class AutomaticPaymentRepository
    {
        private static DeathDataEntities db = new DeathDataEntities();


        public static List<AutomaticPayment> GetAllIncludingVirtual()
        {
            return db.AutomaticPayments
                .Include(a => a.Account)
                .Include(a => a.PaymentFrequency)
                .Include(a => a.TransactionCategory)
                .ToList();
        }

        public static List<AutomaticPayment> GetAllByAccountID(int accountID)
        {
            return db.AutomaticPayments
                .Where(a => a.FK_AccountID == accountID)
                .Include(a => a.Account)
                .Include(a => a.PaymentFrequency)
                .Include(a => a.TransactionCategory)
                .ToList();
        }

    }
}