using Microsoft.EntityFrameworkCore;

namespace PixChallenge_Data.Context
{
    public class PixChallengeContext : DbContext
    {
        public PixChallengeContext(DbContextOptions options) : base(options)
        {
        }
    }
}
