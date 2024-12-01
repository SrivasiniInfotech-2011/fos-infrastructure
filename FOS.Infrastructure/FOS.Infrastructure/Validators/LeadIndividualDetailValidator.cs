using FluentValidation;
using FOS.Models.Constants;
using FOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Infrastructure.Validators
{
    public class LeadIndividualDetailValidator : AbstractValidator<LeadIndividualDetail>
    {
        public LeadIndividualDetailValidator()
        {
           // RuleFor(e => e.UserId)
           //.NotNull()
           //.GreaterThan(0)
           //.WithMessage(Constants.Messages.USER_ID_EMPTY);

           // RuleFor(e => e.CompanyId)
           // .NotNull()
           // .GreaterThan(0)
           // .WithMessage(Constants.Messages.COMPANY_ID_EMPTY);

           // RuleFor(e => e.MobileNumber)
           // .NotNull()
           // .NotEmpty()
           // .WithMessage(Constants.Messages.MOBILE_NUMBER_EMPTY);

           // RuleFor(e => e)
           // .Must(s => !string.IsNullOrEmpty(s.AadharNumber) || !string.IsNullOrEmpty(s.PanNumber))
           // .WithMessage(Constants.Messages.AAADHAR_AND_PAN_EMPTY);
        }
    }
}
