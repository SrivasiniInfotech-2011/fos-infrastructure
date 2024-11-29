using FluentValidation;
using FOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Infrastructure.Validators
{
    public class LeadProspectiveDetailsValidator:AbstractValidator<LeadProspectDetail>
    {
        public LeadProspectiveDetailsValidator()
        {
            
        }
    }
}
