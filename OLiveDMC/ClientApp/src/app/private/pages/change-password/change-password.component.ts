import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Status } from 'src/app/model/ResponseModel';
import Swal from 'sweetalert2'
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

 
  changePasswordForm: FormGroup;
  userData: any;

  constructor(
    private formBuilder: FormBuilder,
    private  authService: AuthenticationService,
    private spinner: NgxSpinnerService,
    private router: Router,

    ){
    this.changePasswordForm = this.formBuilder.group({
      old_password: ['',Validators.required],
      new_password: [''],
      confirm_password: ['', Validators.required],
    })    
    this.userData = JSON.parse (this.authService.getUserdata());
  }

  ngOnInit(){}
  
  submitUserData(){
    debugger;
    if(this.changePasswordForm.get('new_password').value != this.changePasswordForm.get('confirm_password').value)
    {
       alert("confirm password is not match");
    } 
    else{
      if(this.changePasswordForm.valid){
        this.spinner.show();
        let Obj = {
          RegistrationId: this.userData.id,
          OldPassword: this.changePasswordForm.get('old_password').value,
          NewPassword: this.changePasswordForm.get('new_password').value,
        } 
  
        this.authService.UserChangePassword(Obj).subscribe(resp=>{
       
          this.spinner.hide();
          if(resp.status == Status.Success){
            Swal.fire(
              'Updated!',
              'Your Password has been Updated Successfully.',
              'success'
            )
            this.changePasswordForm.reset();
            this.router.navigate(['/private/user-profile'])
           }
         else if(resp.status == Status.Warning) {
            Swal.fire('Failed',resp.message,'warning');
         }
          else{
              Swal.fire('Oops...', resp.message, 'error');
          }
          this.changePasswordForm.reset();

        })    
      }
    }
    
  }


}
