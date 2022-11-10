using Bank_Management_System.Database;
using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Bank_Management_System.Services
{
    public class RegisterService : IRegisterService
    {
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
            string cutomerId = context.UsersList.OrderByDescending(p => p.Id).FirstOrDefault().CustomerId;
            return new RegisterResponse { CustomerId=cutomerId};
        }

        public void UnregisterUser(string userId)
        {
            context.UsersList.Remove(GetUser(userId));
            context.SaveChanges();
        }

        public void UpdateUser(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
