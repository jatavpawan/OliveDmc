import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { environment } from 'src/environments/environment';
import { PrivacyPolicyService } from 'src/app/providers/PrivacyPolicyService/privacy-policy.service';

@Component({
  selector: 'app-privacy-policy',
  templateUrl: './privacy-policy.component.html',
  styleUrls: ['./privacy-policy.component.css']
})
export class PrivacyPolicyComponent implements OnInit {

  mycontent: string ='';
  privacyPolicyDescription: any = '';
  status:boolean = false;
  editContent:boolean = false;
  privacyPolicyData: any;
  tinymceConfig: any ;
  tooltipText:string ="this Privacy Policy information is show or hide to the user";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
}
  apiendpoint: string= environment.apiendpoint;


  constructor( 
    private spinner: NgxSpinnerService, 
    private privacyPolicyService: PrivacyPolicyService
  ) {
    this.loadPrivacyPolicy();
  } 

  loadPrivacyPolicy(){
    debugger;
      this.spinner.show();
      this.privacyPolicyService.GetPrivacyPolicyDetail().subscribe(resp =>{
        this.spinner.hide();
          if(resp.status == Status.Success && resp.data != null && resp.data.length != 0  ){
             this.privacyPolicyDescription = resp.data[0].description;
             this.privacyPolicyData = resp.data[0];
          }
     })
  }

  ngOnInit() {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.privacyPolicyService.fileUploadInPrivacyPolicy(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/PrivacyPolicy/image/"+resp.data; 
          success(url);
      })
    }
  }

  SavePrivacyPolicy(editorContent ?){
    debugger;

    this.spinner.show();
    let data: any ={
      Description: this.mycontent, 
      ShowInFrontEnd: this.status
    } 

    if(editorContent !=undefined)
    {
      this.editContent = false;
      data.id = editorContent.id;
    }

    this.privacyPolicyService.AddUpdatePrivacyPolicyDetail(data).subscribe(resp =>{
      if(resp.status ==  Status.Success){
        Swal.fire('', resp.message,'success');
        this.mycontent = "";
        this.status = false;
        this.getPrivacyPolicy();
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

  getPrivacyPolicy(){
    debugger;

    this.privacyPolicyService.GetPrivacyPolicyDetail().subscribe(resp =>{
      this.spinner.hide();
        if(resp.status == Status.Success){
           this.privacyPolicyDescription = resp.data[0].description;
           this.privacyPolicyData = resp.data[0];
        }
        else{
          Swal.fire('' ,resp.message,'warning');
        }
   })
  }

  editCkeditorContent(privacyPolicyData){
    debugger;
    this.editContent = true;
    this.mycontent = this.privacyPolicyDescription;
    this.status = privacyPolicyData.showInFrontEnd;
  }

  deleteCkeditorContent(data){
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
        this.privacyPolicyService.removePrivacyPolicyDetail(data.id).subscribe(resp =>{
          this.spinner.hide();

          if(resp.status ==  Status.Success){
            Swal.fire('', resp.message,'success');
            this.privacyPolicyDescription = "";
            this.privacyPolicyData = undefined;
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
