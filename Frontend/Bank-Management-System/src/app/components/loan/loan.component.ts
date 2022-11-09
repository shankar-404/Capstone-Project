import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {

  loanForm!: FormGroup;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.loanForm = this.fb.group({
      branch: ['',Validators.required],
      amount: ['',Validators.required]
    })
  }

  onSubmit(){
    if(this.loanForm.valid){
      //API Request
      console.log(this.loanForm.value)
    }
    else{
      console.log(this.loanForm.value)
      this.toastr.error("Invalid Form","Error");
      ValidateForm.validateFormFields(this.loanForm);
    }
  }

}
