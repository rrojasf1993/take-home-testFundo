using Loans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> GetByIdAsync(Guid id);
        Task<List<Loan>> GetAllAsync();
        Task AddAsync(Loan loan);
        Task SaveChangesAsync();
    }
}
