using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.DataTransferObjects
{
    public class LoanDto
    {
        public Guid Id { get; set; }
        public string ApplicantName { get; set; } 
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Status { get; set; } 
    }
}
