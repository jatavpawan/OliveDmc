import { PublicRoutingModule } from './../../routing/public-routing/public-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingComponent } from '../../pages/landing/landing.component';
import { SharedModule } from 'src/app/shared/shared/shared.module';
import { LoginComponent } from '../../pages/login/login.component';
import { SignupComponent } from '../../pages/signup/signup.component';
import { ForgotPasswordComponent } from '../../pages/forgot-password/forgot-password.component';
import { SentmailForgotPsswordComponent } from '../../pages/sentmail-forgot-pssword/sentmail-forgot-pssword.component';
import { OtpVerificationComponent } from '../../pages/otp-verification/otp-verification.component';
import { PublicHomeComponent } from '../../pages/public-home/public-home.component';



@NgModule({
  declarations: [
    LandingComponent,
    LoginComponent,
    SignupComponent,
    ForgotPasswordComponent,
    SentmailForgotPsswordComponent,
    OtpVerificationComponent,
    PublicHomeComponent,
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    SharedModule
  ]
})
export class PublicModule { }
