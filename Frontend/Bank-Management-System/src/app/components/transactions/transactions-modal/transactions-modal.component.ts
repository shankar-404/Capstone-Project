import { Component, OnInit, Output, EventEmitter  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-transactions-modal',
  templateUrl: './transactions-modal.component.html',
  styleUrls: ['./transactions-modal.component.css']
})
export class TransactionsModalComponent implements OnInit {

  @Output() transactionTypeEvent = new EventEmitter<string>();
  transactionTypeForm!: FormGroup;
  value!: string
  
  constructor(private fb: FormBuilder, public activeModal: NgbActiveModal) { }
  
  ngOnInit(): void {
    this.transactionTypeForm = this.fb.group({
      transactionType: ['',Validators.required],
    })
  }
  // addNewItem() {
  //   this.transactionType.emit(value);
  // }
  onSave(){ 
    this.value = this.transactionTypeForm.value.transactionType;
    this.transactionTypeEvent.emit(this.value);
    this.activeModal.close();
  }

}
