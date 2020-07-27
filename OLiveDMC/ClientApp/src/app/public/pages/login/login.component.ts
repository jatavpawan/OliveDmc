import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { Status } from 'src/app/model/ResponseModel';
import { Router } from '@angular/router';
// import  'jquery';
import Swal from 'sweetalert2'
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  submitLoginForm: boolean = false;

  constructor( private formBuilder : FormBuilder,
     private  authService: AuthenticationService,
     private router: Router,
     private spinner: NgxSpinnerService,

  ) {
      
      this.loginForm = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required],
        keepLoggedIn: [false],
      })
  }

  ngOnInit(): void {

    
    if (JSON.parse (localStorage.getItem("keepMeLoggedIn"))){
      let keepMeLoggedInObj =JSON.parse (localStorage.getItem("keepMeLoggedIn"));
      this.loginForm.get('email').setValue(keepMeLoggedInObj.email);
      this.loginForm.get('password').setValue(keepMeLoggedInObj.password);
      localStorage.removeItem('keepMeLoggedIn');
    }
  }


  login(){
    
    console.log("Login Form");
    if(this.loginForm.valid){
      this.spinner.show();
        this.authService.loginUser(this.loginForm.value).subscribe(resp=>{
          this.spinner.hide();
          if(resp.status == Status.Success){
            localStorage.setItem("id_token", resp.message);
            this.authService.setUserdata(resp.data);
            this.router.navigate(['private/dashboard']);
          }
          else{
            // alert(resp.message);
            Swal.fire('Oops...', resp.message, 'warning');
          }
      })    
    }
    else{
      this.submitLoginForm = true; 
    }
  }
  

  keepLoggedIn(value){
    console.log('checkbox value',value.target.checked);
    let checkValue: Boolean = value.target.checked;
    
    if(checkValue == true){
       localStorage.setItem("keepMeLoggedIn", JSON.stringify(this.loginForm.value));
    }
    else{
       if (JSON.parse (localStorage.getItem("keepMeLoggedIn"))) {
        localStorage.removeItem("keepMeLoggedIn");
       } 
    }
  }
}
