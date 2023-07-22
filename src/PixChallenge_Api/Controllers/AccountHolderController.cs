using Microsoft.AspNetCore.Mvc;
using PixChallenge_Application.Interfaces;

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
        public async Task<IActionResult> CreateAccountHolder()
        {
            return Ok();
        }
    }
}
