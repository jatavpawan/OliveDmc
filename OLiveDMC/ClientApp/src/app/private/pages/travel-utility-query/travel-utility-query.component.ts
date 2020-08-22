import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { TravelUtilityService } from 'src/app/providers/TravelUtilityService/travel-utility.service';

@Component({
  selector: 'app-travel-utility-query',
  templateUrl: './travel-utility-query.component.html',
  styleUrls: ['./travel-utility-query.component.css']
})
export class TravelUtilityQueryComponent implements OnInit {

  queryForm: FormGroup;
  queries:any =[];
  edit_query: boolean = false;
  queryId: string;

  constructor( 
    private formBuilder : FormBuilder,
    private  travelUtilityService: TravelUtilityService, 
    private spinner: NgxSpinnerService,
    ) {

    this.queryForm = this.formBuilder.group({
      id: [0],
      travelUtilityType: ['', Validators.required],
      name: ['', Validators.required],
      mobile: ['', Validators.required],
      email: ['', Validators.required],
      message: ['', Validators.required],
    })
    
  }

  ngOnInit(){
    this.GetAllQuery();
  }


  submitQueryData(){
    if(this.queryForm.valid){
      this.spinner.show();

      this.travelUtilityService.AddUpdateTravelUtilityQuery(this.queryForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_query == true){
          Swal.fire(
            'Updated!',
            'Your Travel Utility Query has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Travel Utility Query has been Added.',
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
    this.queryForm.setValue({
      id: 0,
      travelUtilityType: '',
      name: '',
      mobile: '',
      email: '',
      message: '',
    })
  }

  GetAllQuery(){
    this.travelUtilityService.GetAllTravelUtilityQuery().subscribe(resp=>{
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

    this.queryForm.get('id').setValue(query.id);
    this.queryForm.get('travelUtilityType').setValue(query.travelUtilityType);
    this.queryForm.get('name').setValue(query.name);
    this.queryForm.get('mobile').setValue(query.mobile);
    this.queryForm.get('email').setValue(query.email);
    this.queryForm.get('message').setValue(query.message);
    this.edit_query = true;
  }

  deleteQuery(id){

    this.spinner.show()
    this.travelUtilityService.deleteTravelUtilityQuery(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllQuery();  
        Swal.fire(
          'Deleted!',
          'Your Travel Utility Query has been deleted.',
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
      text: "You Want to delete this Travel Utility Query!",
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
