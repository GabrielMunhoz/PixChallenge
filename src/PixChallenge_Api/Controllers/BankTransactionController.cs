using Microsoft.AspNetCore.Mvc;
using PixChallenge_Application.Interfaces;

namespace PixChallenge_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankTransactionController : ControllerBase
    {
        private readonly IBankTransactionService _bankTransactionService;
        private readonly ILogger<BankTransactionController> _logger;

        public BankTransactionController(IBankTransactionService bankTransaction, ILogger<BankTransactionController> logger)
        {
            _bankTransactionService = bankTransaction;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPaymentAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentAsync(string key)
        {
            return Ok();
        }
    }
}
