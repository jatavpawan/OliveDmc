import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { ThemeService } from 'src/app/providers/theme.service';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { BannerService } from 'src/app/providers/BannerService/banner.service';


@Component({
  selector: 'app-theme-page',
  templateUrl: './theme-page.component.html',
  styleUrls: ['./theme-page.component.css']
})

export class ThemePageComponent implements OnInit {

  themeForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  themes:any=[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_TourTheme: boolean = false;
  themeId: string;
  tinymceConfig: any;
  tooltipText:string ="this theme is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string="";
  videoName:string = "";

  constructor( 
    private formBuilder : FormBuilder,
    private  themeService: ThemeService, 
    private router: Router,
    private spinner: NgxSpinnerService,  
    ) {

    this.themeForm = this.formBuilder.group({
      themeName: ['', Validators.required],
      description: ['', Validators.required],
      status: [false],
      FeaturedImage: [''],
      video: [''],
    })
 }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.themeService.fileUploadInTourTheme(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/TourTheme/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllTourTheme();
  }

 
  preview(file) {
    if(this.edit_TourTheme == true){
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

  submitThemeData(){

    if(this.themeForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_TourTheme == true ? formData.append('Id', this.themeId) : formData.append('Id', '0'); 
      this.themeId = '0';
      if( (this.edit_TourTheme == false) || (this.edit_TourTheme == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('ThemeName', this.themeForm.get('themeName').value);
      formData.append('Description', this.themeForm.get('description').value);
      formData.append('Status', this.themeForm.get('status').value);
      formData.append('Video', this.videoName);
    
      
      this.themeService.AddUpdateTheme(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_TourTheme == true){
          Swal.fire(
            'Updated!',
            'Your Theme has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Theme has been Added.',
            'success'
          )
         }
          
          this.edit_TourTheme = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.themeForm.reset();
          this.resetThemeForm()
          this.themeForm.get('description').setValue('');
          this.videoName = "";
          this.videoUrl = "";
          this.GetAllTourTheme();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllTourTheme(){
    this.themeService.GetAllTourTheme().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.themes = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editTourTheme(theme){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.themeForm.get('themeName').setValue(theme.themeName);
    this.themeForm.get('description').setValue(theme.description);
    this.themeForm.get('status').setValue(theme.status);
    this.themeId = ''+theme.id; 
    this.videoName = theme.video; 
    this.previewUrl =  this.apiendpoint+'Uploads/TourTheme/image/'+theme.featuredImage;
    this.edit_TourTheme = true;
  }

  deleteTourTheme(id){
    this.spinner.show()
    this.themeService.deleteTourTheme(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllTourTheme();  
        Swal.fire(
          'Deleted!',
          'Your Theme has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(themeId){
    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this theme!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteTourTheme(themeId);
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
      this.themeService.videoUploadInTheme(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/TourTheme/Video/"+resp.data;
          this.videoName = resp.data;
          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }
      })  
    }
    else{
      this.themeForm.get('video').setValue(null);
    files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.themeService.deleteVideoInTheme(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(theme){
    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/theme-detail', theme.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_TourTheme == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetThemeForm(){
    this.themeForm.setValue({
      themeName: '', 
      description: '', 
      status: false, 
      FeaturedImage: '', 
      video: '', 
    })
  }

}
