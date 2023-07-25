using Microsoft.EntityFrameworkCore;
using PixChallenge_Data.Extensions;
using PixChallenge_Data.Mappings;

namespace PixChallenge_Data.Context
{
    public class PixChallengeContext : DbContext
    {
        public PixChallengeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountHolderMap());
            modelBuilder.ApplyConfiguration(new BankTransactionMap());

            modelBuilder.ApplyGlobalConfigurations();
            base.OnModelCreating(modelBuilder);
        }
    }
}
