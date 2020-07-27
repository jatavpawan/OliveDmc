import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { Status } from 'src/app/model/ResponseModel';
import { Router } from '@angular/router';
import  'jquery';
import Swal from 'sweetalert2'
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup;
  passwordMatchError: boolean = false;
  checkPasswordMatch: boolean = false;
  submitSignupForm: boolean = false;

  constructor( private formBuilder : FormBuilder,
     private  authService: AuthenticationService,
     private router: Router,
     private spinner: NgxSpinnerService,

  ) {
      this.signupForm = this.formBuilder.group({
        firstName: ['',Validators.required],
        middleName: [''],
        lastName: ['', Validators.required],
        emailId: ['', Validators.required],
        mobileNo: ['', Validators.required],
        category: ['', Validators.required],
        travelEnthuiast: [false],
        password: [null, Validators.required],
        confirmPassword: [null, Validators.required],
      })
  }

  ngOnInit(): void {
  }

  signUp(){
    debugger;
    console.log("signUp Form");
    if(this.signupForm.valid){
      this.spinner.show();
      this.authService.registerUser(this.signupForm.value).subscribe(resp=>{
        
        console.log(resp);
        this.spinner.hide();
  
        if(resp.status ==  Status.Success){
          Swal.fire('Registered!',resp.message,'success');
          this.router.navigate(['public/otp-verification']);
          this.router.navigateByUrl('public/otp-verification/'+this.signupForm.get('mobileNo').value)

        }
        else if(resp.status == Status.Warning) {
            Swal.fire('Not Registered!',resp.message,'warning');
        }
        else{
          Swal.fire('Oops...', resp.message, 'error');
        }
        
  
      })
    }
    else{
      this.submitSignupForm = true; 
    }
  }
  
  passwordMatch(){
    
    let password =  this.signupForm.get('password').value;
    let confirmPassword = this.signupForm.get('confirmPassword').value;
    this.passwordMatchError =  password ==confirmPassword  ?  true : false;
    this.checkPasswordMatch = true;
  }
  
  validateNumbers(key) {
    
    // var keycode = (key.which) ? key.which : key.keyCode;

    // if (keycode > 31 && (keycode < 48 || keycode > 57)) {
    //     alert(" You can enter only characters 0 to 9 ");
    //     return false;
    // }
    // else return true;
    return true;
  }


  

}
