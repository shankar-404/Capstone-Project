using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Bank_Management_System.Entities;
using Bank_Management_System.Services;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginServiceController : ControllerBase
    {
        private LoginService loginService;
        public LoginServiceController() {
            loginService = new LoginService();
        }
        // POST api/<LoginServiceController>
        [HttpPost]
        public ActionResult Post([FromBody] LoginInfo loginInfo)
        {
            int statusCode = loginService.Login(loginInfo);
            return StatusCode(statusCode, statusCode);
                
        }

    }
}
