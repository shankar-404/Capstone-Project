using Bank_Management_System.Entities;
using Bank_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterServiceController : ControllerBase
    {
        private RegisterService registerService;
        public RegisterServiceController() {
            registerService = new RegisterService();
        }
        // GET: api/<RegisterServiceController>
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            try
            {
                return StatusCode(200, registerService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<RegisterServiceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RegisterServiceController>
        [HttpPost]
        [Route("Register")]
        public ActionResult Register([FromBody] UserInfo userInfo)
        {
            try
            {
                registerService.RegisterUser(userInfo);
                return StatusCode(200, "User Registered !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<RegisterServiceController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<RegisterServiceController>/5
        [HttpDelete("Unregister/{userId}")]
        public ActionResult UnRegister(string userId)
        {
            try
            {
                registerService.UnregisterUser(userId);
                return StatusCode(200, "UnRegistered User !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
