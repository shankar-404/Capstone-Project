import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateForm';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  startDateModel!: NgbDateStruct;
  endDateModel!: NgbDateStruct;
  viewForm!: FormGroup;

  constructor(private fb: FormBuilder, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.viewForm = this.fb.group({
      transactionType: ['',Validators.required],
      startDate: ['',Validators.required],
      endDate: ['',Validators.required],
    })
  }

  onSubmit(){
    if(this.viewForm.valid){
      //API Request
      console.log(this.viewForm.value)
    }
    else{
      console.log(this.viewForm.value)
      this.toastr.error("Invalid Form","Error");
      ValidateForm.validateFormFields(this.viewForm);
    }
  }

}
