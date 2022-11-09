using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Database
{
    public class UserInfoDbContext:DbContext
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BankDb;Trusted_Connection=True;trustServerCertificate=true;";

        public DbSet<UserInfo> UsersList { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
