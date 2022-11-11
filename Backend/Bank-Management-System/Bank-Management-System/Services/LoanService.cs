using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using Bank_Management_System.Constants;
using Bank_Management_System.Database;

namespace Bank_Management_System.Services
{
    public class LoanService : ILoanService
    {
        private UserInfoDbContext context;

        public LoanService() {
            context = new UserInfoDbContext();
        }

        public LoanResponse ApplyLoan(LoanRequest request)
        {
            string customerId = request.CustomerId;
            double amount = request.Amount;
            string? loanType = request.LoanType;
            LoanResponse? loanResponse = null;
            if (amount <= 0)
                loanResponse = new LoanResponse { Status = false, Message = "Enter a valid Loan Amount !" };
            else if (amount >= Constants.Constants.MAX_CREDIT_LIMIT)
                loanResponse = new LoanResponse { Status = false, Message = "Loan Amount exceeds max credit limit !" };
            else {
                loanResponse = new LoanResponse { Status = true, Message = $"Loan Amount of rs {amount} requested." };
                AddNewLoan(request);
            }
            return loanResponse;
        }

        private void AddNewLoan(LoanRequest request)
        {
            context.LoanList.Add(new LoanInfo { CustomerId = request.CustomerId, Amount = request.Amount, LoanType = request.LoanType });
            context.SaveChanges();
        }

        public List<LoanInfo> GetAllLoansById(string customerId)
        {
            return context.LoanList.Where(loan => loan.CustomerId == customerId).ToList();
        }
    }
}
