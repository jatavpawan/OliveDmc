import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { AboutUsService } from 'src/app/providers/AboutUsService/about-us.service';
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {
 
  mycontent: string ='';
  log: string = '';
  aboutUsDescription: any = '';
  status:boolean = false;
  editContent:boolean = false;
  aboutUsData: any;
  tinymceConfig: any ;
  tooltipText:string ="this about us information is show or hide to the user";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
}
  apiendpoint: string= environment.apiendpoint;


  constructor( 
    private spinner: NgxSpinnerService, 
    private aboutUsService: AboutUsService
  ) {
    this.loadAboutUs();
  } 

  loadAboutUs(){
      this.spinner.show();
      this.aboutUsService.GetAboutUsDetail().subscribe(resp =>{
        this.spinner.hide();
          if(resp.status == Status.Success && resp.data != null && resp.data.length != 0  ){
             this.aboutUsDescription = resp.data[0].description;
             this.aboutUsData = resp.data[0];
          }
     })
  }

  ngOnInit() {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.aboutUsService.fileUploadInAboutUs(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/AboutUS/image/"+resp.data; 
          success(url);
      })
    }
  }

  SaveAboutUs(editorContent ?){

    this.spinner.show();
    let data: any ={
      Description: this.mycontent, 
      Status: this.status
    } 

    if(editorContent !=undefined)
    {
      this.editContent = false;
      data.id = editorContent.id;
    }

    this.aboutUsService.AddUpdateAboutUsDetail(data).subscribe(resp =>{
      if(resp.status ==  Status.Success){
        Swal.fire('', resp.message,'success');
        this.mycontent = "";
        this.status = false;
        this.getAboutUs();
      }
      else if(resp.status == Status.Warning) {
          Swal.fire('' ,resp.message,'warning');
          this.spinner.hide();
      }
      else{
        Swal.fire('Oops...', resp.message, 'error');
        this.spinner.hide();
      }
    })
  }

  getAboutUs(){
    this.aboutUsService.GetAboutUsDetail().subscribe(resp =>{
      this.spinner.hide();
        if(resp.status == Status.Success){
           this.aboutUsDescription = resp.data[0].description;
           this.aboutUsData = resp.data[0];
        }
        else{
          Swal.fire('' ,resp.message,'warning');
        }
   })
  }

  editCkeditorContent(aboutUsData){
    this.editContent = true;
    this.mycontent = this.aboutUsDescription;
    this.status = aboutUsData.status;
  }

  deleteCkeditorContent(data){
    this.spinner.show();
    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Content!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.aboutUsService.removeAboutUsDetail(data.id).subscribe(resp =>{
          this.spinner.hide();

          if(resp.status ==  Status.Success){
            Swal.fire('', resp.message,'success');
            this.aboutUsDescription = "";
            this.aboutUsData = undefined;
          }
          else if(resp.status == Status.Warning) {
              Swal.fire('' ,resp.message,'warning');
          }
          else{
            Swal.fire('Oops...', resp.message, 'error');
          }
       })
      }

    })
  }
}
