import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    FooterComponent,
    HeaderComponent,
    PublicLayoutComponent,
    PrivateLayoutComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule
  ],
  providers: [
    DataService,
    AuthGuard,
    AuthenticationService,
    ThemeService,
    NewsService,
    CurrentNewsService,
    UpcommingNewsService,
    EventService,
    DestinationVideosService,
    InterviewService,
    TrendingNewsService,
    FaqService,
    TopDestinationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    { provide: Window, useValue: window }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
