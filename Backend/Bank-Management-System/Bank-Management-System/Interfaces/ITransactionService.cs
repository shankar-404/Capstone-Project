using Bank_Management_System.Entities;

namespace Bank_Management_System.Interfaces
{
    public interface ITransactionService
    {
        TransactionResponse Withdraw(TransactionRequest t);
        TransactionResponse Deposit(TransactionRequest t);
        TransactionResponse Balance(string customerId);
    }
}
