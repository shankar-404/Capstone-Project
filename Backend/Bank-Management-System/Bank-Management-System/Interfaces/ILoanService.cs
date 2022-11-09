using Bank_Management_System.Entities;

namespace Bank_Management_System.Interfaces
{
    public interface ILoanService
    {
        public int Elligible(LoanInfo userLoanInfo);
        public List<LoanInfo> ShowLoans(string id);
    }
}
