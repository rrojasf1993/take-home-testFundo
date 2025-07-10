using Loans.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ILoanRepository Loans { get; }
        Task<int> CompleteChangesAsync();
    }
}
