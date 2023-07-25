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
            builder.HasOne(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Payee).WithMany().HasForeignKey(x => x.PayeeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
