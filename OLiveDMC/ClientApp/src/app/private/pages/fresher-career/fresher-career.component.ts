import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { FresherCareerService } from 'src/app/providers/FresherCareerService/fresher-career.service';

@Component({
  selector: 'app-fresher-career',
  templateUrl: './fresher-career.component.html',
  styleUrls: ['./fresher-career.component.css']
})
export class FresherCareerComponent implements OnInit {


  careerPerson = "student";
  skills: Array<any> = [];
  fresherForm: FormGroup;
  fresherResumeFile: any;
  fresherProjectFile: any;
  fresherResumeFileName: any = "";
  fresherProjectFileName: any = "";
  fresherResumeUploaded: boolean = false;
  fresherProjectUploaded: boolean = false;
  submitFresherForm: boolean;
  edit_fresher: boolean = false;
  fresherCareers: Array<any> = [];
  apiendpoint: string =  environment.apiendpoint;
  
  constructor( 
    private formBuilder : FormBuilder,
    private  fresherService: FresherCareerService, 
    private spinner: NgxSpinnerService,
    ) {

    this.fresherForm = this.formBuilder.group({
      location: ["", Validators.required],
      skillId: ["", Validators.required],
      socialMediaProfile: ["", Validators.required],
      aboutMe: ["", Validators.required],
      uploadResume: ["", Validators.required],
      uploadProject: ["", Validators.required],
    });
    
  }

  ngOnInit(): void {
    debugger;
    this.GetAllFresherCareer();
  }


  GetAllFresherCareer(){
    debugger;

    this.fresherService.GetAllFresherCareer().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.fresherCareers = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }



  
  editCategory(fresher){

    this.edit_fresher = true;
  }

  deleteFresher(id){

    this.spinner.show()
    this.fresherService.deleteFresherCareer(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllFresherCareer();  
        Swal.fire(
          'Deleted!',
          'Your Fresher Career has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(fresherId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Fresher Career!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteFresher(fresherId);
      }

    })
  }

}
 