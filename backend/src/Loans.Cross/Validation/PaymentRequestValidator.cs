using FluentValidation;
using Loans.Cross.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.Validation
{
    public class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.LoanId)
            .NotEmpty().WithMessage("The loan Id is mandatory.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("The loan payment amount must be greater than 0");
        }

    }
}


