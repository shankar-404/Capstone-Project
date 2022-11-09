using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using Bank_Management_System.Database;
using System.Linq;
namespace Bank_Management_System.Services
{
    public class LoanService : ILoanService
    {
        private readonly UserInfoDbContext _db;

        public LoanService()
        {
            _db = new UserInfoDbContext();
        }
        public List<LoanInfo> ShowLoans(string id)
        {
            var loans = (from l in _db.Loans
                         where l.UserId == id
                         select l).ToList();
            return loans;
        }
       public int Elligible(LoanInfo userLoanInfo)
        {
            var customer = _db.UsersList.SingleOrDefault(user => user.UserId == userLoanInfo.UserId);
            if(customer==null)
            {
                return -1; 
            }
            else if(userLoanInfo.LoanAmount < 0 || userLoanInfo.LoanAmount > 100000)
            {
                return 0;
            }
            else
            {
                _db.Loans.Add(userLoanInfo);
                _db.SaveChanges();
                return 1;
            }
        }
    }
}
