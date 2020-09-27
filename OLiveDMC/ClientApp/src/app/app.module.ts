import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { SidebarComponent } from './private/shared/sidebar/sidebar.component';
import { FooterComponent } from './private/shared/footer/footer.component';
import { HeaderComponent } from './private/shared/header/header.component';
import { PublicLayoutComponent } from './public/layout/public-layout/public-layout.component';
import { PrivateLayoutComponent } from './private/layout/private-layout/private-layout.component';
import { AppRoutingModule } from './routing/app-routing/app-routing.module';
import { DataService } from './providers/dataservice/data.service';
import { AuthGuard } from './security/auth.guard';
import { AuthenticationService } from './providers/authentication/authentication.service';
import { AuthInterceptor } from './security/auth.interceptor';
import { ThemeService } from './providers/theme.service';
import { SharedModule } from './shared/shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NewsService } from './providers/NewsService/news.service';
import { CurrentNewsService } from './providers/CurrentNewsService/current-news.service';
import { EventService } from './providers/EventService/event.service';
import { UpcommingNewsService } from './providers/UpcommingNewsService/upcomming-news.service';
import { DestinationVideosService } from './providers/DestinationVideos/destination-videos.service';
import { InterviewService } from './providers/Interview/interview.service';
import { TrendingNewsService } from './providers/TrendingNews/trending-news.service';
import { FaqService } from './providers/FAQ/faq.service';
import { TopDestinationService } from './providers/TopDestination/top-destination.service';
import { OpenVideoComponent } from './public/shared/open-video/open-video.component';
import { LatestEventService } from './providers/LatestEventService/latest-event.service';
import { NewdestinationInWhatsnewService } from './providers/NewDestinationsInWhatsNew/newdestination-in-whatsnew.service';
import { InterviewInWhatsnewService } from './providers/InterviewInWhatsNew/interview-in-whatsnew.service';
import { FestivalService } from './providers/FestivalService/festival.service';
import { TravelUtilityDetailComponent } from './private/pages/travel-utility-detail/travel-utility-detail.component';
import { ShareService } from './providers/ShareService/share.service';
import { TeamMemberService } from './providers/TeamMemberService/team-member.service';
import { ContactUsService } from './providers/ContactUsService/contact-us.service';
import { PrivacyPolicyService } from './providers/PrivacyPolicyService/privacy-policy.service';
import { BlogCategoryService } from './providers/BlogCategoryService/blog-category.service';
import { DatePipe } from '@angular/common';
import { AreaofexpertiseService } from './providers/AreaOfExpertiseService/areaofexpertise.service';
import { SkillService } from './providers/SkillService/skill.service';
import { SkillComponent } from './private/pages/skill/skill.component';
import { AreaOfExpertiseComponent } from './private/pages/area-of-expertise/area-of-expertise.component';
import { ProfessionalCareerComponent } from './private/pages/professional-career/professional-career.component';
import { StudentCareerService } from './providers/StudentCareerService/student-career.service';
import { FresherCareerService } from './providers/FresherCareerService/fresher-career.service';
// import { NgSelectModule } from ' @ng-select/ng-select';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    FooterComponent,
    HeaderComponent,
    PublicLayoutComponent,
    PrivateLayoutComponent,
    OpenVideoComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    SharedModule,
    // NgSelectModule

  ],
  providers: [
    DataService,
    NewdestinationInWhatsnewService,
    InterviewInWhatsnewService,
    DataService,
    AuthGuard,
    AuthenticationService,
    ThemeService,
    NewsService,
    CurrentNewsService,
    UpcommingNewsService,
    EventService,
    LatestEventService,
    DestinationVideosService,
    InterviewService,
    TrendingNewsService,
    FaqService,
    TopDestinationService,
    FestivalService,
    ShareService,
    TeamMemberService,
    ContactUsService,
    PrivacyPolicyService,
    BlogCategoryService,
    AreaofexpertiseService,
    SkillService,
    FresherCareerService,
    ProfessionalCareerComponent,
    StudentCareerService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    { provide: Window, useValue: window },
    DatePipe
  ],
  // schemas: [CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [
    OpenVideoComponent
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
