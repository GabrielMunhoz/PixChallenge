using PixChallenge_Core.Enums;

namespace PixChallenge_Core.Entities
{
    public class AccountHolder : BaseEntity
    {
        public string? Name { get; set; }
        public KeyType KeyType { get; set; }
        public string ValueKey { get; set; }
    }
}
