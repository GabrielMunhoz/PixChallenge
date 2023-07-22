using PixChallenge_Core.Entities;

namespace PixChallenge_Application.Interfaces
{
    public interface IBankTransactionService
    {
        Task<BankTransaction> ProcessPayment(BankTransaction transaction);
        Task<BankTransaction> GetByKeyAsync(string key); 
    }
}
