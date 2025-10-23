using FluentValidation;

namespace Softela.PestManagement.Application.Commands.Account.UpdateAccount
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Account ID must be greater than 0");

            RuleFor(x => x.AccountNum)
                .NotEmpty()
                .WithMessage("Account number is required")
                .MaximumLength(50)
                .WithMessage("Account number must not exceed 50 characters");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Account name is required")
                .MaximumLength(100)
                .WithMessage("Account name must not exceed 100 characters");

            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .WithMessage("Company ID must be greater than 0");
        }
    }
}
