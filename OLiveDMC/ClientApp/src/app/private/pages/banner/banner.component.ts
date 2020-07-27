import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { BannerService } from 'src/app/providers/BannerService/banner.service';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent implements OnInit {

  bannerForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  banners:any =[];
  apiendpoint:string= environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_banner: boolean = false;
  bannerId: string;
  tinymceConfig: any;
  tooltipText:string ="this banner is show or hide from the user";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

  constructor( 
    private formBuilder : FormBuilder,
    private  bannerService: BannerService, 
    private spinner: NgxSpinnerService 
    ) {

    this.bannerForm = this.formBuilder.group({
      title: ['', Validators.required],
      pageId: [''],
      status: [false],
      imagePath: [''],
    })
 }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.bannerService.fileUploadInBanner(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/Banner/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllBanner();
  }

 
  preview(file) {
    if(this.edit_banner == true){
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
  
  
  submitBannerData(){

    if(this.bannerForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_banner == true ? formData.append('Id', this.bannerId) : formData.append('Id', '0'); 
      this.bannerId = '0';
      if( (this.edit_banner == false) || (this.edit_banner == true && this.editfileUploaded == true)){
        formData.append('ImagePath', this.file);
      }
      else{
        formData.append('ImagePath', null);
      }
      formData.append('Title', this.bannerForm.get('title').value);
      formData.append('Status', this.bannerForm.get('status').value);
      formData.append('PageId', this.bannerForm.get('pageId').value);

      this.bannerService.AddUpdateBanner(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_banner == true){
          Swal.fire(
            'Updated!',
            'Your Banner has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Banner has been Added.',
            'success'
          )
         }
          
          this.edit_banner = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.bannerForm.reset();
          this.resetBannerForm();
          this.GetAllBanner();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllBanner(){
    this.bannerService.GetAllBanner().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.banners = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editBanner(banner){
    this.bannerForm.get('title').setValue(banner.title);
    this.bannerForm.get('status').setValue(banner.status);
    this.bannerForm.get('pageId').setValue(banner.pageId);
    this.bannerId = ''+banner.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/Banner/image/'+banner.imagePath;
    this.edit_banner = true;
  }

  deleteBanner(id){
    this.spinner.show()
    this.bannerService.deleteBanner(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllBanner();  
        Swal.fire(
          'Deleted!',
          'Your Banner has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(bannerId){
    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Banner!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteBanner(bannerId);
      }

    })
  }


  resetBannerForm(){
    this.bannerForm.setValue({
      title: '', 
      pageId: '', 
      status: '', 
      imagePath: '', 
    })

  }
}
``