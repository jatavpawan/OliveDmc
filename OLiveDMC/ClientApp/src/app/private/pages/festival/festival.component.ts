import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { FestivalService } from 'src/app/providers/FestivalService/festival.service';

@Component({
  selector: 'app-festival',
  templateUrl: './festival.component.html',
  styleUrls: ['./festival.component.css']
})
export class FestivalComponent implements OnInit {

  festivalForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  festivals:any =[];
  apiendpoint:string =environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_festival: boolean = false;
  festivalId: string;
  tinymceConfig: any;
  tooltipText:string ="this Festival is show or hide to the user";
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
    private  festivalService: FestivalService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.festivalForm = this.formBuilder.group({
      title: ['', Validators.required],
      shortDescription: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
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
      self.festivalService.fileUploadInFestival(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/Festival/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllFestival();
  }

 
  preview(file) {
    if(this.edit_festival == true){
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

  submitFestivalData(){
    debugger;
    if(this.festivalForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_festival == true ? formData.append('Id', this.festivalId) : formData.append('Id', '0'); 
      this.festivalId = '0';
      if( (this.edit_festival == false) || (this.edit_festival == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.festivalForm.get('title').value);
      formData.append('ShortDescription', this.festivalForm.get('shortDescription').value);
      formData.append('Description', this.festivalForm.get('description').value);
      formData.append('ShowInFrontEnd', this.festivalForm.get('showInFrontEnd').value);
      formData.append('Video', this.videoName);

      this.festivalService.AddUpdateFestival(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_festival == true){
          Swal.fire(
            'Updated!',
            'Your Festival has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Festival has been Added.',
            'success'
          )
         }
          
          this.edit_festival = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetFestivalForm();
          this.videoName = "";
          this.videoUrl = "";
          this.GetAllFestival();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllFestival(){
    debugger;

    this.festivalService.GetAllFestival().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.festivals = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editFestival(festival){
    debugger;

    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.festivalForm.get('title').setValue(festival.title);
    this.festivalForm.get('shortDescription').setValue(festival.shortDescription);
    this.festivalForm.get('description').setValue(festival.description);
    this.festivalForm.get('showInFrontEnd').setValue(festival.showInFrontEnd);
   
    this.festivalId = ''+festival.id; 
    this.videoName = festival.video;
    this.previewUrl =  this.apiendpoint+'Uploads/Festival/image/'+festival.featuredImage;
    this.edit_festival = true;
  }

  deleteFestival(id){
    debugger;

    this.spinner.show()
    this.festivalService.deleteFestival(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllFestival();  
        Swal.fire(
          'Deleted!',
          'Your Festival has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(festivalId){
    debugger;

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Festival!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteFestival(festivalId);
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
      this.festivalService.videoUploadInFestival(formdata).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
          this.videoUrl = this.apiendpoint+"Uploads/Festival/Video/"+resp.data; 
          this.videoName = resp.data;

          if(oldVideoName != ""){
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }
        
      })
     }

     else{
      this.festivalForm.get('video').setValue(null);
    files.size > 10485760 &&  Swal.fire('Upload Failed',"Video Size Exceed To 10MB",'warning');
    files.type != "video/mp4" &&  Swal.fire('Upload Failed',"Only MP4 video is supported",'warning');
    }
    
  }
    //--------------paste---------------

  deleteVideoFromPhysicalLocation(oldVideoName:string){
    debugger;
    this.festivalService.deleteVideoInFestival(oldVideoName).subscribe(resp=>{
      if(resp.status == Status.Success){
         console.log("previous Video Delete Successfully ");
      }
    })  
  }

  gotoDetailPage(festival){
    debugger;

    if(this.videoName != ""){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/festival-detail', festival.id]);
  }

  ngOnDestroy() {
    if(this.videoName != "" && this.edit_festival == false){
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetFestivalForm(){
    debugger;

    this.festivalForm.setValue({
      title: '', 
      shortDescription: '', 
      description: '', 
      showInFrontEnd: false, 
      featuredImage: '', 
      video: '', 
    })
  }

  shortDescriptionCharacterCount(event): boolean{
    if(this.festivalForm.get('shortDescription').value.length >=200  && event.keyCode != 8 ){
      let shortDescription:string = this.festivalForm.get('shortDescription').value;
      this.festivalForm.get('shortDescription').setValue(shortDescription.substring(0,200));
      this.characterCount =  this.festivalForm.get('shortDescription').value.length;
      return false;
    }
    this.characterCount =  this.festivalForm.get('shortDescription').value.length;
    return true;
  }

}
