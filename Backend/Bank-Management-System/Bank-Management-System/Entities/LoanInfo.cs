using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Entities
{
    [Table("LoanInformation")]
    public class LoanInfo
    {         
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public string? Branch { get; set; }
        [Required]
        public int LoanAmount { get; set; }
        
    }
}
