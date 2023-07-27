using FluentValidation;
using PixChallenge_Core.Entities;
using System.Transactions;

namespace PixChallenge_Rules.BankTransactionRules
{
    public class BankTransactionValidator : AbstractValidator<BankTransaction>
    {
        public BankTransactionValidator()
        {
            RuleFor(b => b.SenderId).NotNull().NotEmpty();
            RuleFor(b => b.DateProcessed).NotNull();
            RuleFor(b => b.PayeeKey).NotEmpty().NotNull();

            RuleFor(b => b.Value)
                .Must(x => x > decimal.MinValue)
                .WithMessage("Value must be more than 0.");
            RuleFor(b => b.SenderId)
                .Must(x => x != Guid.Empty)
                .WithMessage("SenderId is required.");
        }
    }
}
