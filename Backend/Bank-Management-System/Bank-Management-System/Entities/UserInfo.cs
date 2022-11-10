using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Entities
{
    [Table("UserInformation")]
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CustomerId { get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid Token { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        [StringLength(10)]
        public string? ContactNumber { get; set; }
        public string? Occupation { get; set; }
        public string? DOB { get; set; }
        [Required]
        public string Password { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public double Balance { get; set; }


    }
}
