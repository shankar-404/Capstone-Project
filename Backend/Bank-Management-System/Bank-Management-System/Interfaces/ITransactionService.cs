using Bank_Management_System.Entities;

namespace Bank_Management_System.Interfaces
{
    public interface ITransactionService
    {
        TransactionResponse Withdraw(TransactionRequest transactionRequest);
        TransactionResponse Deposit(TransactionRequest transactionRequest);
        TransactionResponse Balance(string customerId);
    }
}
