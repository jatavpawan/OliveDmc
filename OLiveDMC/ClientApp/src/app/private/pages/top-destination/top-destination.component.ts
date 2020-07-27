import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { TopDestinationService } from 'src/app/providers/TopDestination/top-destination.service';
import { LocationService } from 'src/app/providers/LocationService/location.service';

@Component({
  selector: 'app-top-destination',
  templateUrl: './top-destination.component.html',
  styleUrls: ['./top-destination.component.css']
})
export class TopDestinationComponent implements OnInit {

  countries:any =[];
  states:any =[];
  cities:any =[];
  statesLoad: any = [];
  addStateFlag: boolean= false;
  cityLoad: any = [];
  addCityFlag: boolean= false;
  topDestinationForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  topDestinations:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_topDestination: boolean = false;
  tpDestinationId: string;
  tinymceConfig: any;
  tooltipText:string ="this Top Destination is show or hide to the user";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

  constructor( 
    private formBuilder : FormBuilder,
    private  topDestinationService: TopDestinationService, 
    private  locationService: LocationService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.topDestinationForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
      featuredImage: [''],
      countryId: [0],
      stateId: [0],
      cityId: [0]

    })
    
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.topDestinationService.fileUploadInTopDestination(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/Home/TopDestination/image/"+resp.data; 
          success(url);
      })
    }

    this.GetAllTopDestination();
    this.GetAllCountry();
    
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
  this.statesLoad = [];
  this.cityLoad = [];
  this.topDestinationForm.get('stateId').setValue('');
  this.topDestinationForm.get('cityId').setValue('');


  this.spinner.show();
  let countryId =  this.topDestinationForm.get('countryId').value;
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
  this.cityLoad = [];
  this.topDestinationForm.get('cityId').setValue('');
  let stateId =  this.topDestinationForm.get('stateId').value;
  this.locationService.GetCityByStateId(stateId).subscribe(resp => {
    debugger;
    this.spinner.hide();
       if(resp.status == Status.Success){
         this.cityLoad = resp.data;
         resp.data == [] ? this.addCityFlag = true : this.addCityFlag = false;
       }
  })
}

 
  preview(file) {

    if(this.edit_topDestination == true){
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

  submitTopDestinationData(){
    if(this.topDestinationForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_topDestination == true ? formData.append('Id', this.tpDestinationId) : formData.append('Id', '0'); 
      this.tpDestinationId = '0';
      if( (this.edit_topDestination == false) || (this.edit_topDestination == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.topDestinationForm.get('title').value);
      formData.append('Description', this.topDestinationForm.get('description').value);
      formData.append('ShowInFrontEnd', this.topDestinationForm.get('showInFrontEnd').value);
      formData.append('CountryId', this.topDestinationForm.get('countryId').value);
      formData.append('StateId', this.topDestinationForm.get('stateId').value);
      formData.append('CityId', this.topDestinationForm.get('cityId').value);


      this.topDestinationService.AddUpdateTopDestination(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_topDestination == true){
          Swal.fire(
            'Updated!',
            'Your Top Destination has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Top Destination has been Added.',
            'success'
          )
         }
          
          this.edit_topDestination = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetTopDestinationForm();
          // this.topDestinationForm.reset();
          // this.topDestinationForm.get('description').setValue('');
          this.GetAllTopDestination();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllTopDestination(){

    this.topDestinationService.GetAllTopDestination().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.topDestinations = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editTopDestination(topDestination){
    this.topDestinationForm.get('title').setValue(topDestination.title);
    this.topDestinationForm.get('description').setValue(topDestination.description);
    this.topDestinationForm.get('showInFrontEnd').setValue(topDestination.showInFrontEnd);
    this.topDestinationForm.get('countryId').setValue(topDestination.countryId);
 
   
    this.tpDestinationId = ''+topDestination.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/Home/TopDestination/image/'+topDestination.featuredImage;
    this.edit_topDestination = true;

    this.statesLoad= [];
    this.cityLoad= [];
    this.spinner.show();
    this.locationService.GetStateByCountryId(topDestination.countryId).subscribe(resp => {
      debugger;
      if(resp.status == Status.Success){
        this.statesLoad = resp.data;
        this.topDestinationForm.get('stateId').setValue(topDestination.stateId);

        this.locationService.GetCityByStateId(topDestination.stateId).subscribe(resp => {
          debugger;
          this.spinner.hide();
          if(resp.status == Status.Success){
            this.cityLoad = resp.data;
            this.topDestinationForm.get('cityId').setValue(topDestination.cityId);

          }
        })
      }
    })


  }

  deleteTopDestination(id){

    this.spinner.show()
    this.topDestinationService.deleteTopDestination(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllTopDestination();  
        Swal.fire(
          'Deleted!',
          'Your Top Destination has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(topDestinationId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Top Destination!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteTopDestination(topDestinationId);
      }

    })
  }

  gotoDetailPage(topDestination){
    this.router.navigate(['/private/top-destination-detail', topDestination.id]);
  }

  resetTopDestinationForm(){
    this.topDestinationForm.setValue({
      title: '', 
      description: '', 
      showInFrontEnd: false, 
      featuredImage: '', 
      countryId: 0, 
      stateId: 0, 
      cityId: 0, 
    })
  }

}
 