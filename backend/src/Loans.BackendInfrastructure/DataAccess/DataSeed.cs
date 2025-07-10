using Loans.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.BackendInfrastructure.DataAccess
{
    public static class DataSeed
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Loans.Any())
            {
                context.Loans.AddRange(
                    new Loan { Id = Guid.NewGuid(), ApplicantName = "Alice", Amount = 1000, CurrentBalance = 1000 },
                    new Loan { Id = Guid.NewGuid(), ApplicantName = "Bob", Amount = 500, CurrentBalance = 200 },
                    new Loan { Id = Guid.NewGuid(), ApplicantName = "Jon doe", Amount = 500, CurrentBalance = 200 },
                    new Loan { Id = Guid.NewGuid(), ApplicantName = "Someone", Amount = 500, CurrentBalance = 200 }
                );
                context.SaveChanges();
            }
        }
    }
}
