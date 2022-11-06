import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  passwordInputType: string = "password";
  passwordIsText: boolean = false;
  passwordIcon: string = "fa-eye-slash";
  registerForm!: FormGroup;

  constructor(private fb: FormBuilder, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: ['', Validators.required],
      lastName: ['', Validators.required],
      city: ['', Validators.required],
      contact: ['', Validators.required],
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
      console.log(this.registerForm.value)
    }
    else{
      ValidateForm.validateFormFields(this.registerForm);
      this.toastr.error("Invalid Form","Error");
    }
  }

}
