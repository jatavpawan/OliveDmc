import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { NewdestinationInWhatsnewService } from 'src/app/providers/NewDestinationsInWhatsNew/newdestination-in-whatsnew.service';

@Component({
  selector: 'app-newdestinations-in-whatsnew',
  templateUrl: './newdestinations-in-whatsnew.component.html',
  styleUrls: ['./newdestinations-in-whatsnew.component.css']
})
export class NewdestinationsInWhatsnewComponent implements OnInit {

  
  destinationForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  destinations:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_destination: boolean = false;
  destinationId: string;
  tinymceConfig: any;
  tooltipText:string ="this Destination is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";
  characterCount:number = 0;
  
  constructor( 
    private formBuilder : FormBuilder,
    private  destinationService: NewdestinationInWhatsnewService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.destinationForm = this.formBuilder.group({
      title: ['', Validators.required],
      location: ['', Validators.required],
      shortDescription: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [true],
      featuredImage: [''],
      video: [''],

    })
    
  }

  ngOnInit(): void {
    debugger;
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.destinationService.fileUploadInNewDestinationsInWhatsNew(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/NewDestinationsInWhatsNew/image/"+resp.data; 
          success(url);
      })
    }

    this.GetAllDestination();
  }

 
  preview(file) {
    debugger;

    if(this.edit_destination == true){
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

  submitDestinationData(){
    debugger;
    if(this.destinationForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_destination == true ? formData.append('Id', this.destinationId) : formData.append('Id', '0'); 
      this.destinationId = '0';
      if( (this.edit_destination == false) || (this.edit_destination == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.destinationForm.get('title').value);
      formData.append('Location', this.destinationForm.get('location').value);
      formData.append('ShortDescription', this.destinationForm.get('shortDescription').value);
      formData.append('Description', this.destinationForm.get('description').value);
      formData.append('ShowInFrontEnd', this.destinationForm.get('showInFrontEnd').value);
      formData.append('Video', this.videoName);


      this.destinationService.AddUpdateNewDestinationsInWhatsNew(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_destination == true){
          Swal.fire(
            'Updated!',
            'Your Destination has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Destination has been Added.',
            'success'
          )
         }
          
          this.edit_destination = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.destinationForm.reset();
          // this.destinationForm.get('description').setValue('');
          this.resetDestinationForm();
          this.videoName = "";
          this.videoUrl = "";
          this.GetAllDestination();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllDestination(){
    debugger;

    this.destinationService.GetAllNewDestinationsInWhatsNew().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.destinations = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editDestination(destination){
    debugger;
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.destinationForm.get('title').setValue(destination.title);
    this.destinationForm.get('location').setValue(destination.location);
    this.destinationForm.get('shortDescription').setValue(destination.shortDescription);
    this.destinationForm.get('description').setValue(destination.description);
    this.destinationForm.get('showInFrontEnd').setValue(destination.showInFrontEnd);
   
    this.destinationId = ''+destination.id; 
    this.videoName = destination.video;
    this.previewUrl =  this.apiendpoint+'Uploads/NewDestinationsInWhatsNew/image/'+destination.featuredImage;
    this.edit_destination = true;
  }

  deleteDestination(id){
    debugger;

    this.spinner.show()
    this.destinationService.deleteNewDestinationsInWhatsNew(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllDestination();  
        Swal.fire(
          'Deleted!',
          'Your Destination has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(destinationId){
    debugger;

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Destination!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteDestination(destinationId);
      }

    })
  }

  changeVideo(file){
    debugger;
    let oldVideoName: string = this.videoName;
    let files = file.files[0];
    if(files.size <= 10485760 && files.type == "video/mp4"){
      console.log(`video size is : ${files.size/1048576}MB`)
      const  formdata = new FormData();
      formdata.append("fileInfo", files);
      this.spinner.show();
      this.destinationService.videoUploadInNewDestinationsInWhatsNew(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/NewDestinationsInWhatsNew/Video/"+resp.data; 
          this.videoName = resp.data;
          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }

      })
    }
    else{
      this.destinationForm.get('video').setValue(null);
    files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.destinationService.deleteVideoInNewDestinationsInWhatsNew(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(destination){
    debugger;
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/destination-detail', destination.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_destination == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }


  resetDestinationForm(){
    this.destinationForm.setValue({
      title: '', 
      location: '', 
      shortDescription: '', 
      description: '', 
      showInFrontEnd: true, 
      featuredImage: '', 
      video: '', 
    })
  }

  shortDescriptionCharacterCount(event): boolean{
    if(this.destinationForm.get('shortDescription').value.length >=200  && event.keyCode != 8 ){
      let shortDescription:string = this.destinationForm.get('shortDescription').value;
      this.destinationForm.get('shortDescription').setValue(shortDescription.substring(0,200));
      this.characterCount =  this.destinationForm.get('shortDescription').value.length;
      return false;
    }
    this.characterCount =  this.destinationForm.get('shortDescription').value.length;
    return true;
  }

}
 