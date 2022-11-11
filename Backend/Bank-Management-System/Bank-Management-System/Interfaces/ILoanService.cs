using Bank_Management_System.Entities;
using Microsoft.Identity.Client;

namespace Bank_Management_System.Interfaces
{
    public interface ILoanService
    {
        LoanResponse ApplyLoan(LoanRequest request);
        List<LoanInfo> GetAllLoansById(string Loan);
   
    }
}
