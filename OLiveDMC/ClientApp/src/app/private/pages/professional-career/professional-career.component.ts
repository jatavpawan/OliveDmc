import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { FresherCareerService } from 'src/app/providers/FresherCareerService/fresher-career.service';
import { SkillService } from 'src/app/providers/SkillService/skill.service';
import { ProfessionalCareerService } from 'src/app/providers/ProfessionalCareerService/professional-career.service';
import { AreaOfExpertiseComponent } from '../area-of-expertise/area-of-expertise.component';
import { AreaofexpertiseService } from 'src/app/providers/AreaOfExpertiseService/areaofexpertise.service';

@Component({
  selector: 'app-professional-career',
  templateUrl: './professional-career.component.html',
  styleUrls: ['./professional-career.component.css']
})
export class ProfessionalCareerComponent implements OnInit {


  skills: Array<any> = [];
  edit_professional: boolean = false;
  professionalCareers: Array<any> = [];
  apiendpoint: string =  environment.apiendpoint;
  professionalResumeFilePath: string  = "";
  professionalFilePath: string  = "";
  professionalId: string;
  professionalForm: FormGroup;
  professionalResumeFileName: any = "";
  professionalProjectFileName: any = "";
  professionalResumeFile: any;
  professionalProjectFile: any;
  professionalResumeUploaded: boolean = false;
  professionalProjectUploaded: boolean = false;
  submitProfessionalForm: boolean = false;
  areaExperties: any;
  professionalProjectFilePath: string = "";

  
  constructor( 
    private formBuilder : FormBuilder,
    private  professionalService: ProfessionalCareerService, 
    private spinner: NgxSpinnerService,
    private skillService: SkillService,
    private areaExpertiseService: AreaofexpertiseService,
    ) {

      this.professionalForm = this.formBuilder.group({
        expYear: ["", [ Validators.min(0) , Validators.max(50)]],
        expMonth: ["", [ Validators.min(0) , Validators.max(12)]],
        totalExperience: ["", Validators.required],
        highestQualification: ["", Validators.required],
        currentCompany: ["", Validators.required],
        currentLocation: ["", Validators.required],
        currentCtc: ["", Validators.required],
        expectedCtc: ["", Validators.required],
        skillId: ["", Validators.required],
        areaOfExpertise: ["", Validators.required],
        aboutMe: ["", Validators.required],
        uploadResume: ["", Validators.required],
        uploadProject: ["", Validators.required],
      });
  
    this.professionalResumeFilePath = this.apiendpoint + "Uploads/Career/ProfessionalCareer/UploadResume/"
    this.professionalProjectFilePath = this.apiendpoint + "Uploads/Career/ProfessionalCareer/UploadProject/"
    
  }

  ngOnInit(): void {
    debugger;
    this.GetAllProfessionalCareer();
    this.GetAllSkill();
    this.GetAllAreaExpertise();
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

  GetAllAreaExpertise() {
    this.areaExpertiseService.GetAllAreaofexpertise().subscribe((resp) => {
      if (resp.status == Status.Success) {
        this.areaExperties = resp.data;
      } else {
        Swal.fire("Oops...", resp.message, "error");
      }
      // this.spinner.hide();
    });
  }


  GetAllProfessionalCareer(){
    debugger;

    this.professionalService.GetAllProfessionalCareer().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.professionalCareers = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }



  
  editProfessional(professional){
     debugger;
     this.professionalResumeFileName = professional.uploadResume;  
     this.professionalProjectFileName = professional.uploadProject;
    this.edit_professional = true;
    let newskillId = professional.skillId.split(',').map(item =>{
      return Number (item);
    });
    let newAreaId = professional.areaOfExpertise.split(',').map(item =>{
      return Number (item);
    });
    let totalExperience = professional.totalExperience;
    let expYear = Math.floor(totalExperience/12) ;
    let expMonth = totalExperience%12;
    
    this.professionalForm.get('highestQualification').setValue(professional.highestQualification);
    this.professionalForm.get('currentCompany').setValue(professional.currentCompany);
    this.professionalForm.get('currentLocation').setValue(professional.currentLocation);
    this.professionalForm.get('currentCtc').setValue(professional.currentCtc);
    this.professionalForm.get('expectedCtc').setValue(professional.expectedCtc);
    this.professionalForm.get('areaOfExpertise').setValue(newAreaId);
    this.professionalForm.get('aboutMe').setValue(professional.aboutMe);
    this.professionalForm.get('totalExperience').setValue(professional.totalExperience);
    this.professionalForm.get('expYear').setValue(expYear);
    this.professionalForm.get('expMonth').setValue(expMonth);
    this.professionalForm.get('skillId').setValue(newskillId);
    
    this.professionalId =  professional.id;
  }

  deleteProfessional(id){
    debugger;
    this.spinner.show()
    this.professionalService.deleteProfessionalCareer(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllProfessionalCareer();  
        Swal.fire(
          'Deleted!',
          'Your Professional Career has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(professionalId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Professional Career!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteProfessional(professionalId);
      }

    })
  }

