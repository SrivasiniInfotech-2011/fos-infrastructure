using FluentValidation;
using FOS.Models.Constants;
using FOS.Models.Requests;

namespace FOS.Infrastructure.Validators
{
    public class BranchLocationRequestValidator : AbstractValidator<BranchLocationRequest>
    {
        public BranchLocationRequestValidator()
        {
            RuleFor(e => e.UserId)
           .NotNull()
           .GreaterThan(0)
           .WithMessage(Constants.Messages.USER_ID_EMPTY);

            RuleFor(e => e.CompanyId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage(Constants.Messages.COMPANY_ID_EMPTY);

            RuleFor(e => e.LobId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage(Constants.Messages.LOB_ID_EMPTY);
        }
    }
}
