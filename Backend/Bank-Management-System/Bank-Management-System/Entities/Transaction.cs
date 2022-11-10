using System;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
	public class Transaction
	{
		public int Id { get; set; }

		public int UserInfoId { get; set; }
		public UserInfo UserInfo { get; set; }

		public double Amount { get; set; }
		public string Type { get; set; }
	}
}

