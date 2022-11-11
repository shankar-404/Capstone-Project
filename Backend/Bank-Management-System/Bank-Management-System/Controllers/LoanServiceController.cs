using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Bank_Management_System.Entities;
using Bank_Management_System.Services;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanServiceController : ControllerBase
    {
        private LoanService loanService;
        public LoanServiceController()
        {
            loanService = new LoanService();
        }
        // POST api/<LoginServiceController>
        [HttpPost]
        [Route("/ApplyLoan")]
        public ActionResult ApplyLoan([FromBody] LoanRequest request)
        {
            try
            {
                return StatusCode(200, loanService.ApplyLoan(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetUserLoan/{customerId}")]
        public ActionResult GetLoanbyId(string customerId)
        {
            try
            {
                return StatusCode(200, loanService.GetAllLoansById(customerId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
