namespace Bank_Management_System.Entities
{
    public class LoanRequest
    {
        public string CustomerId { get; set; }
        public double Amount { get; set; }
        public string? BankBranch { get; set; }
        public string? LoanType { get; set; }
    }
}
