import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

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
