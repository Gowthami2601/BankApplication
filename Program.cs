using System;
using BankApplication.Models;
using BankApplication.Services;
namespace BankCon
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********Welcome*************");
            int x = 0;
            while (x != 1)
            {
                UserChoices userChoice = (UserChoices)Enum.Parse(typeof(UserChoices), Console.ReadLine());
                switch (userChoice)
                {
                    case UserChoices.CreateAccount:
                        {
                            BankServices.AddAccount( );
                            break;
                        }
                    case UserChoices.Deposit:
                        {
                            BankServices.Deposit();
                            break;
                        }
                    case UserChoices.Withdraw:
                        {
                            BankServices.Withdraw();
                            break;
                        }
                    case UserChoices.Transfer:
                        {
                            BankServices.Transfer();
                            break;
                        }
                    case UserChoices.Transactions:
                        {
                            BankMessages.UserOutput("Enter AccountId");
                            int actId = BankMessages.GetIntInput();
                            BankMessages.UserOutput("Enter pin");
                            string pin = BankMessages.GetStringInput();
                            TransactionServices.PrintTransaction(actId,pin);
                            break;
                        }
         
                }
            }
        }
            public enum UserChoices
        {
            CreateAccount = 1,
            Deposit = 2,
            Withdraw = 3,
            Transfer = 4,
            Transactions = 5
            //
        }

        }
    }
