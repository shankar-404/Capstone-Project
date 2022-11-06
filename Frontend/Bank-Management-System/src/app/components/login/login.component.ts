import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  passwordInputType: string = "password";
  passwordIsText: boolean = false;
  passwordIcon: string = "fa-eye-slash";

  constructor() { }

  ngOnInit(): void {
  }

  hideShowPassword(){
    this.passwordIsText = !this.passwordIsText;
    this.passwordIsText ? this.passwordIcon = "fa-eye" : this.passwordIcon = "fa-eye-slash";
    this.passwordIsText ? this.passwordInputType = "text" : this.passwordInputType = "password";
  }

}
