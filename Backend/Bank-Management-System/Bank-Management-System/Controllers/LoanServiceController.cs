using Bank_Management_System.Entities;
using Bank_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public ActionResult GetLoan([FromBody] LoanInfo loanInfo)
        {
            int statusCode = loanService.Elligible(loanInfo);
            if (statusCode == -1)
            {
                return StatusCode(404,"User not found");
            }
            else if (statusCode == 0)
            {
                return StatusCode(406, "Loan amount not in eligibility limit");
            }
            else
            {
                return StatusCode(200, "Loan approved");
            }

        }
        [HttpGet,Route("ShowLoans/{id}")]
        public ActionResult ShowLoans(string id)
        {
            var loans = loanService.ShowLoans(id);
            return StatusCode(200,loans);
        }

    }
    
}
