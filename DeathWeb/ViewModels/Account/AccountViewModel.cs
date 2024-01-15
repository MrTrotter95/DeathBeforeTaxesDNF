using DeathWeb.Models;
using DeathWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeathWeb.ViewModels.Account
{
    public class AccountViewModel
    {
        public Models.Account Account { get; set; }

        public List<AutomaticPayment> AutomaticPayments;
        public List<AutomaticPaymentLog> AutomaticPaymentsLog;
        public List<ExpenseToPay> ExpensesToPay;

        public AccountViewModel(int accountID)
        {
            var now = DateTime.Now;

            Account = AccountRepository.GetAccountByID(accountID);

            ExpensesToPay = new List<ExpenseToPay>();



            if (Account.FK_AccountTypeID == Domain.Constants.AccountType.Expense)
            {
                AutomaticPayments = AutomaticPaymentRepository.GetAllByAccountID(accountID);

                var paymentIDsList = AutomaticPayments.Select(c => c.ID).ToList();

                AutomaticPaymentsLog = AutomaticPaymentLogRepository.GetAllByAutomaticPaymentIDs(paymentIDsList);

                if (AutomaticPaymentsLog.Count() == 0)
                {
                    // Add Exisiting AP's
                    foreach (var payment in AutomaticPayments)
                    {
                        if (payment.StartDate <= now)
                        {
                            ExpensesToPay.Add(new ExpenseToPay
                            {
                                ID = payment.ID,
                                FK_AccountID = payment.FK_AccountID.Value,
                                FK_FrequencyID = payment.FK_FrequencyID.Value,
                                FK_CategoryID = payment.FK_CategoryID.Value,
                                Name = payment.Name,
                                Amount = payment.Amount.Value,
                                DueDate = payment.StartDate,
                                isPaid = false
                            });
                        }
                    }


                    // Add Generated AP's
                    foreach (var payment in AutomaticPayments)
                    {
                        var dateCounter = payment.StartDate;
                        while (dateCounter <= now)
                        {
                            var generatedPayment = new ExpenseToPay();

                            generatedPayment.ID = payment.ID;
                            generatedPayment.FK_AccountID = payment.FK_AccountID.Value;
                            generatedPayment.FK_FrequencyID = payment.FK_FrequencyID.Value;
                            generatedPayment.FK_CategoryID = payment.FK_CategoryID.Value;
                            generatedPayment.Name = payment.Name;
                            generatedPayment.Amount = payment.Amount.Value;
                            generatedPayment.isPaid = false;

                            switch (payment.FK_FrequencyID)
                            {
                                case 1:
                                    generatedPayment.DueDate = payment.StartDate.AddDays(1);
                                    break;
                                case 2:
                                    generatedPayment.DueDate = payment.StartDate.AddDays(7);
                                    break;
                                case 3:
                                    generatedPayment.DueDate = payment.StartDate.AddDays(14);
                                    break;
                                case 4:
                                    generatedPayment.DueDate = payment.StartDate.AddMonths(1);
                                    break;
                                default:
                                    break;
                            }

                            if (generatedPayment.DueDate <= now)
                            {
                                ExpensesToPay.Add(generatedPayment);
                                
                            }
                            dateCounter = generatedPayment.DueDate.Value;
                        }
                    }
                }
                else
                {

                }
            }

            ExpensesToPay.OrderBy(i => i.DueDate).ToList();

            //Generate a AP

            // If there are no APs, we need to create one from the APs. So it's a first timer. This should only execute once when it's initially setup



            // Else if
        }


    }

    public class ExpenseToPay
    {
        public int ID;
        public int FK_AccountID;
        public int FK_FrequencyID;
        public int FK_CategoryID;
        public string Name;
        public decimal? Amount;
        public DateTime? DueDate;
        public bool isPaid;
    }
}