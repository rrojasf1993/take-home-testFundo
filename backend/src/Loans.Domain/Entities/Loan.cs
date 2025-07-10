using Loans.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Active;
        public void MakePayment(decimal amount)
        {
            if (amount <= 0 || amount > CurrentBalance)
                throw new InvalidOperationException("Invalid payment amount.");

            CurrentBalance -= amount;
            if (CurrentBalance == 0)
                Status = LoanStatus.Paid;
        }
    }
}
