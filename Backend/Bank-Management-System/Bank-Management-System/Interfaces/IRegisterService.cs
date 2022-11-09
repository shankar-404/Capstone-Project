using Bank_Management_System.Entities;

namespace Bank_Management_System.Interfaces
{
    public interface IRegisterService
    {
        void RegisterUser(UserInfo userInfo);
        void UnregisterUser(string UserId);
        void UpdateUser(string UserId);
        UserInfo GetUser(string UserId);
        List<UserInfo> GetAllUsers();
    }
}
