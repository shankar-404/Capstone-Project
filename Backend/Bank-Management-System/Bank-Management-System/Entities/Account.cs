using System;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
	public class Account
	{
		public int Id { get; set; }

		public int UserInfoId { get; set; }
		public UserInfo UserInfo { get; set; }

		public double Balance { get; set; }
	}
}

