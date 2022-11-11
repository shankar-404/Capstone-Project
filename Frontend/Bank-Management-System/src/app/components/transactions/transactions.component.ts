import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';
import { TransactionsService } from 'src/app/services/transactions.service';
import { TransactionsModalComponent } from './transactions-modal/transactions-modal.component';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  transactionForm!: FormGroup;
  transactionTypeValue!: string;
  customerId!:string;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private router: Router, private transactionsService: TransactionsService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.customerId = localStorage.getItem('customerId') || ""
    this.transactionForm = this.fb.group({
      customerId: [this.customerId],
      transactionType: ['',Validators.required],
      amount: ['',Validators.required]
    })
  }

  onSubmit(){
    if(this.transactionForm.valid){
      if(this.transactionForm.value['transactionType'] == 'Withdraw') {
      //API Request
      this.transactionsService.withdraw(this.transactionForm.value)
      .subscribe({
        next:(res)=>{
          // console.log(res)
          if(res.status == true) {
            this.toastr.success("Transaction Complete: Balance = " + res.balance,"Success");
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
    else if(this.transactionForm.value['transactionType'] == 'Deposit') {
      //API Request
      this.transactionsService.deposit(this.transactionForm.value)
      .subscribe({
        next:(res)=>{
          // console.log(res)
          if(res.status == true) {
            this.toastr.success("Transaction Complete: Balance = " + res.balance,"Success");
          }
          else{
            this.toastr.error(res.message,"Error");
          } 
        },
        error:(err)=>{
          // console.log(this.transactionForm.value)
          this.toastr.success("Connection to backend failed","Error");
        }
      })
    }
    }
    else{
      console.log(this.transactionForm.value)
      this.toastr.error("Invalid Form","Error");
      ValidateForm.validateFormFields(this.transactionForm);
    }
  }
  addToForm(eventData: string) {
    console.log(eventData)
  }

  openModal(){
    const modalRef = this.modalService.open(TransactionsModalComponent);
    modalRef.componentInstance.transactionTypeEvent.subscribe((data: any) => {
      this.transactionForm.value.transactionType = data
      this.transactionTypeValue = data;
    })
		console.log(modalRef.componentInstance.value)
  }

}
