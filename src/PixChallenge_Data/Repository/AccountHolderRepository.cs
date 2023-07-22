using PixChallenge_Core.Entities;
using PixChallenge_Data.Context;
using PixChallenge_Data.Repository.Base;

namespace PixChallenge_Data.Repository
{
    public class AccountHolderRepository : BaseRepository<AccountHolder>
    {
        public AccountHolderRepository(PixChallengeContext context) : base(context)
        {
        }
    }
}
