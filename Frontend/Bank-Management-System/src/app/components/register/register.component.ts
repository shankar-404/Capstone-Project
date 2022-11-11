import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';
import { AuthService } from 'src/app/services/auth.service';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model!: NgbDateStruct;
  passwordInputType: string = "password";
  passwordIsText: boolean = false;
  passwordIcon: string = "fa-eye-slash";
  registerForm!: FormGroup;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    localStorage.clear();
    this.registerForm = this.fb.group({
      customerId:[''],
      firstName: ['', Validators.required],
      middleName: ['', Validators.required],
      lastName: ['', Validators.required],
      city: ['', Validators.required],
      contactNumber: ['', Validators.required],
      occupation: ['', Validators.required],
      dob: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  hideShowPassword(){
    this.passwordIsText = !this.passwordIsText;
    this.passwordIsText ? this.passwordIcon = "fa-eye" : this.passwordIcon = "fa-eye-slash";
    this.passwordIsText ? this.passwordInputType = "text" : this.passwordInputType = "password";
  }

  onSubmit(){
    if(this.registerForm.valid){
      //API Request
      let date_str = this.registerForm.value['dob'].year + '-' + this.registerForm.value['dob'].month + '-' + this.registerForm.value['dob'].day
      this.registerForm.value['dob'] = date_str;
      this.auth.register(this.registerForm.value)
      .subscribe({
        next:(res)=>{
          this.toastr.success("Customer ID: " + res.customerId,"Success");
          this.registerForm.reset();
          this.router.navigate(['login']);
        },
        error:(err)=>{
          this.toastr.error("Already registered","Error");
        }
      })
    }
    else{
      ValidateForm.validateFormFields(this.registerForm);
      this.toastr.error("Invalid Form","Error");
    }
  }

}
