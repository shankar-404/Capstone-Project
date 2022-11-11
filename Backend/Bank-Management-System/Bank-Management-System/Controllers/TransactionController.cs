using Microsoft.AspNetCore.Mvc;
using Bank_Management_System.Entities;
using Bank_Management_System.Services;

namespace Bank_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionService _transactionService;
        public TransactionController()
        {
            _transactionService = new TransactionService();
        }

        [Route("withdraw")]
        [HttpPost]
        public IActionResult Withdraw([FromBody]TransactionRequest t)
        {

            try
            {
                TransactionResponse response = _transactionService.Withdraw(t);
                return StatusCode(200, response);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("deposit")]
        [HttpPost]
        public IActionResult Deposit([FromBody]TransactionRequest t)
        {

            try
            {
                TransactionResponse response = _transactionService.Deposit(t);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("balance/{customerId}")]
        [HttpGet]
        public IActionResult Balance([FromRoute] string customerId)
        {
            try
            {
                TransactionResponse response = _transactionService.Balance(customerId);
                return StatusCode(200, response);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("transactions/{customerId}")]
        [HttpGet]
        public IActionResult Transactions([FromRoute] string customerId)
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetAllTransaction(customerId);
                return StatusCode(200, transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("transactionsFilter/{customerId}/{start}/{end}")]
        [HttpGet]
        public IActionResult TransactionsFilter([FromRoute] string customerId, DateTime start, DateTime end)
        {
            try
            {
                FilterRequest request = new FilterRequest { CustomerId = customerId, start = start, end = end };
                List<Transaction> transactions = _transactionService.GetAllTransactionFilter(request);
                return StatusCode(200, transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
