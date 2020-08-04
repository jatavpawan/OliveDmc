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
// import { SafeHtmlPipe } from 'src/app/pipe/safe-html.pipe';



@NgModule({
  declarations: [
    LandingComponent,
    LoginComponent,
    SignupComponent,
    ForgotPasswordComponent,
    SentmailForgotPsswordComponent,
    OtpVerificationComponent,
    PublicHomeComponent,
    PublicAboutComponent,
    PublicAttractionComponent,
    PublicBlogComponent,
    PublicCareerComponent,
    PublicContactUsComponent,
    PublicDestinationFinderComponent,
    PublicEventDetailsComponent,
    PublicFaqComponent,
    PublicFlightComponent,
    PublicHotelBookingComponent,
    PublicNewsEventsComponent,
    PublicPacakgesComponent,
    PublicPrivacyPolicyComponent,
    PublicSocialMediaComponent,
    PublicTravelDetailsComponent,
    PublicPrivacyPolicyComponent,
    PublicSocialMediaComponent,
    PublicTravelUtilityComponent,
    PublicWhatsNewComponent,
    // SafeHtmlPipe
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    SharedModule
  ]
})
export class PublicModule { }
