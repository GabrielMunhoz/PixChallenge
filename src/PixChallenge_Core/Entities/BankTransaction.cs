using PixChallenge_Core.Enums;

namespace PixChallenge_Core.Entities
{
    public class BankTransaction
    {
        public Guid Id { get; set; }
        public AccountHolder Sender { get; set; }
        public AccountHolder Payee { get; set; }
        public KeyType KeyType { get; set; }
        public decimal Value { get; set; }
        public DateTime DateProcessed { get; set; }

    }
}
