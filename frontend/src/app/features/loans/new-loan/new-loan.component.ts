import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoanService } from '../../../base/services/loan-service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MaterialModuleModule } from '../../../shared/material-module/material-module.module';

@Component({
  selector: 'app-new-loan',
  //imports: [MaterialModuleModule],
  templateUrl: './new-loan.component.html',
  styleUrl: './new-loan.component.scss',
   standalone: false
})

export class NewLoanComponent {
  form!: FormGroup;
  loading = false;

  constructor(
    private fb: FormBuilder,
    private loanService: LoanService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      applicantName: ['', [Validators.required, Validators.maxLength(100)]],
      amount: [null, [Validators.required, Validators.min(1)]]
    });
  }

  submit(): void {
    if (this.form.invalid) return;

    this.loading = true;
    this.loanService.create(this.form.value).subscribe({
      next: (loan) => {
        this.snackBar.open('a loan was succesfully created ', 'close', { duration: 3000 });
        this.form.reset();
        this.loading = false;
      },
      error: () => {
        this.snackBar.open('Error creating a loan', 'close', { duration: 5000, panelClass: ['snackbar-error'] });
        this.loading = false;
      }
    });
  }
}
