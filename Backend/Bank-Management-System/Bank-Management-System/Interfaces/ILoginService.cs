using Bank_Management_System.Entities;

namespace Bank_Management_System.Interfaces
{
    public interface ILoginService
    {
        LoginResponse Login(LoginInfo userLoginInfo);
    }
}
