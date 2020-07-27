import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { OfferAdsService } from 'src/app/providers/OfferAdsService/offer-ads.service';

@Component({
  selector: 'app-offer-ads',
  templateUrl: './offer-ads.component.html',
  styleUrls: ['./offer-ads.component.css']
})
export class OfferAdsComponent implements OnInit {

  
  offerAdsForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  offerAds:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_offerAds: boolean = false;
  offerAdsId: string;
  tinymceConfig: any;
  tooltipText:string ="this Offer And Ads is show or hide to the user";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

  constructor( 
    private formBuilder : FormBuilder,
    private  offerAdsService: OfferAdsService, 
    private spinner: NgxSpinnerService,
    private authService: AuthenticationService,
    ) {

    this.offerAdsForm = this.formBuilder.group({
      title: ['', Validators.required],
      pageId: ['', Validators.required],
      image: [''],
    })
    
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.offerAdsService.fileUploadInOfferAds(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/OfferAds/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllOfferAds();
  }

 
  preview(file) {
    if(this.edit_offerAds == true){
       this.editfileUploaded = true;
    }

    let files = file.files[0] 
    var mimeType = files.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(files); 
    reader.onload = (_OfferAds) => { 
      this.previewUrl = reader.result; 
    }

    this.file = files;  
    this.fileUploaded = true;
  }

  submitOfferAdsData(){
    if(this.offerAdsForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_offerAds == true ? formData.append('Id', this.offerAdsId) : formData.append('Id', '0'); 
      this.offerAdsId = '0';
      if( (this.edit_offerAds == false) || (this.edit_offerAds == true && this.editfileUploaded == true)){
        formData.append('image', this.file);
      }
      else{
        formData.append('image', null);
      }
      formData.append('Title', this.offerAdsForm.get('title').value);
      formData.append('PageId', this.offerAdsForm.get('pageId').value);

      this.offerAdsService.AddUpdateOfferAds(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_offerAds == true){
          Swal.fire(
            'Updated!',
            'Your Offer And Ads has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Offer And Ads has been Added.',
            'success'
          )
         }
          
          this.edit_offerAds = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.offerAdsForm.reset();
          this.resetOfferAdsForm();
          this.GetAllOfferAds();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllOfferAds(){
    
    this.offerAdsService.GetAllOfferAds().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.offerAds = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editOfferAds(offerAds){

    this.offerAdsForm.get('title').setValue(offerAds.title);
    this.offerAdsForm.get('pageId').setValue(offerAds.pageId);
   
    this.offerAdsId = ''+offerAds.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/OfferAds/image/'+offerAds.image;
    this.edit_offerAds = true;
  }

  deleteOfferAds(id){

    this.spinner.show()
    this.offerAdsService.deleteOfferAds(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllOfferAds();  
        Swal.fire(
          'Deleted!',
          'Your Offer And Ads has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(offerAdsId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Offer And Ads!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteOfferAds(offerAdsId);
      }

    })
  }

  resetOfferAdsForm(){
    this.offerAdsForm.setValue({
      title: '', 
      pageId: '', 
      image: '', 
    })
  }

}
