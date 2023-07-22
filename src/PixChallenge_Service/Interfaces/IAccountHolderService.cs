using PixChallenge_Core.Entities;

namespace PixChallenge_Application.Interfaces
{
    public interface IAccountHolderService
    {
        Task<AccountHolder> CreateAsync(AccountHolder accountHolder);
    }
}
