import { Component, OnInit } from '@angular/core';
import { MaterialModuleModule } from '../../../shared/material-module/material-module.module';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { LoanService } from '../../../base/services/loan-service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoanDto } from '../../../base/model/dto/Loan';
import { CommonModule } from '@angular/common';
import { LoanPaymentRequest } from '../../../base/model/dto/PaymentRequest';

@Component({
  selector: 'app-loan-detail',
  imports: [MaterialModuleModule, CommonModule, ReactiveFormsModule],
  templateUrl: './loan-detail.component.html',
  styleUrl: './loan-detail.component.scss'
})
export class LoanDetailComponent implements OnInit {
  paymentForm!: FormGroup;
  currentLoan: LoanDto = {} as LoanDto;
  loading = true;

  constructor(
    private route: ActivatedRoute,
    private loanService: LoanService,
    private snackBar: MatSnackBar,
    private fb: FormBuilder
  ) { }
  ngOnInit(): void {
    console.log("Begin geting details from loan");
    this.paymentForm = this.fb.group({
      amount: [null, [Validators.required, Validators.min(1)]]
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loanService.getById(id).subscribe({
        next: (data) => {
          this.currentLoan = data;
          this.loading = false;
        },
        error: () => {
          this.snackBar.open('The loan detail could not be loaded', 'Close', { duration: 4000 });
          this.loading = false;
        }
      });
    }
  }

  payLoanInstatement() {
    if (!this.currentLoan) return;

    const request: LoanPaymentRequest = {
      loanId: this.currentLoan.id,
      amount: this.paymentForm.value.amount
    };

    this.loading = true;
    this.loanService.makePayment(request).subscribe({
      next: () => {
        this.snackBar.open('Payment sucesfull', 'close', { duration: 4000 });
        this.currentLoan!.currentBalance -= request.amount;
        this.paymentForm.reset();
        this.loading = false;
      },
      error: () => {
        this.snackBar.open('Error processing the payment', 'close', { duration: 4000 });
        this.loading = false;
      }
    });
  }
}
