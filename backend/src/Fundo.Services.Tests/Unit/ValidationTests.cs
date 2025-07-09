using FluentValidation.TestHelper;
using Loans.Cross.DataTransferObjects;
using Loans.Cross.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Unit
{
    public class ValidationTests
    {
        private readonly CreateLoanRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_ApplicantName_Is_Empty()
        {
            var result = _validator.TestValidate(new CreateLoanRequest { ApplicantName = "", Amount = 100 });
            result.ShouldHaveValidationErrorFor(x => x.ApplicantName);
        }

        [Fact]
        public void Should_Have_Error_When_Amount_Is_Zero()
        {
            var result = _validator.TestValidate(new CreateLoanRequest { ApplicantName = "Luis", Amount = 0 });
            result.ShouldHaveValidationErrorFor(x => x.Amount);
        }

        [Fact]
        public void Should_Pass_When_Valid()
        {
            var result = _validator.TestValidate(new CreateLoanRequest { ApplicantName = "Luis", Amount = 500 });
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
