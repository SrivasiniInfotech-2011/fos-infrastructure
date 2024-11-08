using FluentValidation;
using FOS.Models.Constants;
using FOS.Models.Entities;

namespace FOS.Infrastructure.Validators
{
    public class ProspectValidator : AbstractValidator<Prospect?>
    {
        public ProspectValidator()
        {
            RuleFor(e => e!.CompanyId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage(Constants.Messages.COMPANY_ID_EMPTY);

            RuleFor(e => e!.ProspectDate)
           .NotNull()
           .WithMessage(Constants.Messages.PROSPECT_DATE_EMPTY);

            RuleFor(e => e!.CustomerId)
           .NotNull()
           .GreaterThan(0)
           .WithMessage(Constants.Messages.CUSTOMER_ID_EMPTY);

            RuleFor(e => e!.ProspectTypeId)
           .NotNull()
           .GreaterThan(0)
           .WithMessage(Constants.Messages.PROSPECT_TYPE_ID_EMPTY);

            RuleFor(e => e!.ProspectName)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.PROSPECT_NAME_EMPTY);

            RuleFor(e => e!.MobileNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.MOBILE_NUMBER_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.AddressLine1)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.COMMS_ADDRESSLINE1_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.AddressLine2)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.COMMS_ADDRESSLINE2_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.Landmark)
           .NotNull()
           .NotEmpty()
           .WithMessage(Constants.Messages.COMMS_LANDMARK_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.City)
           .NotNull()
           .NotEmpty()
           .WithMessage(Constants.Messages.COMMS_CITY_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.StateId)
            .NotNull()
            .WithMessage(Constants.Messages.COMMS_STATE_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.CountryId)
            .NotNull()
            .WithMessage(Constants.Messages.COMMS_COUNTRY_EMPTY);

            RuleFor(e => e!.CommunicationAddress!.Pincode)
            .NotNull()
            .WithMessage(Constants.Messages.COMMS_PINCODE_EMPTY);

            RuleFor(e => e!.PermanentAddress!.AddressLine1)
           .NotNull()
           .NotEmpty()
           .WithMessage(Constants.Messages.PERMS_ADDRESSLINE1_EMPTY);

            RuleFor(e => e!.PermanentAddress!.AddressLine2)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.PERMS_ADDRESSLINE2_EMPTY);

            RuleFor(e => e!.PermanentAddress!.Landmark)
           .NotNull()
           .NotEmpty()
           .WithMessage(Constants.Messages.PERMS_LANDMARK_EMPTY);

            RuleFor(e => e!.PermanentAddress!.City)
           .NotNull()
           .NotEmpty()
           .WithMessage(Constants.Messages.PERMS_CITY_EMPTY);

            RuleFor(e => e!.PermanentAddress!.StateId)
            .NotNull()
            .WithMessage(Constants.Messages.PERMS_STATE_EMPTY);

            RuleFor(e => e!.PermanentAddress!.CountryId)
            .NotNull()
            .WithMessage(Constants.Messages.COMMS_COUNTRY_EMPTY);

            RuleFor(e => e!.PermanentAddress!.Pincode)
            .NotNull()
            .WithMessage(Constants.Messages.PERMS_PINCODE_EMPTY);

            RuleFor(e => e!.PanNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.PAN_EMPTY);

            RuleFor(e => e!.PanNumberImagePath)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.PAN_IMAGE_EMPTY);

            RuleFor(e => e!.ProspectImagePath)
            .NotNull()
            .NotEmpty()
            .WithMessage(Constants.Messages.PROSPECT_IMAGE_EMPTY);
        }
    }
}
