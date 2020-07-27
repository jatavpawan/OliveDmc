import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Status } from 'src/app/model/ResponseModel';
import Swal from 'sweetalert2'
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  profileForm: FormGroup;
  userData: any;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  ProfileImg: string = "";
  apiendpoint: string;

  constructor(
    private formBuilder: FormBuilder,
    private  authService: AuthenticationService,
    private spinner: NgxSpinnerService,

    ){
    this.profileForm = this.formBuilder.group({
      firstName: ['',Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      emailId: ['', Validators.required],
      mobileNo: ['', Validators.required],
      category: ['', Validators.required],
      travelEnthuiast: [false],
    })    
    debugger;
    this.userData = JSON.parse (this.authService.getUserdata());
    this.ProfileImg = this.userData.profileImage;
    this.profileForm.setValue({
      firstName: this.userData.firstName,
      middleName: this.userData.middleName,
      lastName: this.userData.lastName,
      emailId: this.userData.emailId,
      mobileNo: this.userData.mobileNo,
      category: this.userData.category,
      travelEnthuiast: this.userData.travelEnthuiast,
    })
    this.apiendpoint = environment.apiendpoint;
  }

  ngOnInit(){}

  
  preview(file) {
    debugger;
    // if(this.edit_blog == true){
    //    this.editfileUploaded = true;
    // }

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

  
  submitUserData(){
    debugger;
    if(this.profileForm.valid){
      this.spinner.show();

      let formData = new FormData();
      formData.append('Id', this.userData.id);
      if( this.fileUploaded == true){
        formData.append('ProfileImage', this.file);
      }
      else{
        formData.append('ProfileImage', null);
      }
      formData.append('FirstName', this.profileForm.get('firstName').value);
      formData.append('MiddleName', this.profileForm.get('middleName').value);
      formData.append('LastName', this.profileForm.get('lastName').value);
      formData.append('EmailId', this.profileForm.get('emailId').value);
      formData.append('MobileNo', this.profileForm.get('mobileNo').value);
      formData.append('Category', this.profileForm.get('category').value);
      formData.append('TravelEnthuiast', this.profileForm.get('travelEnthuiast').value);

      this.authService.updateRegisterUser(formData).subscribe(resp=>{
     
        this.spinner.hide();
        if(resp.status == Status.Success){
          Swal.fire(
            'Updated!',
            'Your Profile has been Updated.',
            'success'
          )
          this.authService.setUserdata(resp.data);
          // this.fileUploaded = false;
          this.file = undefined;
          // this.profileForm.reset();
         }
      })    
    }
  }




}
