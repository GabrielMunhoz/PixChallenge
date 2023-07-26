﻿using Microsoft.Extensions.Logging;
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
                if (!IsValidPayment(transaction))
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

            if (transaction.SenderId == Guid.Empty)
                return false;

            return true;
        }

        private async Task<bool> IsValidAccountHolders(BankTransaction transaction)
        {
            AccountHolder sender = await _accountHolderRepository
                .GetAsync(x => x.Id == transaction.SenderId);

            if (sender == null)
                return false;

            if (transaction.PayeeKey == sender.ValueKey)
                return false;

            return true;

        }

        public Task<List<BankTransaction>> GetByKeyAsync(string key)
        {
            try
            {
                return Task.FromResult(_bankTransactionRepository
                    .Query(x => x.PayeeKey.Equals(key), x => x.Sender)
                    .ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
