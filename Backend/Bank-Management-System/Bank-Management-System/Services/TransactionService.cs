using Bank_Management_System.Database;
using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Services
{
    public class TransactionService : ITransactionService
    {
        private UserInfoDbContext context;

        public TransactionService()
        {
            context = new UserInfoDbContext();
        }

        public void AddTransaction(Transaction transaction)
        {
            context.TransactionList.Add(transaction);
            context.SaveChanges();
        }

        public List<Transaction> GetAllTransactionFilter(FilterRequest request)
        {
            string custumorId = request.CustomerId;
            DateTime start = request.start;
            DateTime end = request.end;
            string type = request.type;
            return GetAllTransaction(custumorId).Where(t => t.Time>=start && t.Time<=end && t.Type==type).ToList();
        }

        public List<Transaction> GetAllTransaction(string customerId) {
            return context.TransactionList.Where(t=>t.CustomerId==customerId).ToList();
        }
        public TransactionResponse Balance(string customerId)
        {
            double CurrentBalance = (double)context.AccountList.SingleOrDefault(user => user.CustomerId == customerId).Balance;
            return new TransactionResponse {CustomerId=customerId, Status=true, Message=null, Balance=CurrentBalance };
        }

        public TransactionResponse Deposit(TransactionRequest transactionRequest)
        {
            string customerId = transactionRequest.CustomerId;
            double amount = (double)transactionRequest.Amount;
            double Currentbalance = (double)Balance(customerId).Balance;
            double NewBalance = Currentbalance + amount;
            UpdateBalance(customerId, NewBalance);

            AddTransaction(new Transaction { CustomerId = customerId, Amount = amount, Type = Constants.Constants.DEPOSIT });

            double balance = (double)Balance(customerId).Balance;
            return new TransactionResponse { CustomerId = customerId, Status = true, Message = $"Amount Rs {amount} Deposited !", Balance = NewBalance };
        }

        private void UpdateBalance(string customerId, double NewBalance)
        {
            var entry = context.AccountList.SingleOrDefault(user => user.CustomerId == customerId);
            entry.Balance = NewBalance;
            context.AccountList.Add(entry);
            context.Entry(entry).State = EntityState.Modified;
            context.SaveChanges();
        }

        public TransactionResponse Withdraw(TransactionRequest transactionRequest)
        {
            string customerId = transactionRequest.CustomerId;
            double amount = (double)transactionRequest.Amount;
            double CurrentBalance = (double)context.AccountList.SingleOrDefault(user => user.CustomerId == customerId).Balance;
            bool status = ValidateWidthraw(amount, CurrentBalance);
            string message;
            double NewBalance = CurrentBalance;
            if (status)
            {
                NewBalance = CurrentBalance - amount;
                UpdateBalance(customerId, NewBalance);

                AddTransaction(new Transaction { CustomerId = customerId, Amount = amount, Type = Constants.Constants.WITHDRAW });
                message = $"Rs {amount} withrawn";

            }
            else {
                message = "Insufficient Balance";
            }

            return new TransactionResponse { CustomerId = customerId, Status = status, Message = message, Balance = NewBalance };
        }

        private bool ValidateWidthraw(double amount, double balance)
        {
            if (balance==0)
                return false;
            if (balance < amount)
                return false;
            return true;
        }
    }
}
