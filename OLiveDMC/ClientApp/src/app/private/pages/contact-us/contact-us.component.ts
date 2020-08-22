import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { ContactUsService } from 'src/app/providers/ContactUsService/contact-us.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  contactUsForm: FormGroup;
  queries:any =[];
  edit_query: boolean = false;
  queryId: string;

  constructor( 
    private formBuilder : FormBuilder,
    private  contactUsService: ContactUsService, 
    private spinner: NgxSpinnerService,
    ) {

    this.contactUsForm = this.formBuilder.group({
      id: [0],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      mobile: ['', Validators.required],
      email: ['', Validators.required],
      message: ['', Validators.required],
    })
    
  }

  ngOnInit(){
    this.GetAllQuery();
  }


  submitQueryData(){
    if(this.contactUsForm.valid){
      this.spinner.show();

      this.contactUsService.AddUpdateContactUs(this.contactUsForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_query == true){
          Swal.fire(
            'Updated!',
            'Your Query has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Query has been Added.',
            'success'
          )
         }
          this.edit_query = false;
          this.resetQuery();
          this.GetAllQuery();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  resetQuery(){
    this.contactUsForm.setValue({
      id: 0,
      firstName: '',
      lastName: '',
      mobile: '',
      email: '',
      message: '',
    })
  }

  GetAllQuery(){
    this.contactUsService.GetAllContactUs().subscribe(resp=>{
      debugger;
      if(resp.status == Status.Success){
          this.queries = resp.data;
          console.log("this.queries: ", this.queries);
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editQuery(query){

    this.contactUsForm.get('id').setValue(query.id);
    this.contactUsForm.get('firstName').setValue(query.firstName);
    this.contactUsForm.get('lastName').setValue(query.lastName);
    this.contactUsForm.get('mobile').setValue(query.mobile);
    this.contactUsForm.get('email').setValue(query.email);
    this.contactUsForm.get('message').setValue(query.message);
    this.edit_query = true;
  }

  deleteQuery(id){

    this.spinner.show()
    this.contactUsService.deleteContactUs(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllQuery();  
        Swal.fire(
          'Deleted!',
          'Your Query has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(queryId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Query!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteQuery(queryId);
      }

    })
  }
}
