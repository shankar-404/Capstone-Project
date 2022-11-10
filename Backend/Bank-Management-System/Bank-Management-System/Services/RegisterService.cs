using Bank_Management_System.Database;
using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Bank_Management_System.Services
{
    public class RegisterService : IRegisterService
    {
        public const double OPENING_BALANCE = 0.0;
        private UserInfoDbContext context; 
        public RegisterService() {
            context = new UserInfoDbContext();
        }

        public List<UserInfo> GetAllUsers()
        {
            return context.UsersList.ToList();
        }

        public UserInfo GetUser(string userId)
        {
            return context.UsersList.SingleOrDefault(user => user.CustomerId == userId);
        }

        public RegisterResponse RegisterUser(UserInfo userInfo)
        {
            context.UsersList.Add(userInfo);
            context.SaveChanges();
            string customerId = context.UsersList.OrderByDescending(p => p.Id).FirstOrDefault().CustomerId;
            CreateAccount(customerId);
            return new RegisterResponse { CustomerId=customerId};
        }

        private void CreateAccount(string customerId)
        {
            context.AccountList.Add(new Account { CustomerId = customerId, Balance = OPENING_BALANCE });
            context.SaveChanges();
        }

        public void UnregisterUser(string customerId)
        {
            context.UsersList.Remove(GetUser(customerId));
            context.SaveChanges();
            DeleteAccount(customerId);
        }
        private Account GetAccount(string customerId) {
            return context.AccountList.SingleOrDefault(a => a.CustomerId == customerId);
        }
        private void DeleteAccount(string customerId)
        {
            context.AccountList.Remove(GetAccount(customerId));
            context.SaveChanges();
        }

        public void UpdateUser(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
