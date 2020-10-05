import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { FresherCareerService } from 'src/app/providers/FresherCareerService/fresher-career.service';
import { SkillService } from 'src/app/providers/SkillService/skill.service';

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
  submitFresherForm: boolean =  false;
  edit_fresher: boolean = false;
  fresherCareers: Array<any> = [];
  apiendpoint: string =  environment.apiendpoint;
  fresherResumeFilePath: string  = "";
  fresherProjectFilePath: string  = "";
  fresherId: string;

  
  constructor( 
    private formBuilder : FormBuilder,
    private  fresherService: FresherCareerService, 
    private spinner: NgxSpinnerService,
    private skillService: SkillService,
    ) {

    this.fresherForm = this.formBuilder.group({
      location: ["", Validators.required],
      skillId: ["", Validators.required],
      socialMediaProfile: ["", Validators.required],
      aboutMe: ["", Validators.required],
      uploadResume: ["", Validators.required],
      uploadProject: ["", Validators.required],
    });
    this.fresherResumeFilePath = this.apiendpoint + "Uploads/Career/FresherCareer/UploadResume/"
    this.fresherProjectFilePath = this.apiendpoint + "Uploads/Career/FresherCareer/UploadProject/"
    
  }

  ngOnInit(): void {
    debugger;
    this.GetAllFresherCareer();
    this.GetAllSkill();
  }

  GetAllSkill() {
    this.skillService.GetAllSkills().subscribe((resp) => {
      if (resp.status == Status.Success) {
        this.skills = resp.data;
      } else {
        Swal.fire("Oops...", resp.message, "error");
      }
      // this.spinner.hide();
    });
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



  
  editFresher(fresher){
     debugger;
     this.fresherResumeFileName = fresher.uploadResume;  
     this.fresherProjectFileName = fresher.uploadProject;
    this.edit_fresher = true;
    this.fresherForm.get('location').setValue(fresher.location);
    let newskillId = fresher.skillId.split(',').map(item =>{
      return Number (item);
   });

    this.fresherForm.get('skillId').setValue(newskillId);
    this.fresherForm.get('socialMediaProfile').setValue(fresher.socialMediaProfile);
    this.fresherForm.get('aboutMe').setValue(fresher.aboutMe);
    // this.fresherForm.get('uploadResume').setValue(fresher.uploadResume);
    // this.fresherForm.get('uploadProject').setValue(fresher.uploadProject);
    this.fresherId =  fresher.id;
  }

  deleteFresher(id){
    debugger;
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

  downloadImage(urlLink:string){
    debugger;
    window.location.href = urlLink;

  }

  submitFresherData() {
    debugger;
    this.submitFresherForm = false;
    if (this.fresherForm.valid || this.edit_fresher == true) {
      // this.spinner.show();
      let formData = new FormData();

      this.edit_fresher == true ? formData.append('Id', this.fresherId) : formData.append('Id', '0'); 
      this.fresherId = '0';
      if( (this.edit_fresher == false) || (this.edit_fresher == true && this.fresherResumeUploaded == true)){
        formData.append("UploadResume", this.fresherResumeFile);
      }
      else{
        formData.append("UploadResume", null);
      }
      if( (this.edit_fresher == false) || (this.edit_fresher == true && this.fresherProjectUploaded == true)){
        formData.append("UploadProject", this.fresherProjectFile);
      }
      else{
        formData.append("UploadProject", null);
      }

      let skillIds: string =  this.fresherForm.get("skillId").value.toString();
      formData.append("Location", this.fresherForm.get("location").value);
      formData.append("SkillId", skillIds);
      formData.append(
        "SocialMediaProfile",
        this.fresherForm.get("socialMediaProfile").value
      );
      formData.append("AboutMe", this.fresherForm.get("aboutMe").value);

      if(this.fresherResumeUploaded ==  true){
        formData.append("UploadResume", this.fresherResumeFile);
      }
      if(this.fresherProjectUploaded ==  true){
        formData.append("UploadProject", this.fresherProjectFile);
      }

      this.fresherService.AddUpdateFresherCareer(formData).subscribe((resp) => {
        if (resp.status == Status.Success) {
          this.GetAllFresherCareer();
          Swal.fire(
            "Saved!",
            "Your Fresher Career Record Saved",
            "success"
          );

          this.fresherResumeUploaded = false;
          this.fresherProjectUploaded = false;
          this.fresherResumeFile = undefined;
          this.fresherProjectFile = undefined;
          this.fresherResumeFileName = "";
          this.fresherProjectFileName = "";
          this.resetFresherForm();
        } else {
          // this.spinner.hide();
          Swal.fire("Oops...", "Something went Wrong", "warning");
        }
      });
    } else {
      this.submitFresherForm = true;
    }
  }

  resetFresherForm() {

    this.fresherForm.reset();
    this.fresherForm.setValue({
      location: "",
      skillId: "",
      socialMediaProfile: "",
      aboutMe: "",
      uploadResume: "",
      uploadProject: "",
    });
  }


  FresherUploadResumeFile(uploadresume) {
    debugger;
    let files = uploadresume.files[0];
    let ext = files.name.split('.').pop();
    if(ext=="pdf" || ext=="docx" || ext=="doc"){
      this.fresherResumeFileName = files.name;
      this.fresherResumeFile = files;
      this.fresherResumeUploaded = true;
     

    } else{
      this.fresherForm.get('uploadResume').setValue('');
      Swal.fire("Warning", "Only pdf and docs file is supported", "warning");
      return false;
    }

    
  }

  FresherUploadProjectFile(uploadproject) {
    debugger;
    let files = uploadproject.files[0];

    let ext = files.name.split('.').pop();
    if(ext=="pdf" || ext=="docx" || ext=="doc"){
      this.fresherProjectFileName = files.name;
      this.fresherProjectFile = files;
    this.fresherProjectUploaded = true;
    } else{
      this.fresherForm.get('uploadProject').setValue('');
      Swal.fire("Warning", "Only pdf and docs file is supported", "warning");
      return false;

    }
  }

  removeFresherResume() {
    this.fresherResumeFile =  undefined;
    this.fresherResumeUploaded = false;
    this.fresherForm.get('uploadResume').setValue('');
    this.fresherResumeFileName = "";
 
  }

  removeFresherProject() {
    this.fresherProjectFile =  undefined;
    this.fresherProjectUploaded = false;
    this.fresherForm.get('uploadProject').setValue('');
    this.fresherProjectFileName = "";

  }

}
 