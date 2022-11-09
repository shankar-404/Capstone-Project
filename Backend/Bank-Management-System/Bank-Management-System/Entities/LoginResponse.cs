namespace Bank_Management_System.Entities
{
    public class LoginResponse
    {
        public int status { get; set; }
        public string? customerId { get; set; }
        public string? Token { get; set; }

    }
}
