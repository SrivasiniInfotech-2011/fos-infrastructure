using FluentValidation;
using FOS.Models.Constants;
using FOS.Models.Requests;

namespace FOS.Infrastructure.Validators
{
    public class GetProspectDetailsRequestValidator : AbstractValidator<GetProspectDetailsRequest>
    {
        public GetProspectDetailsRequestValidator()
        {
            RuleFor(e => e.UserId)
           .NotNull()
           .GreaterThan(0)
           .WithMessage(Constants.Messages.USER_ID_EMPTY);

            RuleFor(e => e.CompanyId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage(Constants.Messages.COMPANY_ID_EMPTY);

            RuleFor(e => e.MobileNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.MOBILE_NUMBER_EMPTY);

            RuleFor(e => e)
            .Must(s => !string.IsNullOrEmpty(s.AadharNumber) || !string.IsNullOrEmpty(s.PanNumber))
            .WithMessage(Constants.Messages.AAADHAR_AND_PAN_EMPTY);
        }
    }
}
