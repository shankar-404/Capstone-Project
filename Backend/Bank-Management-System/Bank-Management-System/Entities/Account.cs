using System;
using System.ComponentModel.DataAnnotations;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
	public class Account
	{
		[Key]
		public int Id { get; set; }
		public string CustomerId { get; set; }
		public double Balance { get; set; }
	}
}

