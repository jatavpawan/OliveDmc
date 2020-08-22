import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { AboutUsService } from 'src/app/providers/AboutUsService/about-us.service';

@Component({
  selector: 'app-aboutus-statement',
  templateUrl: './aboutus-statement.component.html',
  styleUrls: ['./aboutus-statement.component.css']
})
export class AboutusStatementComponent implements OnInit {

 
  statementForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  statements:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_statement: boolean = false;
  statementId: string;
  tinymceConfig: any;
  tooltipText:string ="this About Us Statement is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  
  constructor( 
    private formBuilder : FormBuilder,
    private  aboutUsService: AboutUsService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.statementForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
      featuredImage: [''],
    })
    
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.aboutUsService.fileUploadInAboutUsStatement(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/AboutUsStatement/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllAboutUsStatement();
  }

 
  preview(file) {

    if(this.edit_statement == true){
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

  submitAboutUsStatementData(){
    if(this.statementForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_statement == true ? formData.append('Id', this.statementId) : formData.append('Id', '0'); 
      this.statementId = '0';
      if( (this.edit_statement == false) || (this.edit_statement == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.statementForm.get('title').value);
      formData.append('Description', this.statementForm.get('description').value);
      formData.append('ShowInFrontEnd', this.statementForm.get('showInFrontEnd').value);


      this.aboutUsService.AddUpdateAboutUsStatement(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_statement == true){
          Swal.fire(
            'Updated!',
            'Your About Us Statement has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your About Us Statement has been Added.',
            'success'
          )
         }
          
          this.edit_statement = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetAboutUsStatementForm();
          this.GetAllAboutUsStatement();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllAboutUsStatement(){

    this.aboutUsService.GetAllAboutUsStatement().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.statements = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editAboutUsStatement(statement){
    this.statementForm.get('title').setValue(statement.title);
    this.statementForm.get('description').setValue(statement.description);
    this.statementForm.get('showInFrontEnd').setValue(statement.showInFrontEnd);
   
    this.statementId = ''+statement.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/AboutUsStatement/image/'+statement.featuredImage;
    this.edit_statement = true;
  }

  deleteAboutUsStatement(id){

    this.spinner.show()
    this.aboutUsService.deleteAboutUsStatement(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllAboutUsStatement();  
        Swal.fire(
          'Deleted!',
          'Your About Us Statement has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(statementId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this About Us Statement!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteAboutUsStatement(statementId);
      }

    })
  }


  gotoDetailPage(statement){
    this.router.navigate(['/private/AboutUsStatement-detail', statement.id]);
  }

  ngOnDestroy() {
  }

  resetAboutUsStatementForm(){
    this.statementForm.setValue({
      title: '', 
      description: '', 
      showInFrontEnd: false, 
      featuredImage: '', 
    })
  }


}

