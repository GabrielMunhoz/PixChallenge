using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixChallenge_Core.Entities;

namespace PixChallenge_Data.Mappings
{
    public class AccountHolderMap : IEntityTypeConfiguration<AccountHolder>
    {
        public void Configure(EntityTypeBuilder<AccountHolder> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValueKey).IsRequired();
            builder.Property(x => x.KeyType).IsRequired();

        }
    }
}
