using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.DataTransferObjects
{
    public class CreateLoanRequest
    {
        public string ApplicantName { get; set; }
        public decimal Amount { get; set; }
    }
}
