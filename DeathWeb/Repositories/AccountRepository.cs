using DeathWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeathWeb.Repositories
{
    public class AccountRepository
    {
        private static DeathDataEntities db = new DeathDataEntities();

        public static Account GetAccountByID(int accountID)
        {
            return db.Accounts.Where(a => a.ID == accountID).Include(a => a.AccountType).SingleOrDefault();
        }
    }
}