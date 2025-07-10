using AutoMapper;
using Loans.Cross.DataTransferObjects;
using Loans.Cross.Interfaces;
using Loans.Domain.Entities;
using Loans.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Cross.Services
{
    public class LoanService:ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> GetAllAsync()
        {
            var loans = await _unitOfWork.Loans.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }

        public async Task<LoanDto?> GetByIdAsync(Guid id)
        {
            var loan = await _unitOfWork.Loans.GetByIdAsync(id);
            return loan == null ? null : _mapper.Map<LoanDto>(loan);
        }

        public async Task<LoanDto> CreateAsync(CreateLoanRequest request)
        {
            var loan = _mapper.Map<Loan>(request);
            loan.Id = Guid.NewGuid();
            loan.CurrentBalance = loan.Amount;
            loan.Status = LoanStatus.Active;

            await _unitOfWork.Loans.AddAsync(loan);
            await _unitOfWork.CompleteChangesAsync();

            return _mapper.Map<LoanDto>(loan);
        }

        public async Task<bool> MakePaymentAsync(PaymentRequest request)
        {
            var loan = await _unitOfWork.Loans.GetByIdAsync(request.LoanId);
            if (loan == null) return false;

            loan.MakePayment(request.Amount);
            await _unitOfWork.CompleteChangesAsync();
            return true;
        }
    }
}
