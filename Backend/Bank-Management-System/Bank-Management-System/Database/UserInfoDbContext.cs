using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Bank_Management_System.Database
{
    public class UserInfoDbContext:DbContext
    {
        //Monish-ConnectionString
        //private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BankDb;Trusted_Connection=True;trustServerCertificate=true;";

        //Shankar-ConnectionString
        private const string ConnectionString = @"server=DESKTOP-TSPSRDD;database=BankDb;Trusted_Connection=true;trustServerCertificate=true;";

        public DbSet<UserInfo> UsersList { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                .Property(p => p.CustomerId)
                // here is the computed query definition
                .HasComputedColumnSql("N'wf'+ RIGHT('00'+CAST(Id AS VARCHAR(5)),5)").HasConversion<string>();
            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Token)
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Token)
                .HasDefaultValueSql("(newsequentialid())");

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Token)
                .HasDefaultValueSql("(newid())");

        }
    }
}
