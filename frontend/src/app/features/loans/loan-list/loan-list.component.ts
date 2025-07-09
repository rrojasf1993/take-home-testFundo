import { Component, OnInit } from '@angular/core';
import { LoanService } from '../../../base/services/loan-service';
import { LoanDto } from '../../../base/model/dto/Loan';
import { MaterialModuleModule } from '../../../shared/material-module/material-module.module';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-loan-list',
  //imports: [MaterialModuleModule],
  templateUrl: './loan-list.component.html',
  styleUrl: './loan-list.component.scss',
  standalone: false
})
export class LoanListComponent implements OnInit {
  loanService: LoanService;
  snackBar: MatSnackBar;
  currentLoans: Array<LoanDto> = [];
  displayedColumns: string[] = ['applicantName', 'amount', 'currentBalance', 'status','actions'];
  loading: boolean = false;

  constructor(loanServiceInstance: LoanService, snackBarInstance: MatSnackBar) {
    this.loanService = loanServiceInstance;
    this.snackBar = snackBarInstance;
  }
  ngOnInit(): void {
    console.log("Begin getting loans from web api")
    //throw new Error('Method not implemented.');
    this.getAllLoans();
  }

  getAllLoans() {
    let loansObservable = this.loanService.getAll();
    loansObservable.subscribe({
      next: (data) => {
        this.currentLoans = data;
        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
        this.snackBar.open('Error loading loans. Try again.', 'Close', {
          duration: 5000,
          panelClass: ['snackbar-error']
        });
      }
    });
  }
}