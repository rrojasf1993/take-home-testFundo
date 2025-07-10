using FluentValidation;
using Loans.Cross.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.Validation
{
    public class CreateLoanRequestValidator : AbstractValidator<CreateLoanRequest>
    {
        public CreateLoanRequestValidator()
        {
            RuleFor(x => x.ApplicantName)
    .NotEmpty().WithMessage("The solicitant name is mandatory")
    .MaximumLength(100);

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("The amount to pay bust be greater than zero.");

        }
    }
}

