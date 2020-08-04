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
import { PublicAboutComponent } from '../../pages/public-about/public-about.component';
import { PublicAttractionComponent } from '../../pages/public-attraction/public-attraction.component';
import { PublicBlogComponent } from '../../pages/public-blog/public-blog.component';
import { PublicCareerComponent } from '../../pages/public-career/public-career.component';
import { PublicContactUsComponent } from '../../pages/public-contact-us/public-contact-us.component';
import { PublicDestinationFinderComponent } from '../../pages/public-destination-finder/public-destination-finder.component';
import { PublicEventDetailsComponent } from '../../pages/public-event-details/public-event-details.component';
import { PublicFaqComponent } from '../../pages/public-faq/public-faq.component';
import { PublicFlightComponent } from '../../pages/public-flight/public-flight.component';
import { PublicHotelBookingComponent } from '../../pages/public-hotel-booking/public-hotel-booking.component';
import { PublicNewsEventsComponent } from '../../pages/public-news-events/public-news-events.component';
import { PublicPacakgesComponent } from '../../pages/public-pacakges/public-pacakges.component';
import { PublicPrivacyPolicyComponent } from '../../pages/public-privacy-policy/public-privacy-policy.component';
import { PublicSocialMediaComponent } from '../../pages/public-social-media/public-social-media.component';
import { PublicTravelDetailsComponent } from '../../pages/public-travel-details/public-travel-details.component';
import { PublicTravelUtilityComponent } from '../../pages/public-travel-utility/public-travel-utility.component';
import { PublicWhatsNewComponent } from '../../pages/public-whats-new/public-whats-new.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'landing',
    component: LandingComponent,
  },
  {
    path: 'home',
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
  {
    path: 'about',
    component: PublicAboutComponent,
  },
  {
    path: 'attraction',
    component: PublicAttractionComponent,
  },
  {
    path: 'blog',
    component: PublicBlogComponent,
  },
  {
    path: 'career',
    component: PublicCareerComponent,
  },
  {
    path: 'contact-us',
    component: PublicContactUsComponent,
  },
  {
    path: 'destination-finder',
    component: PublicDestinationFinderComponent,
  },
  {
    path: 'event-details',
    component: PublicEventDetailsComponent,
  },
  {
    path: 'faq',
    component: PublicFaqComponent,
  },
  {
    path: 'flight',
    component: PublicFlightComponent,
  },
  {
    path: 'hotel-booking',
    component: PublicHotelBookingComponent,
  },
  {
    path: 'news-events',
    component: PublicNewsEventsComponent,
  },
  {
    path: 'pacakges',
    component: PublicPacakgesComponent,
  },
  {
    path: 'privacy-policy',
    component: PublicPrivacyPolicyComponent,
  },
  {
    path: 'social-media',
    component: PublicSocialMediaComponent,
  },
  {
    path: 'travel-details',
    component: PublicTravelDetailsComponent,
  },
  {
    path: 'social-media',
    component: PublicSocialMediaComponent,
  },
  {
    path: 'travel-utility',
    component: PublicTravelUtilityComponent,
  },
  {
    path: 'whats-new',
    component: PublicWhatsNewComponent,
  },






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


