using Loans.BackendInfrastructure.DataAccess;
using Loans.BackendInfrastructure.Repository;
using Loans.Cross.Interfaces;
using Loans.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.BackendInfrastructure.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ILoanRepository Loans { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Loans = new LoanRepository(context);
        }

      

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> CompleteChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
