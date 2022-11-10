using System;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
	public class TransactionResponse
	{
		public int UserId { get; set; }
		public int AccountId { get; set; }
		public bool Status { get; set; }
        public double Balance { get; set; }
	}
}

