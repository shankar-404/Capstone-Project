﻿using Bank_Management_System.Entities;
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
        public DbSet<Account> AccountList { get; set; }
        public DbSet<Transaction> TransactionList { get; set; }
        public DbSet<LoanInfo> LoanList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConnectionString);
            //optionsBuilder.UseInMemoryDatabase(databaseName: "BankDb");
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

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Balance)
            //    .HasDefaultValueSql("0.0");

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Time)
                .HasDefaultValueSql("getdate()");

        }
    }
}
