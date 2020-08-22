import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { EventService } from 'src/app/providers/EventService/event.service';
import { Router } from '@angular/router';
import { LatestEventService } from 'src/app/providers/LatestEventService/latest-event.service';

@Component({
  selector: 'app-latest-event',
  templateUrl: './latest-event.component.html',
  styleUrls: ['./latest-event.component.css']
})
export class LatestEventComponent implements OnInit {

  latestEventForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  latestEvents:any =[];
  apiendpoint:string =environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_latestEvent: boolean = false;
  latestEventId: string;
  tinymceConfig: any;
  tooltipText:string ="this Latest Event is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";

  constructor( 
    private formBuilder : FormBuilder,
    private  latestEventService: LatestEventService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    private authService: AuthenticationService,
    ) {

    this.latestEventForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
      featuredImage: [''],
      video: [''],
      location: [''],

    })
    
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.latestEventService.fileUploadInLatestEvent(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/LatestEvent/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllLatestEvent();
  }

 
  preview(file) {
    if(this.edit_latestEvent == true){
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

  submitLatestEventData(){
    if(this.latestEventForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_latestEvent == true ? formData.append('Id', this.latestEventId) : formData.append('Id', '0'); 
      this.latestEventId = '0';
      if( (this.edit_latestEvent == false) || (this.edit_latestEvent == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.latestEventForm.get('title').value);
      formData.append('Description', this.latestEventForm.get('description').value);
      formData.append('ShowInFrontEnd', this.latestEventForm.get('showInFrontEnd').value);
      formData.append('Location', this.latestEventForm.get('location').value);
      formData.append('Video', this.videoName);

      this.latestEventService.AddUpdateLatestEvent(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_latestEvent == true){
          Swal.fire(
            'Updated!',
            'Your Latest Event has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Latest Event has been Added.',
            'success'
          )
         }
          
          this.edit_latestEvent = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.videoName = "";
          this.videoUrl = "";
          this.resetLatestEventForm();
          // this.eventForm.reset();
          // this.eventForm.get('description').setValue('');
         
          this.GetAllLatestEvent();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllLatestEvent(){
    this.latestEventService.GetAllLatestEvent().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.latestEvents = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editLatestEvent(latestEvent){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.latestEventForm.get('title').setValue(latestEvent.title);
    this.latestEventForm.get('description').setValue(latestEvent.description);
    this.latestEventForm.get('showInFrontEnd').setValue(latestEvent.showInFrontEnd);
    this.latestEventForm.get('location').setValue(latestEvent.location);
   
    this.latestEventId = ''+latestEvent.id; 
    this.videoName = latestEvent.video;
    this.previewUrl =  this.apiendpoint+'Uploads/LatestEvent/image/'+latestEvent.featuredImage;
    this.edit_latestEvent = true;
  }

  deleteLatestEvent(id){

    this.spinner.show()
    this.latestEventService.deleteLatestEvent(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllLatestEvent();  
        Swal.fire(
          'Deleted!',
          'Your Latest Event has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(latestEventId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Event!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteLatestEvent(latestEventId);
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
      this.latestEventService.videoUploadInLatestEvent(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/LatestEvent/Video/"+resp.data; 
          this.videoName = resp.data;

          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }
        
      })
     }

     else{
      this.latestEventForm.get('video').setValue(null);
    files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }
    //--------------paste---------------

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.latestEventService.deleteVideoInLatestEvent(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(latestEvent){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/latest-event-detail', latestEvent.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_latestEvent == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetLatestEventForm(){
    this.latestEventForm.setValue({
      title: '', 
      description: '', 
      showInFrontEnd: false, 
      featuredImage: '', 
      location: '', 
      video: '', 
    })
  }

}
