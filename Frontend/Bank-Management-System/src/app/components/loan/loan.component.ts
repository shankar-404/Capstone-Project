import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';
import { LoanService } from 'src/app/services/loan.service';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {

  loanForm!: FormGroup;
  customerId!:string;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private router: Router, private loanService: LoanService) { }

  ngOnInit(): void {
    this.customerId = localStorage.getItem('customerId') || ""
    this.loanForm = this.fb.group({
      customerId:[this.customerId],
      bankBranch: ['',Validators.required],
      amount: ['',Validators.required]
    })
  }

  onSubmit(){
    if(this.loanForm.valid){
      //API Request
      console.log(this.loanForm.value)
      this.loanService.apply(this.loanForm.value)
      .subscribe({
        next:(res)=>{
          console.log(res)
          if(res.status == true) {
            this.toastr.success(res.message,"Success");
          }
          else{
            this.toastr.error(res.message,"Error");
          } 
        },
        error:(err)=>{
          this.toastr.error("Connection to backend failed","Error");
        }
      })

    }
    else{
      console.log(this.loanForm.value)
      this.toastr.error("Invalid Form","Error");
      ValidateForm.validateFormFields(this.loanForm);
    }
  }

}
