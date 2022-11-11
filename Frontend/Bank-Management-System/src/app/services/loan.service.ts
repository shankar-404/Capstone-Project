import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  private baseUrl: string = "https://localhost:7281"
  constructor(private http: HttpClient) { }

  apply(loanObj:any){
    return this.http.post<any>(`${this.baseUrl}/ApplyLoan`, loanObj)
  }
}
