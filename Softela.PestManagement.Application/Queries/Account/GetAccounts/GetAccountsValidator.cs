using FluentValidation;

namespace Softela.PestManagement.Application.Queries.Account.GetAccounts
{
    public class GetAccountsValidator : AbstractValidator<GetAccountsRequest>
    {
        public GetAccountsValidator()
        {
            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .WithMessage("Company ID must be greater than 0");
        }
    }
}
