using Bank_Management_System.Entities;

namespace Bank_Management_System.Interfaces
{
    public interface IRegisterService
    {
        void RegisterUser(UserInfo userInfo);
        void UnregisterUser(string customerId);
        void UpdateUser(string customerId);
        UserInfo GetUser(string customerId);
        List<UserInfo> GetAllUsers();
    }
}
