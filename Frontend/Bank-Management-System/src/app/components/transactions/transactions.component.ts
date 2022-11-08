import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';
import { TransactionsModalComponent } from './transactions-modal/transactions-modal.component';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  transactionForm!: FormGroup;
  transactionTypeValue!: string;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private router: Router, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.transactionForm = this.fb.group({
      transactionType: ['',Validators.required],
      amount: ['',Validators.required]
    })
  }

  onSubmit(){
    if(this.transactionForm.valid){
      //API Request
      console.log(this.transactionForm.value)
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
