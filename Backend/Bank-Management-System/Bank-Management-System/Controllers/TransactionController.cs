using Microsoft.AspNetCore.Mvc;

using Bank_Management_System.Entities;
using Bank_Management_System.Services;

namespace Bank_Management_System.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {
        private readonly TransactionService _transactionService;
        public TransactionController() {
            _transactionService = new TransactionService();
        }

        [Route("withdraw")]
        [HttpPost]
        public IActionResult Withdraw(TransactionRequest t) {

            return Ok(_transactionService.Withdraw(t));
        }

        [Route("deposit")]
        [HttpPost]
        public IActionResult Deposit(TransactionRequest t) {
            return Ok(_transactionService.Deposit(t));
        }

        [Route("balance/{id:}")]
        [HttpGet]
        public IActionResult Balance([FromRoute] int id) {
            return Ok(_transactionService.Balance(id));
        }
    }
}
