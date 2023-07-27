using FluentValidation;
using Microsoft.Extensions.Logging;
using PixChallenge_Application.Interfaces;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Interfaces;
using PixChallenge_Rules.Validations;

namespace PixChallenge_Application.Services
{
    public class AccountHolderService : IAccountHolderService
    {
        private readonly IAccountHolderRepository _accountHolderRepository;
        private readonly ILogger<AccountHolderService> _logger;

        public AccountHolderService(IAccountHolderRepository accountHolderRepository, ILogger<AccountHolderService> logger)
        {
            _accountHolderRepository = accountHolderRepository;
            _logger = logger;
        }
        public async Task<AccountHolder> CreateAsync(AccountHolder accountHolder)
        {
            _logger.LogInformation("CreateAsync Service");

            try
            {
                AccountHolderValidator validations = new AccountHolderValidator();

                await validations.ValidateAndThrowAsync(accountHolder);

                return await _accountHolderRepository.CreateAsync(accountHolder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message); 
                throw;
            }
        }
    }
}
