using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Bank_Management_System.Services
{
    public class LoginService : ILoginService
    {
        private RegisterService registerService;

        public LoginService()
        {
            registerService = new RegisterService();
        }

        public LoginResponse Login(LoginInfo loginInfo)
        {
            string customerId = loginInfo.CustomerId;
            string password = loginInfo.Password;
            UserInfo? user = registerService.GetUser(customerId);
            if (user == null)
                return new LoginResponse { status = 404, customerId=null, Token=null };
            if (password != user.Password)
                return new LoginResponse { status = 401, customerId = null, Token = null };
            return new LoginResponse { status = 200, customerId = user.CustomerId, Token = user.Token.ToString() };
        }
    }
}