  downloadImage(urlLink:string){
    debugger;
    window.location.href = urlLink;

  }


  submitProfessionalData() {
    debugger;
    this.submitProfessionalForm = false;

    let year = this.professionalForm.get("expYear").value;
    let month = this.professionalForm.get("expMonth").value;
    if((parseInt(year) > 0  && parseInt(year) <= 50)  || (parseInt(month) > 0  && parseInt(year) <= 12)  ){
      let exp = year*12 + month;
      this.professionalForm.get("totalExperience").setValue(exp)
    }
    if (this.professionalForm.valid || this.edit_professional == true) {


       let skillIds: string =  this.professionalForm.get("skillId").value.toString();
       let areaIds: string =  this.professionalForm.get("areaOfExpertise").value.toString();
      // this.spinner.show();
      let formData = new FormData();

      this.edit_professional == true ? formData.append('Id', this.professionalId) : formData.append('Id', '0'); 
      this.professionalId = '0';
      if( (this.edit_professional == false) || (this.edit_professional == true && this.professionalResumeUploaded == true)){
        formData.append("UploadResume", this.professionalResumeFile);
      }
      else{
        formData.append("UploadResume", null);
      }
      if( (this.edit_professional == false) || (this.edit_professional == true && this.professionalProjectUploaded == true)){
        formData.append("UploadProject", this.professionalProjectFile);
      }
      else{
        formData.append("UploadProject", null);
      }

      formData.append(
        "TotalExperience",
        this.professionalForm.get("totalExperience").value
      );
      formData.append(
        "HighestQualification",
        this.professionalForm.get("highestQualification").value
      );
      formData.append(
        "CurrentCompany",
        this.professionalForm.get("currentCompany").value
      );
      formData.append(
        "CurrentLocation",
        this.professionalForm.get("currentLocation").value
      );
      formData.append(
        "CurrentCtc",
        this.professionalForm.get("currentCtc").value
      );
      formData.append(
        "ExpectedCtc",
        this.professionalForm.get("expectedCtc").value
      );
      formData.append("SkillId", skillIds);
      formData.append("AreaOfExpertise",areaIds);
      formData.append("AboutMe", this.professionalForm.get("aboutMe").value);
     
      this.professionalService
        .AddUpdateProfessionalCareer(formData)
        .subscribe((resp) => {
          if (resp.status == Status.Success) {
            this.GetAllProfessionalCareer();

            Swal.fire(
              "Saved!",
              "Your Professional Career Record Saved",
              "success"
            );

            this.professionalResumeUploaded = false;
            this.professionalProjectUploaded = false;
            this.professionalResumeFile = undefined;
            this.professionalProjectFile = undefined;
            this.professionalResumeFileName = "";
            this.professionalProjectFileName = "";
            this.resetProfessionalForm();
          } else {
            // this.spinner.hide();
            Swal.fire("Oops...", "Something went Wrong", "warning");
          }
        });
    } else {
      this.submitProfessionalForm = true;
    }
  }


  resetProfessionalForm() {
    this.professionalForm.reset();
    this.professionalForm.setValue({
      totalExperience: "",
      highestQualification: "",
      currentCompany: "",
      currentLocation: "",
      currentCtc: "",
      expectedCtc: "",
      skillId: "",
      areaOfExpertise: "",
      aboutMe: "",
      uploadResume: "",
      uploadProject: "",
    });
  }


  ProfessionalUploadResumeFile(uploadresume) {
    debugger;
    let files = uploadresume.files[0];
    this.professionalResumeFileName = files.name;
    
    let ext = files.name.split('.').pop();
    if(ext=="pdf" || ext=="docx" || ext=="doc"){
      this.professionalResumeFile = files;
      this.professionalResumeUploaded = true;
    } else{
      Swal.fire("Warning", "Only pdf and docs file is supported", "warning");
    }

  
  }

  ProfessionalUploadProjectFile(uploadproject) {
    debugger;
    let files = uploadproject.files[0];
    this.professionalProjectFileName = files.name;

    let ext = files.name.split('.').pop();
    if(ext=="pdf" || ext=="docx" || ext=="doc"){
      this.professionalProjectFile = files;
      this.professionalProjectUploaded = true;
    } else{
      Swal.fire("Warning", "Only pdf and docs file is supported", "warning");
    }

  
  }

  removeProfessionalResume() {
    this.professionalResumeFile =  undefined;
    this.professionalResumeUploaded = false;
    this.professionalForm.get('uploadResume').setValue('');
    this.professionalResumeFileName = "";
 
  }

  removeProfessionalProject() {
    this.professionalProjectFile =  undefined;
    this.professionalProjectUploaded = false;
    this.professionalForm.get('uploadProject').setValue('');
    this.professionalProjectFileName = "";

  }

}
 