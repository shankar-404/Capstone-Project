import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {

  private baseUrl: string = "https://localhost:7281/api"
  constructor(private http: HttpClient) { }

  withdraw(withdrawObj:any) {
    // console.log("Req:", withdrawObj)
    return this.http.post<any>(`${this.baseUrl}/Transaction/withdraw`, withdrawObj)
  }

  deposit(depositObj:any) {
    // console.log("Req:", depositObj)
    return this.http.post<any>(`${this.baseUrl}/Transaction/deposit`, depositObj)
  }

  view(viewObj:any){

    console.log(viewObj.startDate)
    let start = viewObj.startDate.day + '-' + viewObj.startDate.month + '-' + viewObj.startDate.year
    let end = viewObj.endDate.day + '-' + viewObj.endDate.month + '-' + viewObj.endDate.year
    
    if(viewObj.transactionType == "Withdraw"){
      return this.http.get<any>(`${this.baseUrl}/Transaction/transactionsFilter/${viewObj.customerId}/${start}/${end}/WITHDRAW`)
    }
    else{
      return this.http.get<any>(`${this.baseUrl}/Transaction/transactionsFilter/${viewObj.customerId}/${start}/${end}/DEPOSIT`)

    }
    // console.log(`${this.baseUrl}/Transaction/transactionsFilter/${viewObj.customerId}/${start}/${end}`)
    // return this.http.get<any>(`${this.baseUrl}/Transaction/transactionsFilter/${viewObj.customerId}/${start}/${end}`)
  }

}
