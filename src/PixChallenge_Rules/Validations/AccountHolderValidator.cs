using FluentValidation;
using PixChallenge_Core.Entities;
using PixChallenge_Core.Enums;

namespace PixChallenge_Rules.Validations
{
    public class AccountHolderValidator : AbstractValidator<AccountHolder>
    {
        public AccountHolderValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.KeyType).IsInEnum();
            RuleFor(x => x.ValueKey).NotEmpty();
        }
    }
}
