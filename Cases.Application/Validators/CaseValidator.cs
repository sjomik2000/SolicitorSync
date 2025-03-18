using Cases.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Cases.Application.Models;

namespace Cases.Application.Validators
{
    public class CaseValidator : AbstractValidator<Case>
    {

        public CaseValidator()
        {
            RuleFor(x => x.case_name).NotEmpty();
            RuleFor(x => x.client_name).NotEmpty();
            RuleFor(x => x.case_type).NotEmpty();
            RuleFor(x => x.case_state).NotEmpty();
            RuleFor(x => x.case_description).NotEmpty();

        }

    }
}
