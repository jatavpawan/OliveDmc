import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { LocationService } from 'src/app/providers/LocationService/location.service';
import { environment } from 'src/environments/environment';
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { TravelUtilityService } from 'src/app/providers/TravelUtilityService/travel-utility.service';




@Component({
  selector: 'app-travel-utility',
  templateUrl: './travel-utility.component.html',
  styleUrls: ['./travel-utility.component.css']
})
export class TravelUtilityComponent implements OnInit {

 
  countries:any =[];
  states:any =[];
  cities:any =[];
  utilityForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  apiendpoint:string =environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_utility: boolean = false;
  utilityId: string;
  tinymceConfig: any;
  tooltipText:string ="this Utility is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  formWizardName:string = 'Visa'

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";
  statesLoad: any = [];
  addStateFlag: boolean= false;
  cityLoad: any = [];
  addCityFlag: boolean= false;
  utilityDetail: any;

  constructor( 
    private  locationService: LocationService,
    private  travelUtilityService: TravelUtilityService,
    private spinner: NgxSpinnerService,
    private formBuilder : FormBuilder,

  ){
    this.utilityForm = this.formBuilder.group({
      utilityType: ['Visa'],
      description: [''],
      status: [false],
      image: [''],
      video: [''],
      countryId: [0],
      stateId: [0],
      cityId: [0]
    })


  }


  ngOnInit(){
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.travelUtilityService.fileUploadInUtility(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/Utility/image/"+resp.data; 
          success(url);
      })
    }

    this.getUtilityDetailByUtilityType('Visa');
    this.GetAllCountry();
  }

  getUtilityDetailByUtilityType(utilityType?){
    debugger;
    this.spinner.show();
    this.travelUtilityService.getUtilityDetailByUtilityType(utilityType).subscribe(resp=>{
      this.spinner.hide();  
      if(resp.status == Status.Success){
            this.utilityDetail = resp.data;
            console.log("this.utilityDetail", this.utilityDetail);
        }

    })
  }

  GetAllCountry(){
      debugger;
      this.locationService.GetAllCountry().subscribe(resp=>{
        if(resp.status == Status.Success){
            this.countries = resp.data;
        } 
        else{
          Swal.fire('Oops...', resp.message, 'error');
        }
        this.spinner.hide();
      })    
    }

  changeCountry(){
    debugger;
    this.spinner.show();
    let countryId =  this.utilityForm.get('countryId').value;
    this.locationService.GetStateByCountryId(countryId).subscribe(resp => {
      debugger;
      this.spinner.hide();
         if(resp.status == Status.Success){
           this.statesLoad = resp.data;
           resp.data == [] ? this.addStateFlag = true : this.addStateFlag = false;
         }
    })
  }

  changeState(){
    debugger;
    this.spinner.show();
    let stateId =  this.utilityForm.get('stateId').value;
    this.locationService.GetCityByStateId(stateId).subscribe(resp => {
      debugger;
      this.spinner.hide();
         if(resp.status == Status.Success){
           this.cityLoad = resp.data;
           resp.data == [] ? this.addCityFlag = true : this.addCityFlag = false;
         }
    })
  }
    
  resetUtilityForm(){
    this.utilityForm.setValue({
      utilityType: '',
      description: '',
      status: false,
      image: '',
      video: '',
      countryId: 0,
      stateId: 0,
      cityId: 0
    })
  }

  preview(file) {
    if(this.edit_utility == true){
       this.editfileUploaded = true;
    }

    let files = file.files[0] 
    var mimeType = files.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(files); 
    reader.onload = (_event) => { 
      this.previewUrl = reader.result; 
    }

    this.file = files;  
    this.fileUploaded = true;
  }

  submitUtilityData(){
    if(this.utilityForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_utility == true ? formData.append('Id', this.utilityId) : formData.append('Id', '0'); 
      this.utilityId = '0';
      if( (this.edit_utility == false) || (this.edit_utility == true && this.editfileUploaded == true)){
        formData.append('Image', this.file);
      }
      else{
        formData.append('Image', null);
      }
      formData.append('UtilityType', this.utilityForm.get('utilityType').value);
      formData.append('Description', this.utilityForm.get('description').value);
      formData.append('Status', this.utilityForm.get('status').value);
      formData.append('CountryId', this.utilityForm.get('countryId').value);
      formData.append('StateId', this.utilityForm.get('stateId').value);
      formData.append('cityId', this.utilityForm.get('cityId').value);
      formData.append('Video', this.videoName);

      this.travelUtilityService.AddUpdateUtility(formData).subscribe(resp=>{
        this.spinner.hide();
        let utilityType = this.utilityForm.get('utilityType').value;
        if(resp.status == Status.Success){
         if(this.edit_utility == true){
          Swal.fire(
            'Updated!',
            'Your Utility has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Utility has been Added.',
            'success'
          )
         }

         this.getUtilityDetailByUtilityType(utilityType);
          
          this.edit_utility = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetUtilityForm();
          this.videoName = "";
        } 
      })    
    }
    
  }

  editUtility(utility){

    this.statesLoad= [];
    this.cityLoad= [];
    this.spinner.show();
    this.locationService.GetStateByCountryId(utility.countryId).subscribe(resp => {
      debugger;
      if(resp.status == Status.Success){
        this.statesLoad = resp.data;
        this.locationService.GetCityByStateId(utility.stateId).subscribe(resp => {
          debugger;
          this.spinner.hide();
          if(resp.status == Status.Success){
            this.cityLoad = resp.data;
            if(this.videoName != ""){
              this.deleteVideoFromPhysicalLocation(this.videoName);
            }
            this.utilityForm.get('utilityType').setValue(utility.utilityType);
            this.utilityForm.get('description').setValue(utility.description);
            this.utilityForm.get('status').setValue(utility.status);
            this.utilityForm.get('countryId').setValue(utility.countryId);
            this.utilityForm.get('stateId').setValue(utility.stateId);
            this.utilityForm.get('cityId').setValue(utility.cityId);
           
            this.utilityId = ''+utility.id; 
            this.videoName = utility.video;
            this.previewUrl =  this.apiendpoint+'Uploads/Utility/image/'+utility.image;
            this.edit_utility = true;
          }
        })
      }
    })


  }
  deleteUtility(id){

    this.spinner.show()
    this.travelUtilityService.deleteUtility(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        // this.GetAllEvent();  
        Swal.fire(
          'Deleted!',
          'Your Utility has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(utilityId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Utility!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteUtility(utilityId);
      }

    })
  }

  changeVideo(file){
    debugger;
    let oldVideoName: string = this.videoName;
     let files = file.files[0] 

     if(files.size <= 10485760 && files.type == "video/mp4"){
      console.log(`video size is : ${files.size/1048576}MB`)
      const  formdata = new FormData();
      formdata.append("fileInfo", files);
      this.spinner.show();
      this.travelUtilityService.videoUploadInUtility(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/Utility/Video/"+resp.data; 
          this.videoName = resp.data;

          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }
        
      })
     }

     else{
      this.utilityForm.get('video').setValue(null);
      files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
      files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }
    //--------------paste---------------

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.travelUtilityService.deleteVideoInUtility(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  // gotoDetailPage(event){
  //   if(this.videoName != ""){
  //     this.deleteVideoFromPhysicalLocation(this.videoName);
  //   }
  // }

   changeInFormWizard(WizardName:string){

    debugger;
    this.formWizardName = WizardName;
    this.utilityForm.get('utilityType').setValue(WizardName);
    this.getUtilityDetailByUtilityType(WizardName);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_utility == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }

  }

}
