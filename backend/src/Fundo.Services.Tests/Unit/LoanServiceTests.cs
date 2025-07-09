using AutoMapper;
using Loans.Cross.DataTransferObjects;
using Loans.Cross.Interfaces;
using Loans.Cross.Services;
using Loans.Domain.Entities;
using Loans.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Unit
{
    public class LoanServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly IMapper _mapper;

        public LoanServiceTests()
        {
            Mock<ILoggerFactory> mockLogger = new Mock<ILoggerFactory>();
            mockLogger.Setup(f => f.CreateLogger(It.IsAny<string>()))
                .Returns(new Mock<ILogger>().Object);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateLoanRequest, Loan>();
                cfg.CreateMap<Loan, LoanDto>();
            },mockLogger.Object);
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddLoanAndReturnDto()
        {
            // Arrange
            var request = new CreateLoanRequest { ApplicantName = "Ana", Amount = 1000 };
            var repoMock = new Mock<ILoanRepository>();
            _unitOfWorkMock.Setup(u => u.Loans).Returns(repoMock.Object);

            var service = new LoanService(_unitOfWorkMock.Object, _mapper);

            // Act
            var result = await service.CreateAsync(request);

            // Assert
            Assert.Equal("Ana", result.ApplicantName);
            Assert.Equal(1000, result.Amount);
            _unitOfWorkMock.Verify(u => u.CompleteChangesAsync(), Times.Once);
        }
    }
}
