using Loans.Cross.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.Interfaces
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDto>> GetAllAsync();
        Task<LoanDto?> GetByIdAsync(Guid id);
        Task<LoanDto> CreateAsync(CreateLoanRequest request);
        Task<bool> MakePaymentAsync(PaymentRequest request);
    }
}
