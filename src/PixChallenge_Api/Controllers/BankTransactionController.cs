using Microsoft.AspNetCore.Mvc;
using PixChallenge_Api.ViewModels.BankTransaction;
using PixChallenge_Application.Interfaces;
using PixChallenge_Core.Entities;

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
        public async Task<IActionResult> ProcessPaymentAsync(CreateTransactionViewModel createTransactionViewModel)
        {
            _logger.LogInformation("Process Payment Async controller");
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                BankTransaction bankTransaction = CreateTransactionViewModelToBankTransaction(createTransactionViewModel);

                return Ok(await _bankTransactionService.ProcessPayment(bankTransaction));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private BankTransaction CreateTransactionViewModelToBankTransaction(CreateTransactionViewModel createTransactionViewModel)
        {
            return new BankTransaction
            {
                DateProcessed = DateTime.UtcNow,
                KeyType = createTransactionViewModel.KeyType,
                Payee = new AccountHolder { ValueKey = createTransactionViewModel.PayeeKey },
                Sender = new AccountHolder { ValueKey = createTransactionViewModel.SenderKey },
                Value = createTransactionViewModel.Value,
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentAsync(string key)
        {
            return Ok();
        }
    }
}
