import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { NewsService } from 'src/app/providers/NewsService/news.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {


  newsForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  newses:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_news: boolean = false;
  newsId: string;
  tinymceConfig: any;
  tooltipText:string ="this News is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";

  constructor( 
    private formBuilder : FormBuilder,
    private  newsService: NewsService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    private authService: AuthenticationService,
    ) {

    this.newsForm = this.formBuilder.group({
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
      self.newsService.fileUploadInNews(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/News/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllNews();
  }

 
  preview(file) {

    if(this.edit_news == true){
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

  submitNewsData(){
    if(this.newsForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_news == true ? formData.append('Id', this.newsId) : formData.append('Id', '0'); 
      this.newsId = '0';
      if( (this.edit_news == false) || (this.edit_news == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.newsForm.get('title').value);
      formData.append('Description', this.newsForm.get('description').value);
      formData.append('Status', this.newsForm.get('status').value);
      formData.append('Video', this.videoName);


      this.newsService.AddUpdateNews(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_news == true){
          Swal.fire(
            'Updated!',
            'Your News has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your News has been Added.',
            'success'
          )
         }
          
          this.edit_news = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetNewsForm();
          // this.newsForm.reset();
          // this.newsForm.get('description').setValue('');
          this.videoName = "";
          this.GetAllNews();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllNews(){

    this.newsService.GetAllNews().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.newses = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editNews(news){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.newsForm.get('title').setValue(news.title);
    this.newsForm.get('description').setValue(news.description);
    this.newsForm.get('status').setValue(news.status);
   
    this.newsId = ''+news.id; 
    this.videoName = news.video;
    this.previewUrl =  this.apiendpoint+'Uploads/News/image/'+news.featuredImage;
    this.edit_news = true;
  }

  deleteNews(id){

    this.spinner.show()
    this.newsService.deleteNews(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllNews();  
        Swal.fire(
          'Deleted!',
          'Your News has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(newsId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this News!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteNews(newsId);
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
      this.newsService.videoUploadInNews(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/News/Video/"+resp.data; 
          this.videoName = resp.data;
          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }

      })
    }
    else{
      this.newsForm.get('video').setValue(null);
    files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.newsService.deleteVideoInNews(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(news){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/news-detail', news.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_news == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetNewsForm(){
    this.newsForm.setValue({
      title: '', 
      description: '', 
      status: false, 
      featuredImage: '', 
      video: '', 
    })
  }

}
 