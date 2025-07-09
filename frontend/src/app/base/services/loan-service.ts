import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoanDto } from '../model/dto/Loan';
import { CreateLoanRequest } from '../model/dto/CreateLoanRequest';
import { environment } from '../../../environment';
import { LoanPaymentRequest } from '../model/dto/PaymentRequest';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
   private apiUrl = `${environment.apiUrl}/loans`;
 constructor(private http: HttpClient) {}

  getAll(): Observable<LoanDto[]> {
    return this.http.get<LoanDto[]>(this.apiUrl);
  }

  getById(id: string): Observable<LoanDto> {
    return this.http.get<LoanDto>(`${this.apiUrl}/${id}`);
  }

  create(request: CreateLoanRequest): Observable<LoanDto> {
    return this.http.post<LoanDto>(this.apiUrl, request);
  }

  makePayment(request: LoanPaymentRequest): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/pay`, request);
  }

}
