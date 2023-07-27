using Microsoft.AspNetCore.Mvc;
using PixChallenge_Api.ViewModels;
using PixChallenge_Application.Interfaces;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Enums;

namespace PixChallenge_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountHolderController : ControllerBase
    {
        private readonly IAccountHolderService _accountHolderService;
        private readonly ILogger<AccountHolderController> _logger;

        public AccountHolderController(IAccountHolderService accountHolderService, ILogger<AccountHolderController> logger)
        {
            _accountHolderService = accountHolderService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccountHolder(CreateAccountHolderViewModel createAccountHolderViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                AccountHolder accountHolder = CreateAccountHolderViewModelToAccountHolder(createAccountHolderViewModel);

                return Ok(await _accountHolderService.CreateAsync(accountHolder));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private static AccountHolder CreateAccountHolderViewModelToAccountHolder(CreateAccountHolderViewModel createAccountHolder)
        {
            return new AccountHolder
            {
                KeyType = (KeyType)Enum.Parse(typeof(KeyType), createAccountHolder.KeyType.ToUpper()),
                Name = createAccountHolder.Name,
                ValueKey = createAccountHolder.ValueKey,
            };
        }
    }
}
