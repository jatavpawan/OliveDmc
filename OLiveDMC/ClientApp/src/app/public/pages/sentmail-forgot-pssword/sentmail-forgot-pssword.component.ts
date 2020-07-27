import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { Status } from 'src/app/model/ResponseModel';
import { Router } from '@angular/router';
import  'jquery';
import Swal from 'sweetalert2'
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-sentmail-forgot-pssword',
  templateUrl: './sentmail-forgot-pssword.component.html',
  styleUrls: ['./sentmail-forgot-pssword.component.css']
})
export class SentmailForgotPsswordComponent implements OnInit {

  
  navigation = "login";
  loginForm: FormGroup;
  signupForm: FormGroup;
  otpForm: FormGroup;
  passwordMatchError: boolean = false;
  checkPasswordMatch: boolean = false;
  submitLoginForm: boolean = false;
  submitSignupForm: boolean = false;
  submitOtpForm: boolean = false;
  submitChangePasswordForm: boolean = false;
  submitForgotPasswordForm: boolean = false;
  forgotPasswordForm: FormGroup;
  changePasswordForm: FormGroup;
  changePasswordMatchError: boolean = false;
  checkPasswordMatchInChangePassword: boolean = false;

  constructor( private formBuilder : FormBuilder,
     private  authService: AuthenticationService,
     private router: Router,
     private spinner: NgxSpinnerService,

  ) {
      
      this.forgotPasswordForm = this.formBuilder.group({
        email: ['', Validators.required],
      })




  }

  ngOnInit(): void {
  }


  
  forgotPasswordSubmit(){
    
    console.log("forgotPasswordSubmit Form");
    if(this.forgotPasswordForm.valid){
      this.spinner.show();

      this.authService.forgotPassword(this.forgotPasswordForm.value).subscribe(resp=>{
        
        this.spinner.hide();

        if(resp.status ==  Status.Success){
          Swal.fire('',resp.message,'success');
          this.router.navigateByUrl('/public/forgot-password/'+this.forgotPasswordForm.get('email').value);
        }
        else if(resp.status == Status.Warning) {
            Swal.fire('', resp.message,'warning');
        }
        else{
          Swal.fire('Oops...', resp.message, 'error');
        }
      
      })
    }
    else{
      this.submitForgotPasswordForm = true; 
    }
  }
  
  
  passwordMatchInChangePassword(){
    
    let password =  this.changePasswordForm.get('password').value;
    let confirmPassword = this.changePasswordForm.get('confirmPassword').value;
    this.changePasswordMatchError =  password ==confirmPassword  ?  true : false;
    this.checkPasswordMatchInChangePassword = true;
  }

  

}
