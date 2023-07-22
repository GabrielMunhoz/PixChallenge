using PixChallenge_Data.Context;
using PixChallenge_Data.Repository.Base;

namespace PixChallenge_Data.Repository
{
    public class BankTransactionRepository : BaseRepository<PixChallenge_Core.Entities.BankTransaction>
    {
        public BankTransactionRepository(PixChallengeContext context) : base(context)
        {
        }
    }
}
