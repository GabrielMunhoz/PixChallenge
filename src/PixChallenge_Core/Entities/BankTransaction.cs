using PixChallenge_Core.Enums;

namespace PixChallenge_Core.Entities
{
    public class BankTransaction : BaseEntity
    {

        public KeyType KeyType { get; set; }
        public string PayeeKey { get; set; }
        public decimal Value { get; set; }
        public DateTime DateProcessed { get; set; }

        public Guid SenderId { get; set; }
        public virtual AccountHolder Sender {get;set;}
    }
}
