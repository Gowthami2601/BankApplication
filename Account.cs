using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class Account
    {
        private static int applicationNo =1000;
        public int accountID { get; set; }
        public string name { get; set; }
        public double amount { get; set; }
        public string pin { get; set; }


        public Account(string name, string pin)
        {
            this.accountID = ++applicationNo;
            this.pin = pin;
            this.name = name;
            this.amount = 0;
        }

    }
}
