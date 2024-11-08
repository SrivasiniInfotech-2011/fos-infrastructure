using FluentValidation;
using FOS.Models.Constants;
using FOS.Models.Entities;
using FOS.Models.Requests;

namespace FOS.Infrastructure.Validators
{
    public class CreateProspectRequestValidator : AbstractValidator<CreateProspectRequestModel>
    {
        public CreateProspectRequestValidator()
        {
            RuleFor(e => e.UserId)
           .NotNull()
           .GreaterThan(0)
           .WithMessage(Constants.Messages.USER_ID_EMPTY);

            RuleFor(e => e.Prospect)
            .NotNull()
            .WithMessage(Constants.Messages.CREATE_PROSPECT_EMPTY);

            RuleFor(e => e.Prospect)
            .NotNull()
            .SetValidator(new ProspectValidator());
        }
    }
}
