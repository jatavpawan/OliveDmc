import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { CurrentNewsService } from 'src/app/providers/CurrentNewsService/current-news.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-current-news',
  templateUrl: './current-news.component.html',
  styleUrls: ['./current-news.component.css']
})
export class CurrentNewsComponent implements OnInit {

  
  currentNewsForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  currentNewses:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_currentNews: boolean = false;
  currentNewsId: string;
  tinymceConfig: any;
  tooltipText:string ="this Current News is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";

  constructor( 
    private formBuilder : FormBuilder,
    private  currentNewsService: CurrentNewsService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.currentNewsForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      status: [false],
      featuredImage: [''],
      video: [''],

    })
    
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.currentNewsService.fileUploadInCurrentNews(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/CurrentNews/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllCurrentNews();
  }

 
  preview(file) {
    if(this.edit_currentNews == true){
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

  submitCurrentNewsData(){
    if(this.currentNewsForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_currentNews == true ? formData.append('Id', this.currentNewsId) : formData.append('Id', '0'); 
      this.currentNewsId = '0';
      if( (this.edit_currentNews == false) || (this.edit_currentNews == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.currentNewsForm.get('title').value);
      formData.append('Description', this.currentNewsForm.get('description').value);
      formData.append('Status', this.currentNewsForm.get('status').value);
      formData.append('Video', this.videoName);

      this.currentNewsService.AddUpdateCurrentNews(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_currentNews == true){
          Swal.fire(
            'Updated!',
            'Your Current News has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Current News has been Added.',
            'success'
          )
         }
          
          this.edit_currentNews = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetCurrentNewsForm();
          // this.currentNewsForm.reset();
          // this.currentNewsForm.get('description').setValue('');
          this.videoName = "";
          this.GetAllCurrentNews();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllCurrentNews(){
    this.currentNewsService.GetAllCurrentNews().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.currentNewses = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editCurrentNews(currentNews){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.currentNewsForm.get('title').setValue(currentNews.title);
    this.currentNewsForm.get('description').setValue(currentNews.description);
    this.currentNewsForm.get('status').setValue(currentNews.status);
   
    this.currentNewsId = ''+currentNews.id; 
    this.videoName = currentNews.video;
    this.previewUrl =  this.apiendpoint+'Uploads/CurrentNews/image/'+currentNews.featuredImage;
    this.edit_currentNews = true;
  }

  deleteCurrentNews(id){

    this.spinner.show()
    this.currentNewsService.deleteCurrentNews(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllCurrentNews();  
        Swal.fire(
          'Deleted!',
          'Your Current News has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(currentNewsId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Current News!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteCurrentNews(currentNewsId);
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
      this.currentNewsService.videoUploadInCurrentNews(formdata).subscribe(resp=>{
        this.spinner.hide();
        this.videoUrl = this.apiendpoint+"Uploads/CurrentNews/Video/"+resp.data; 
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/CurrentNews/Video/"+resp.data; 
          this.videoName = resp.data;
          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
  
        }
      })
    }
    else{
      debugger;
      this.currentNewsForm.get('video').setValue(null);
      files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
      files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
      // Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    }
    
  }

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.currentNewsService.deleteVideoInCurrentNews(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(currentNews){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/current-news-detail', currentNews.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_currentNews == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetCurrentNewsForm(){
    this.currentNewsForm.setValue({
      title: '', 
      description: '', 
      status: false, 
      featuredImage: '', 
      video: '', 
    })
  }


}
