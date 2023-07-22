using PixChallenge_Application.Interfaces;
using PixChallenge_Core.Entities;

namespace PixChallenge_Application.Services
{
    public class BankTransactionService: IBankTransactionService
    {
        public Task<BankTransaction> ProcessPayment(BankTransaction transaction)
        {
            throw new NotImplementedException();
        }

        Task<BankTransaction> IBankTransactionService.GetByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
