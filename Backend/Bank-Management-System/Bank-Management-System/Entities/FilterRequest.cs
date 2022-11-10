namespace Bank_Management_System.Entities
{
    public class FilterRequest
    {
        public string CustomerId { get; set;  }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
