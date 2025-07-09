using Fundo.Applications.WebApi.Controllers;
using Loans.Cross.DataTransferObjects;
using Loans.Cross.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Integration.Fundo.Applications.WebApi.Controllers
{
    public class LoansControllerTests
    {
        private readonly Mock<ILoanService> _loanServiceMock = new();
        private readonly LoanManagementController _controller;

        public LoansControllerTests()
        {
            _controller = new LoanManagementController(_loanServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithLoans()
        {
            var loans = new List<LoanDto> { new() { ApplicantName = "Carlos", Amount = 1000 } };
            _loanServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(loans);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLoans = Assert.IsAssignableFrom<IEnumerable<LoanDto>>(okResult.Value);
            Assert.Single(returnedLoans);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAt()
        {
            var request = new CreateLoanRequest { ApplicantName = "Laura", Amount = 800 };
            var dto = new LoanDto { Id = Guid.NewGuid(), ApplicantName = "Laura", Amount = 800 };

            _loanServiceMock.Setup(s => s.CreateAsync(request)).ReturnsAsync(dto);

            var result = await _controller.Create(request);

            var created = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("Laura", ((LoanDto)created.Value!).ApplicantName);

        }
    }
}
