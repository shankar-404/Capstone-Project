import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = "https://localhost:7200/api"
  constructor(private http: HttpClient) { }

  register(registerObj:any) {
    return this.http.post<any>(`${this.baseUrl}/register`,registerObj)
  }

  login(loginObj:any) {
    return this.http.post<any>(`${this.baseUrl}/login`,loginObj)

    //
  }

  isLoggedIn(){
    return !!localStorage.getItem('token')
  }
}
