using Loans.BackendInfrastructure.DataAccess;
using Loans.Domain.Entities;
using Loans.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Loans.BackendInfrastructure.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(Guid id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
