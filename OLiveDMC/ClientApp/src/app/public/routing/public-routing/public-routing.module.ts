import { LandingComponent } from './../../pages/landing/landing.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../../pages/login/login.component';
import { SignupComponent } from '../../pages/signup/signup.component';
import { SentmailForgotPsswordComponent } from '../../pages/sentmail-forgot-pssword/sentmail-forgot-pssword.component';
import { ForgotPasswordComponent } from '../../pages/forgot-password/forgot-password.component';
import { OtpVerificationComponent } from '../../pages/otp-verification/otp-verification.component';
import { PublicHomeComponent } from '../../pages/public-home/public-home.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'landing',
    pathMatch: 'full'
  },
  {
    path: 'landing',
    component: LandingComponent,
  },
  {
    path: 'public-home',
    component: PublicHomeComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'signUp',
    component: SignupComponent,
  },
  {
    path: 'sendmail-forgotpassword',
    component: SentmailForgotPsswordComponent,
  },
  {
    path: 'forgot-password/:email',
    component: ForgotPasswordComponent,
  },
  {
    path: 'otp-verification/:mobileNo',
    component: OtpVerificationComponent,
  },
  // {
  //   path: 'landing',
  //   component: LandingComponent,
  //   children: [
  //     {
  //       path: '',
  //       component: LoginComponent,
  //     },
  //     {
  //       path: 'login',
  //       component: LoginComponent,
  //     },
  //     {
  //       path: 'signUp',
  //       component: SignupComponent,
  //     },
  //     {
  //       path: 'sendmail-forgotpassword',
  //       component: SentmailForgotPsswordComponent,
  //     },
  //     {
  //       path: 'forgot-password',
  //       component: ForgotPasswordComponent,
  //     },
  //     {
  //       path: 'otp-verification',
  //       component: OtpVerificationComponent,
  //     },
  //   ]
  // },

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]

})
export class PublicRoutingModule { }
