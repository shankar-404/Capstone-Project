using Bank_Management_System.Entities;
using Bank_Management_System.Interfaces;

namespace Bank_Management_System.Services
{
    public class LoginService : ILoginService
    {
        private RegisterService registerService;

        public LoginService()
        {
            registerService = new RegisterService();
        }

        public int Login(LoginInfo loginInfo)
        {
            string userId = loginInfo.UserId;
            string password = loginInfo.Password;
            UserInfo? user = registerService.GetUser(userId);
            if (user == null)
                return 404;
            if (password != user.Password)
                return 401;
            return 200;
        }
    }
}
