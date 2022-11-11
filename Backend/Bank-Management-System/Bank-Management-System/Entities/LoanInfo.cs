using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Entities
{
    [Table("LoanInfoTable")]
    public class LoanInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public double Amount { get; set; }
        public string? LoanType {get; set; } // eg ['car loan', 'bike loan', house loan', etc]
    }
}
