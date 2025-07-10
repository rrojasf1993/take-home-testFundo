using Loans.Domain.Entities;
using Loans.Domain.Enums;
using System;
using Xunit;
namespace Fundo.Services.Tests.Unit
{
    public class LoanTests
    {
        [Fact]
        public void MakePayment_ShouldReduceBalance_WhenAmountIsValid()
        {
            // Arrange
            var loan = new Loan
            {
                Id = Guid.NewGuid(),
                ApplicantName = "Bob",
                Amount = 500,
                CurrentBalance = 200,
                Status = LoanStatus.Active
            };

            // Act
            loan.MakePayment(50);

            // Assert
            Assert.Equal(150, loan.CurrentBalance);
        }

        [Fact]
        public void MakePayment_ShouldThrow_WhenAmountIsNegative()
        {
            //a  comment
            var loan = new Loan { CurrentBalance = 200, Status = LoanStatus.Active };

            var ex = Assert.Throws<InvalidOperationException>(() => loan.MakePayment(-10));
            Assert.Equal("Invalid payment amount.", ex.Message);
        }

        [Fact]
        public void MakePayment_ShouldThrow_WhenAmountExceedsBalance()
        {
            var loan = new Loan { CurrentBalance = 100, Status = LoanStatus.Active };

            var ex = Assert.Throws<InvalidOperationException>(() => loan.MakePayment(150));
            Assert.Equal("Invalid payment amount.", ex.Message);
        }

      
    }
}
