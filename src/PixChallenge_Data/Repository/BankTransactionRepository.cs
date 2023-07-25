using PixChallenge_Core.Interfaces;
using PixChallenge_Data.Context;
using PixChallenge_Data.Repository.Base;

namespace PixChallenge_Data.Repository
{
    public class BankTransactionRepository : BaseRepository<PixChallenge_Core.Entities.BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(PixChallengeContext context) : base(context)
        {
        }
    }
}
