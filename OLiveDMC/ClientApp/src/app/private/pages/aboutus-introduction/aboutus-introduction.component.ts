import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { AboutUsService } from 'src/app/providers/AboutUsService/about-us.service';
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-aboutus-introduction',
  templateUrl: './aboutus-introduction.component.html',
  styleUrls: ['./aboutus-introduction.component.css']
})
export class AboutusIntroductionComponent implements OnInit {

  title: string = '';
  featuredImageFirst: any;
  featuredImageSecond: any;
  mycontent: string = '';
  log: string = '';
  aboutUsDescription: any = '';
  status: boolean = false;
  editContent: boolean = false;
  aboutUsData: any;
  tinymceConfig: any;
  tooltipText: string = "this about us information is show or hide to the user";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  apiendpoint: string = environment.apiendpoint;
  previewUrl2:any = null;
  fileUploaded2:boolean = false;
  file2: any;
  editfileUploaded2: boolean = false;
  previewUrl1:any = null;
  fileUploaded1:boolean = false;
  file1: any;
  editfileUploaded1: boolean = false;
  imgSrcPath: string = "";


  constructor(
    private spinner: NgxSpinnerService,
    private aboutUsService: AboutUsService
  ) {
    this.imgSrcPath =  this.apiendpoint+'Uploads/AboutUsIntroduction/image/';
    this.loadAboutUs();
  }

  loadAboutUs() {
    debugger;
    this.spinner.show();
    this.aboutUsService.GetAboutUsIntroductionDetail().subscribe(resp => {
      this.spinner.hide();
      if (resp.status == Status.Success && resp.data != null && resp.data.length != 0) {
        this.aboutUsDescription = resp.data[0].description;
        this.aboutUsData = resp.data[0];
      }
    })
  }

  ngOnInit() {
    var self = this;
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob());
      self.aboutUsService.fileUploadInAboutUsIntroduction(formdata).subscribe(resp => {
        let url = self.apiendpoint + "Uploads/AboutUsIntroduction/image/" + resp.data;
        success(url);
      })
    }
  }

  preview1(file) {
    debugger;

    if(this.editContent == true){
       this.editfileUploaded1 = true;
    }

    let files = file.files[0]; 
    var mimeType = files.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(files); 
    reader.onload = (_event) => { 
      this.previewUrl1 = reader.result; 
    }

    this.file1 = files;  
    this.fileUploaded1 = true;
  }

  preview2(file) {
    debugger;

    if(this.editContent == true){
       this.editfileUploaded2 = true;
    }

    let files = file.files[0]; 
    var mimeType = files.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(files); 
    reader.onload = (_event) => { 
      this.previewUrl2 = reader.result; 
    }

    this.file2 = files;  
    this.fileUploaded2 = true;
  }

  SaveAboutUs(editorContent?) {
    debugger;

    this.spinner.show();
    // let data: any = {
    //   Description: this.mycontent,
    //   Status: this.status,
    //   title: this.title
    // }

    // if (editorContent != undefined) {
    //   this.editContent = false;
    //   data.id = editorContent.id;
    // }

    let formData = new FormData();
    this.editContent == true ? formData.append('Id', editorContent.id) : formData.append('Id', '0'); 
    if( (this.editContent == false) || (this.editContent == true && this.editfileUploaded1 == true)){
      formData.append('FeaturedImageFirst', this.file1);
    }
    if( (this.editContent == false) || (this.editContent == true && this.editfileUploaded2 == true)){
      formData.append('FeaturedImageSecond', this.file2);
    }
    if(this.editContent == true && this.editfileUploaded1 == false){
      formData.append('FeaturedImageFirst', null);
    }
    if(this.editContent == true && this.editfileUploaded2 == false){
      formData.append('FeaturedImageSecond', null);
    }

    formData.append('Title', this.title);
    formData.append('Description', this.mycontent);
    formData.append('ShowInFrontEnd', ''+this.status);

    this.aboutUsService.AddUpdateAboutUsIntroductionDetail(formData).subscribe(resp => {
      this.spinner.hide();
      if (resp.status == Status.Success) {
        Swal.fire('', resp.message, 'success');
        this.mycontent = "";
        this.title = "";
        this.featuredImageFirst = undefined;
        this.featuredImageSecond = undefined;
        this.status = false;
        this.editContent = false;
        this.editfileUploaded1 = false;
        this.fileUploaded1 = false;
        this.file1 = undefined;
        this.editfileUploaded2 = false;
        this.fileUploaded2 = false;
        this.file2 = undefined;
        this.previewUrl1 = undefined;
        this.previewUrl2 = undefined;
        this.getAboutUs();
      }
      else if (resp.status == Status.Warning) {
        Swal.fire('', resp.message, 'warning');
        // this.spinner.hide();
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
        // this.spinner.hide();
      }
    })
  }

  getAboutUs() {
    debugger;
    this.spinner.show();
    this.aboutUsService.GetAboutUsIntroductionDetail().subscribe(resp => {
      this.spinner.hide();
      if (resp.status == Status.Success) {
        this.aboutUsDescription = resp.data[0].description;
        this.aboutUsData = resp.data[0];
      }
      else {
        Swal.fire('', resp.message, 'warning');
      }
    })
  }

  editCkeditorContent(aboutUsData) {
    debugger;

    this.editContent = true;
    this.mycontent = this.aboutUsDescription;
    this.status = aboutUsData.showInFrontEnd;
    this.title = aboutUsData.title;
    this.previewUrl1 =  this.apiendpoint+'Uploads/AboutUsIntroduction/image/'+aboutUsData.featuredImageFirst;
    this.previewUrl2 =  this.apiendpoint+'Uploads/AboutUsIntroduction/image/'+aboutUsData.featuredImageSecond;
  }

  deleteCkeditorContent(data) {
    debugger;

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
        this.spinner.show();
        this.aboutUsService.deleteAboutUsIntroductionInfo(data.id).subscribe(resp => {
          this.spinner.hide();

          if (resp.status == Status.Success) {
            Swal.fire('', resp.message, 'success');
            this.aboutUsDescription = "";
            this.aboutUsData = undefined;
          }
          else if (resp.status == Status.Warning) {
            Swal.fire('', resp.message, 'warning');
          }
          else {
            Swal.fire('Oops...', resp.message, 'error');
          }
        })
      }

    })
  }


}
