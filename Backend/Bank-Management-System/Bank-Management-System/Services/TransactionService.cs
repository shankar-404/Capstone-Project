using Bank_Management_System.Database;
using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Bank_Management_System.Services
{
    public class TransactionService : ITransactionService
    {
        private UserInfoDbContext context;

        public TransactionService ()
        {
            context = new UserInfoDbContext();
        }

        public TransactionResponse Withdraw(TransactionRequest t)
        {
            return new TransactionResponse {
                AccountId = 1,
                UserId = 1,
                Status = true,
                Balance = 0
            };
        }

        public TransactionResponse Deposit(TransactionRequest t)
        {
            return new TransactionResponse
            {
                AccountId = 1,
                UserId = 1,
                Status = true,
                Balance = 0
            };
        }

        public TransactionResponse Balance(int id)
        {
            return new TransactionResponse
            {
                AccountId = 1,
                UserId = 1,
                Status = true,
                Balance = 0
            };
        }
    }
}
