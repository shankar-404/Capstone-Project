using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bank_Management_System.Constants;

namespace Bank_Management_System.Entities
{
	[Table("Transaction Table")]
	public class Transaction
	{
		[Key]
		public int Id { get; set; }
		public string CustomerId { get; set; }
		public double Amount { get; set; }
		public string Type { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Time { get; set; }
	}
}

