using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Models;

namespace BankApplication.Services
{
    public class TransactionServices
    {
        private static List<Transaction> transactionList { set; get; }

        static TransactionServices()
        {

            transactionList = new List<Transaction>();
        }

        public static void AddTransaction(int fromID, int toID, string msg,double amount)
        {
            Transaction transaction = new Transaction(fromID, toID,msg,amount);
            transactionList.Add(transaction);
        }
        public static void PrintTransaction(int accountId,string pin)
        {
            if (BankServices.ValidateAccount(accountId) && BankServices.ValidatePin(accountId, pin))
            {
                BankMessages.UserOutput("Account is created on " + BankServices.dt);
                BankMessages.UserOutput("-----------------------------------------------");
                PrintHistory(accountId);
            }
            else
            {
                BankMessages.UserOutput("Invalid account or pin no");
            }
        }
        public static void PrintHistory(int accountId)
        {
            BankMessages.UserOutput("From           To          Description             Balance");
            BankMessages.UserOutput("_____________________________________________________________");
            foreach (Transaction trns in transactionList)
            {
                BankMessages.UserOutput(trns.fromID + "           " + trns.toId + "           " + trns.msg + "            " + trns.amount);
            }
            BankMessages.UserOutput("Thankyou :)");
        }
    }
}
