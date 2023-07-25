using PixChallenge_Core.Enums;

namespace PixChallenge_Core.Entities
{
    public class BankTransaction : BaseEntity
    {

        public KeyType KeyType { get; set; }
        public decimal Value { get; set; }
        public DateTime DateProcessed { get; set; }

        public virtual Guid PayeeId { get; set; }
        public AccountHolder Payee { get; set; }

        public virtual Guid SenderId { get; set; }
        public AccountHolder Sender { get; set; }

    }
}
