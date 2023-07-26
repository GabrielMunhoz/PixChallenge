using PixChallenge_Core.Entities;

namespace PixChallenge_Application.Interfaces
{
    public interface IBankTransactionService
    {
        Task<BankTransaction> ProcessPayment(BankTransaction transaction);
        Task<List<BankTransaction>> GetByKeyAsync(string key); 
    }
}
