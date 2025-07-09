using AutoMapper;
using Loans.Cross.DataTransferObjects;
using Loans.Cross.Interfaces;
using Loans.Domain.Entities;
using Loans.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fundo.Applications.WebApi.Controllers
{
    [Route("/loans")]
    public class LoanManagementController : Controller
    {
        private readonly ILoanService _loanService;

        public LoanManagementController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetAll()
        {
            var loans = await _loanService.GetAllAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetById(Guid id)
        {
            var loan = await _loanService.GetByIdAsync(id);
            if (loan == null) return NotFound();

            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDto>> Create([FromBody] CreateLoanRequest request)
        {
            var loan = await _loanService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
        }

        [HttpPost("pay")]
        public async Task<IActionResult> MakePayment([FromBody] PaymentRequest request)
        {
            var success = await _loanService.MakePaymentAsync(request);
            return success ? NoContent() : NotFound();

        }
    }
}
