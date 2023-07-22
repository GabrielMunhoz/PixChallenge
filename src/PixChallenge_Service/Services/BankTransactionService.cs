using Microsoft.Extensions.Logging;
using PixChallenge_Application.Interfaces;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Interfaces;

namespace PixChallenge_Application.Services
{
    public class BankTransactionService: IBankTransactionService
    {
        private readonly IBankTransactionRepository _bankTransactionRepository;
        private readonly IAccountHolderRepository _accountHolderRepository;
        private readonly ILogger<BankTransactionService> _logger;

        public BankTransactionService(IBankTransactionRepository bankTransactionRepository, IAccountHolderRepository accountHolderRepository,ILogger<BankTransactionService> logger)
        {
            _bankTransactionRepository = bankTransactionRepository;
            _accountHolderRepository = accountHolderRepository;
            _logger = logger;
        }
        public async Task<BankTransaction> ProcessPayment(BankTransaction transaction)
        {
            try
            {
                //Validate if data are valid
                if (IsValidPayment(transaction))
                    return await Task.FromResult(new BankTransaction());

                if (!(await IsValidAccountHolders(transaction)))
                    return await Task.FromResult(new BankTransaction());

                return await _bankTransactionRepository.CreateAsync(transaction);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private bool IsValidPayment(BankTransaction transaction)
        {
            if(transaction.Value <= Decimal.MinValue) 
                return false;
            
            if(transaction.Payee.ValueKey == transaction.Sender.ValueKey)
                return false;

            return true;
        }

        private async Task<bool> IsValidAccountHolders(BankTransaction transaction)
        {
            transaction.Payee = await _accountHolderRepository
                .GetAsync(x => x.ValueKey == transaction.Payee.ValueKey);

            transaction.Sender = await _accountHolderRepository
                .GetAsync(x => x.ValueKey == transaction.Sender.ValueKey);

            if (transaction.Payee.Id != Guid.Empty && transaction.Sender.Id != Guid.Empty)
                return true; 

            return false;

        }

        Task<BankTransaction> IBankTransactionService.GetByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
