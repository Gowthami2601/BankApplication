using System;
using System.Collections.Generic;
using System.Text;
using BankApplication.Models;
namespace BankApplication.Services
{
    public class BankServices
    {
        public static Dictionary<int, Account> AccountsList { set; get; }
        public static string dt;
        static BankServices()
        {
            AccountsList = new Dictionary<int, Account>();
        }
        public static void AddAccount()
        {
            string name = BankMessages.GetStringInput();
            string pin = BankMessages.GetStringInput();
            Account account = new Account(name, pin);
            AccountsList.Add(account.accountID, account);
            BankMessages.UserOutput("Account " + account.accountID + " is created");
            dt = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
        }
        public string GetDate()
        {
            return dt;
        }
        public static void Deposit()
        {
            BankMessages.UserOutput("Enter your account number");
            int accountId = BankMessages.GetIntInput();
            if (AccountsList.ContainsKey(accountId))
            {
                BankMessages.UserOutput("Enter your account number");
                string pin = BankMessages.GetStringInput();
                if (ValidatePin(accountId, pin))
                {
                    Console.WriteLine("Enter the amount");
                    int deposit = BankMessages.GetIntInput();
                    Account account = AccountsList[accountId];
                    account.amount += deposit;
                    BankMessages.UserOutput("Deposited succesfully.");
                    PrintCurrentBal(accountId, pin);
                }
                else
                {
                    BankMessages.UserOutput("Invlaid Pin");
                }
            }
            else
            {
                Console.WriteLine("Invalid account id");
            }
        }
        public static void Withdraw()
        {
            BankMessages.UserOutput("Enter your account number");
            int accountId = BankMessages.GetIntInput();
            if (AccountsList.ContainsKey(accountId))
            {
                BankMessages.UserOutput("Enter your account number");
                string pin = BankMessages.GetStringInput();
                if (ValidatePin(accountId, pin))
                {
                    Console.WriteLine("Enter the amount");
                    int withdraw = BankMessages.GetIntInput();
                    if (withdraw <= AccountsList[accountId].amount)
                    {
                        AccountsList[accountId].amount -= withdraw;
                        BankMessages.UserOutput("Withdrawing completed succesfully.");
                        PrintCurrentBal(accountId, pin);
                    }
                    else
                    {
                        BankMessages.UserOutput("Insufficient Balance");
                    }
                }
                else
                {
                    BankMessages.UserOutput("Invlaid Pin");
                }
            }
            else
            {
                Console.WriteLine("Invalid account id");
            }
        }
        public static void Transfer()
        {
            BankMessages.UserOutput("Enter account number from which money should be transfered");
            int fromId = BankMessages.GetIntInput();
            if (AccountsList.ContainsKey(fromId))
            {
                BankMessages.UserOutput("Enter your account number");
                string pin = BankMessages.GetStringInput();
                if (ValidatePin(fromId, pin))
                {
                    BankMessages.UserOutput("Enter account number to which money should be transfered");
                    int toId = BankMessages.GetIntInput();
                    if (AccountsList.ContainsKey(toId))
                    {
                        BankMessages.UserOutput("Entre amount");
                        int transferamt = BankMessages.GetIntInput();
                        if (transferamt <= AccountsList[fromId].amount)
                        {
                            AccountsList[fromId].amount -= transferamt;
                            AccountsList[toId].amount += transferamt;
                        }
                        else
                        {
                            BankMessages.UserOutput("Insufficient Balance");
                        }
                    }
                    else
                    {
                        BankMessages.UserOutput("Reciver account id is invalid");
                    }
                }
                else
                {
                    BankMessages.UserOutput("Invalid Pin");
                }
            }
            else
            {
                BankMessages.UserOutput("Invalid Account Id");
            }
        }
        public static void PrintCurrentBal(int accountId,string pin)
        {
            if (AccountsList.ContainsKey(accountId))
            {
                if (ValidatePin(accountId, pin))
                {
                    BankMessages.UserOutput("Your Current Balance is " + AccountsList[accountId].amount);
                }
            }
        }
        public static bool ValidatePin(int accountId,string pin)
        {
            if (pin == AccountsList[accountId].pin)
            {
                return true;
            }
            else
                return false;
        }
        public static bool ValidateAccount(int accountId)
        {
            if (AccountsList.ContainsKey(accountId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
