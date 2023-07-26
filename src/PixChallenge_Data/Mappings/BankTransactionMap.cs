using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixChallenge_Core.Entities;

namespace PixChallenge_Data.Mappings
{
    public class BankTransactionMap : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(b => b.Sender)
                .WithMany()
                .HasForeignKey(b => b.SenderId);
        }
    }
}
