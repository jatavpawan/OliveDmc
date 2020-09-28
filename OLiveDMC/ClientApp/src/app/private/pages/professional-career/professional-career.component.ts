import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { Router } from '@angular/router';
import { DestinationVideosService } from 'src/app/providers/DestinationVideos/destination-videos.service';

@Component({
  selector: 'app-professional-career',
  templateUrl: './professional-career.component.html',
  styleUrls: ['./professional-career.component.css']
})
export class ProfessionalCareerComponent implements OnInit {


  destinationVideoForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  destinationVideos:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_destinationVideo: boolean = false;
  destinationVideoId: string;
  tooltipText:string ="this Destination Video is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";

  constructor( 
    private formBuilder : FormBuilder,
    private  destinationVideosService: DestinationVideosService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.destinationVideoForm = this.formBuilder.group({
      title: ['', Validators.required],
      showInFrontEnd: [false],
      featuredImage: [''],
      video: [''],

    })
    
  }

  ngOnInit(): void {
    debugger;
    var self = this; 
    this.GetAllDestinationVideo();
  }

 
  preview(file) {
    debugger;

    if(this.edit_destinationVideo == true){
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

  submitDestinationVideoData(){
    debugger;

    if(this.destinationVideoForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_destinationVideo == true ? formData.append('Id', this.destinationVideoId) : formData.append('Id', '0'); 
      this.destinationVideoId = '0';
      if( (this.edit_destinationVideo == false) || (this.edit_destinationVideo == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.destinationVideoForm.get('title').value);
      formData.append('showInFrontEnd', this.destinationVideoForm.get('showInFrontEnd').value);
      formData.append('Video', this.videoName);


      this.destinationVideosService.AddUpdateDestinationVideos(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_destinationVideo == true){
          Swal.fire(
            'Updated!',
            'Your Destination Video has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Destination Video has been Added.',
            'success'
          )
         }
          
          this.edit_destinationVideo = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.destinationVideoForm.reset();
          this.resetDestinationVideoForm();
          this.videoName = "";
          this.videoUrl = "";
          this.GetAllDestinationVideo();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllDestinationVideo(){
    debugger;

    this.destinationVideosService.GetAllDestinationVideos().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.destinationVideos = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editDestinationVideo(destinationVideo){
    debugger;

    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.destinationVideoForm.get('title').setValue(destinationVideo.title);
    this.destinationVideoForm.get('showInFrontEnd').setValue(destinationVideo.showInFrontEnd);
   
    this.destinationVideoId = ''+destinationVideo.id; 
    this.videoName = destinationVideo.video;
    this.previewUrl =  this.apiendpoint+'Uploads/Home/DestinationVideos/image/'+destinationVideo.featuredImage;
    this.edit_destinationVideo = true;
  }

  deleteDestinationVideo(id){
    debugger;

    this.spinner.show()
    this.destinationVideosService.deleteDestinationVideos(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllDestinationVideo();  
        Swal.fire(
          'Deleted!',
          'Your DestinationVideo has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(destinationVideoId){
    debugger;

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Destination Video!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteDestinationVideo(destinationVideoId);
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
      this.destinationVideosService.videoUploadInDestinationVideos(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/Home/DestinationVideos/Video/"+resp.data; 
          this.videoName = resp.data;
          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }

      })
    }
    else{
      this.destinationVideoForm.get('video').setValue(null);
    files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.destinationVideosService.deleteVideoInDestinationVideos(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(destinationVideo){
    debugger;

    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/destination-videos-detail', destinationVideo.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_destinationVideo == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetDestinationVideoForm(){
    this.destinationVideoForm.setValue({
      title: '', 
      showInFrontEnd: false, 
      featuredImage: '', 
      video: '', 
    })
  }

}
 