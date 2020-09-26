import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { AreaofexpertiseService } from 'src/app/providers/AreaOfExpertiseService/areaofexpertise.service';


@Component({
  selector: 'app-area-of-expertise',
  templateUrl: './area-of-expertise.component.html',
  styleUrls: ['./area-of-expertise.component.css']
})
export class AreaOfExpertiseComponent implements OnInit {

  areaExForm: FormGroup;
  areaExperties:any =[];
  edit_areaexpertise: boolean = false;
  areaexpertiseId: string;

  constructor( 
    private formBuilder : FormBuilder,
    private  areaExpertiseService: AreaofexpertiseService, 
    private spinner: NgxSpinnerService,
    ) {

    this.areaExForm = this.formBuilder.group({
      id: [0],
      name: [''],
    })
    
  }

  ngOnInit(): void {
    this.GetAllAreaExpertise();
  }


  submitAreaExpertiseData(){
    if(this.areaExForm.valid){
      this.spinner.show();


      this.areaExpertiseService.AddUpdateAreaofexpertise(this.areaExForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_areaexpertise == true){
          Swal.fire(
            'Updated!',
            'Your Area Expertise has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Area Expertise has been Added.',
            'success'
          )
         }
          
          this.edit_areaexpertise = false;
          this.resetAreaExpertise();
          this.GetAllAreaExpertise();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  resetAreaExpertise(){
    this.areaExForm.setValue({
      id: 0,
      name: ''
    })
  }

  GetAllAreaExpertise(){
    this.areaExpertiseService.GetAllAreaofexpertise().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.areaExperties = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editAreaExpertise(areaExpertise){

    this.areaExForm.get('id').setValue(areaExpertise.id);
    this.areaExForm.get('name').setValue(areaExpertise.name);
    this.edit_areaexpertise = true;
  }

  deleteAreaExpertise(id){

    this.spinner.show()
    this.areaExpertiseService.deleteAreaofexpertise(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllAreaExpertise();  
        Swal.fire(
          'Deleted!',
          'Your Area Expertise has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(areaExpertiseId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Area Expertise",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteAreaExpertise(areaExpertiseId);
      }

    })
  }
}
