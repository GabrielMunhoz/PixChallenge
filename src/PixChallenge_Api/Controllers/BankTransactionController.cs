using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PixChallenge_Api.ViewModels.BankTransaction;
using PixChallenge_Application.Interfaces;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Enums;
using System.Text.Json.Serialization;
using System.Text.Json;

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
                KeyType = (KeyType)Enum.Parse(typeof(KeyType), createTransactionViewModel.KeyType),
                PayeeKey = createTransactionViewModel.PayeeKey,
                SenderId = Guid.Parse(createTransactionViewModel.SenderId),
                Value = createTransactionViewModel.Value,
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentAsync(string key)
        {
            try
            {
                return Ok(await _bankTransactionService.GetByKeyAsync(key));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
