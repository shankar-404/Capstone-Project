using Bank_Management_System.Database;
using Bank_Management_System.Entities;
using Bank_Management_System.Constants;
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

        private Account getAccountFromUserId(int id)
        {
            var account = context.AccounList.Where(a => a.UserInfoId == id).FirstOrDefault();
            if (account == null)
            {
                account = new Account { Balance = 0, UserInfoId = id };
                context.AccounList.Add(account);
                context.SaveChanges();
            }

            return account;
        }

        public bool validateTransaction(TransactionRequest t)
        {
            var account = getAccountFromUserId(t.UserId);

            if (t.Type == Constants.Constants.WITHDRAW)
            {
                if (t.Amount > account.Balance)
                {
                    return false;
                }
            }
                
            return true;
        }

        public TransactionResponse Withdraw(TransactionRequest t)
        {
            var account = getAccountFromUserId(t.UserId);

            if (validateTransaction(t))
            {
                account.Balance -= t.Amount ?? 0.0;
                context.AccounList.Update(account);
                context.SaveChanges();

                return new TransactionResponse
                {
                    AccountId = account.Id,
                    UserId = account.UserInfoId,
                    Status = true,
                    Balance = account.Balance
                };
            }

            return new TransactionResponse
            {
                AccountId = account.Id,
                UserId = account.UserInfoId,
                Status = false,
                Balance = account.Balance
            };
        }

        public TransactionResponse Deposit(TransactionRequest t)
        {
            var account = getAccountFromUserId(t.UserId);

            if (validateTransaction(t))
            {
                account.Balance += t.Amount ?? 0.0;
                context.AccounList.Update(account);
                context.SaveChanges();

                return new TransactionResponse
                {
                    AccountId = account.Id,
                    UserId = account.UserInfoId,
                    Status = true,
                    Balance = account.Balance
                };
            }

            return new TransactionResponse
            {
                AccountId = account.Id,
                UserId = account.UserInfoId,
                Status = false,
                Balance = account.Balance
            };
        }

        public TransactionResponse Balance(int id)
        {
            var account = getAccountFromUserId(id);

            return new TransactionResponse
            {
                AccountId = account.Id,
                UserId = account.UserInfoId,
                Status = true,
                Balance = account.Balance
            };
        }
    }
}
