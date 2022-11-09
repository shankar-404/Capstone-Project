import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from 'src/app/helpers/validateForm';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  passwordInputType: string = "password";
  passwordIsText: boolean = false;
  passwordIcon: string = "fa-eye-slash";
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      customerId: ['',Validators.required],
      password: ['',Validators.required]
    })
  }

  hideShowPassword(){
    this.passwordIsText = !this.passwordIsText;
    this.passwordIsText ? this.passwordIcon = "fa-eye" : this.passwordIcon = "fa-eye-slash";
    this.passwordIsText ? this.passwordInputType = "text" : this.passwordInputType = "password";
  }

  onSubmit(){
    if(this.loginForm.valid){
      //API Request
      // console.log(this.loginForm.value)
      this.auth.login(this.loginForm.value)
      .subscribe({
        next:(res)=>{
          console.log(res.message);
          localStorage.setItem('token', 'BOOMER');
          this.loginForm.reset();
          this.router.navigate(['menu']); 
        },
        error:(err)=>{
          console.log(err.message);
          this.router.navigate(['register'])
        }
      })
    }
    else{
      this.toastr.error("Invalid Form","Error");
      ValidateForm.validateFormFields(this.loginForm);
    }
  }

}
