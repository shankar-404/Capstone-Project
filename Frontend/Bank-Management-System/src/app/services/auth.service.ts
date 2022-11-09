import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = "https://localhost:7281/api"
  constructor(private http: HttpClient) { }

  register(registerObj:any) {
    console.log("Req:", registerObj)
    return this.http.post(`${this.baseUrl}/RegisterService/Register`, registerObj, { responseType: 'text' })
  }

  login(loginObj:any) {
    return this.http.post<any>(`${this.baseUrl}/LoginService`,loginObj)
  }

  isLoggedIn(){
    return !!localStorage.getItem('token')
  }
}
