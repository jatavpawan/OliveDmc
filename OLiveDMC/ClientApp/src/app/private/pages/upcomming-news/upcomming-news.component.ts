import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { UpcommingNewsService } from 'src/app/providers/UpcommingNewsService/upcomming-news.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upcomming-news',
  templateUrl: './upcomming-news.component.html',
  styleUrls: ['./upcomming-news.component.css']
})
export class UpcommingNewsComponent implements OnInit {

  upcommingNewsForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  upcommingNewses:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_upcommingNews: boolean = false;
  upcommingNewsId: string;
  tinymceConfig: any;
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipText:string ="this Upcomming News is show or hide to the user";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string ="";
  videoName: string ="";

  constructor( 
    private formBuilder : FormBuilder,
    private  upcommingNewsService: UpcommingNewsService, 
    private spinner: NgxSpinnerService,
    private router: Router,
    private authService: AuthenticationService,
    ) {

    this.upcommingNewsForm = this.formBuilder.group({
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
      self.upcommingNewsService.fileUploadInUpcommingNews(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/UpcommingNews/image/"+resp.data; 
          success(url);
      })
    }

    this.GetAllUpcommingNews();
  }

 
  preview(file) {
    if(this.edit_upcommingNews == true){
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

  submitUpcommingNewsData(){

    if(this.upcommingNewsForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_upcommingNews == true ? formData.append('Id', this.upcommingNewsId) : formData.append('Id', '0'); 
      this.upcommingNewsId = '0';
      if( (this.edit_upcommingNews == false) || (this.edit_upcommingNews == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.upcommingNewsForm.get('title').value);
      formData.append('Description', this.upcommingNewsForm.get('description').value);
      formData.append('Status', this.upcommingNewsForm.get('status').value);
      formData.append('Video', this.videoName);

      this.upcommingNewsService.AddUpdateUpcommingNews(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_upcommingNews == true){
          Swal.fire(
            'Updated!',
            'Your Upcomming News has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Upcomming News has been Added.',
            'success'
          )
         }
          
          this.edit_upcommingNews = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetUpcommingNewsForm();
          // this.upcommingNewsForm.reset();
          // this.upcommingNewsForm.get('description').setValue('');
          this.videoName = "";
          this.GetAllUpcommingNews();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllUpcommingNews(){
    this.upcommingNewsService.GetAllUpcommingNews().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.upcommingNewses = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editUpcommingNews(upcommingNews){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.upcommingNewsForm.get('title').setValue(upcommingNews.title);
    this.upcommingNewsForm.get('description').setValue(upcommingNews.description);
    this.upcommingNewsForm.get('status').setValue(upcommingNews.status);
   
    this.upcommingNewsId = ''+upcommingNews.id; 
    this.videoName = upcommingNews.video;
    this.previewUrl =  this.apiendpoint+'Uploads/UpcommingNews/image/'+upcommingNews.featuredImage;
    this.edit_upcommingNews = true;
  }

  deleteUpcommingNews(id){

    this.spinner.show()
    this.upcommingNewsService.deleteUpcommingNews(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllUpcommingNews();  
        Swal.fire(
          'Deleted!',
          'Your Upcomming News has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(upcommingNewsId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Upcomming News!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteUpcommingNews(upcommingNewsId);
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
      this.upcommingNewsService.videoUploadInUpcommingNews(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/UpcommingNews/Video/"+resp.data; 
          this.videoName = resp.data;
          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }
      })
    }
    else{
      this.upcommingNewsForm.get('video').setValue(null);
      files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
      files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.upcommingNewsService.deleteVideoInUpcommingNews(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(upcommingNews){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/upcomming-news-detail', upcommingNews.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_upcommingNews == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetUpcommingNewsForm(){
    this.upcommingNewsForm.setValue({
      title: '', 
      description: '', 
      status: false, 
      featuredImage: '', 
      video: '', 
    })
  }

}
