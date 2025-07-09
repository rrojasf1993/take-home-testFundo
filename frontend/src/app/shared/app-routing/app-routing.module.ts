import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LoanListComponent } from '../../features/loans/loan-list/loan-list.component';
import { NewLoanComponent } from '../../features/loans/new-loan/new-loan.component';
import { LoanDetailComponent } from '../../features/loans/loan-detail/loan-detail.component';


const routes: Routes = [
  { path: '', redirectTo: 'loans', pathMatch: 'full' },
  { path: 'loans', component: LoanListComponent },
  { path: 'loans/new', component: NewLoanComponent },
  { path: 'loans/:id', component: LoanDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
