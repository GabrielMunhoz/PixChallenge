using PixChallenge_Core.Enums;

namespace PixChallenge_Core.Entities
{
    public class AccountHolder
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public KeyType KeyType { get; set; }

    }
}
