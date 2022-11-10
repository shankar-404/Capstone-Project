using System;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
    public class TransactionRequest
    {
        public string CustomerId { get; set; }
        public double? Amount { get; set; }
        public string Type { get; set; }
    }
}

