import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';
import { TransactionsService } from 'src/app/services/transactions.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  startDateModel!: NgbDateStruct;
  endDateModel!: NgbDateStruct;
  viewForm!: FormGroup;
  customerId!:string;
  tableData!: any;
  
  constructor(private fb: FormBuilder, private toastr: ToastrService, private router: Router, private transactionsService : TransactionsService) { }

  ngOnInit(): void {
    this.tableData = null
    this.customerId = localStorage.getItem('customerId') || ""
    this.viewForm = this.fb.group({
      customerId : [this.customerId],
      transactionType: ['',Validators.required],
      startDate: ['',Validators.required],
      endDate: ['',Validators.required],
    })
  }

  onSubmit(){
    if(this.viewForm.valid){
      //API Request
      console.log(this.viewForm.value)
      this.transactionsService.view(this.viewForm.value)
      .subscribe({
        next:(res)=>{
          console.log(res)
          this.tableData = res;
          // if(res.status == true) {
          //   this.toastr.success("Transaction Complete: Balance = " + res.balance,"Success");
          // }
          // else{
          //   this.toastr.error(res.message,"Error");
          // } 
        },
        error:(err)=>{
          this.toastr.error("Connection to backend failed","Error");
        }
      })
    }
    else{
      console.log(this.viewForm.value)
      this.toastr.error("Invalid Form","Error");
      ValidateForm.validateFormFields(this.viewForm);
    }
  }

}
