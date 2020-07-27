import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from '../dataservice/data.service';
import { ResponseModel } from 'src/app/model/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private dataService: DataService, private router: Router) { }

  //  showData(){
  //    return <Observable<any>> this.dataService.getData('todos');
  //  }
  //  createData(data){
  //    return <Observable<any>> this.dataService.postData('todos', data);
  //  }

  setUserdata(token: string) {
     localStorage.setItem("LoggedInUser", JSON.stringify (token))
   }
   getUserdata() {
     return  localStorage.getItem("LoggedInUser");
   }
   isLoggedIn() {
     return this.getUserdata() !== null;
   }
   logout() {
     localStorage.removeItem("LoggedInUser");
     localStorage.removeItem("id_token");
     this.router.navigate(["public"]);
   }

   loginUser(data){
      return <Observable<ResponseModel>> this.dataService.postData('Login/LoginUser', data);
   }

   registerUser(data){
    return <Observable<ResponseModel>> this.dataService.postData('Login/RegisterUser', data);
   }

   userOtpVerify(data){
    return <Observable<ResponseModel>> this.dataService.postData('Login/UserOtpVerify', data);
   }
   
   userResendOtp(data){
    return <Observable<ResponseModel>> this.dataService.postData('Login/UserResendOtp', data);
   }

  testing(){
    return <Observable<ResponseModel>> this.dataService.postData('test', {name: 'shubham', age: 25});
  }


 forgotPassword(data){
  return <Observable<ResponseModel>> this.dataService.postData('Login/UserForgotPassword', data);
 }

 changePassword(data){
  return <Observable<ResponseModel>> this.dataService.postData('Login/UserChangePassword', data);
 }

 getAllUserDetails()
 {
   return <Observable<ResponseModel>> this.dataService.getData('Login/GetAllUserDetails');
 }
 

 updateRegisterUser(data){
  return <Observable<ResponseModel>> this.dataService.postFormData('Login/UpdateRegisterUser', data);
 }

 UserChangePassword(data){
  return <Observable<ResponseModel>> this.dataService.postData('Login/ChangePassword', data);
 }


 
}
