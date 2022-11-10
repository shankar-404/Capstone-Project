using System;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
	public class TransactionResponse
	{
		public string CustomerId { get; set; }
		public bool Status { get; set; }
		public string? Message { get; set; }
        public double Balance { get; set; }
	}
}

