using FluentValidation;
using FOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.Infrastructure.Validators
{
    public class LeadHeaderValidator:AbstractValidator<LeadHeader>
    {
        public LeadHeaderValidator()
        {
            
        }
    }
}
