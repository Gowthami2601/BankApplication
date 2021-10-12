using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.Models
{
    public class Transaction
    {
        public int fromID { get; set; }
        public int toId { get; set; }
        public string msg { get; set; }
        public double amount { get; set; }

        public Transaction(int fromID, int toId, string msg, double amount)
        {
            this.fromID = fromID;
            this.toId = toId;
            this.msg = msg;
            this.amount = amount;
        }
    }
}