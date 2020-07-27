import { PrivateRoutingModule } from './../../routing/private-routing/private-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { MapComponent } from '../../pages/map/map.component';
import { ThemePageComponent } from '../../pages/theme-page/theme-page.component';
import { OfferAdsComponent } from '../../pages/offer-ads/offer-ads.component';
import { TravelCategorySubcategoryComponent } from '../../pages/travel-category-subcategory/travel-category-subcategory.component';
import { WhatsNewComponent } from '../../pages/whats-new/whats-new.component';
import { TravelUtilityComponent } from '../../pages/travel-utility/travel-utility.component';
import { NewsEventsComponent } from '../../pages/news-events/news-events.component';
import { DestinationComponent } from '../../pages/destination/destination.component';
import { TravelGuruExpertTravelersComponent } from '../../pages/travel-guru-expert-travelers/travel-guru-expert-travelers.component';
import { UserListPageComponent } from '../../pages/user-list-page/user-list-page.component';
import { PostPageComponent } from '../../pages/post-page/post-page.component';
import { ContactDetailsComponent } from '../../pages/contact-details/contact-details.component';
import { SharedModule } from 'src/app/shared/shared/shared.module';
import { PageComponent } from '../../pages/page/page.component';
import { BannerComponent } from '../../pages/banner/banner.component';
import { AboutUsComponent } from '../../pages/about-us/about-us.component';
import { SafeHtmlPipe } from 'src/app/pipe/safe-html.pipe';
import { BlogComponent } from '../../pages/blog/blog.component';
import { BannerDetailComponent } from '../../pages/banner/banner-detail/banner-detail.component';
import { BlogDetailComponent } from '../../pages/blog/blog-detail/blog-detail.component';
import { NewsComponent } from '../../pages/news/news.component';
import { EventComponent } from '../../pages/event/event.component';
import { CurrentNewsComponent } from '../../pages/current-news/current-news.component';
import { UpcommingNewsComponent } from '../../pages/upcomming-news/upcomming-news.component';
import { EventDetailComponent } from '../../pages/event/event-detail/event-detail.component';
import { CurrentNewsDetailComponent } from '../../pages/current-news/current-news-detail/current-news-detail.component';
import { UpcommingNewsDetailComponent } from '../../pages/upcomming-news/upcomming-news-detail/upcomming-news-detail.component';
import { NewsDetailComponent } from '../../pages/news/news-detail/news-detail.component';
import { ThemeDetailComponent } from '../../pages/theme-page/theme-detail/theme-detail.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { OfferAdsDetailComponent } from '../../pages/offer-ads/offer-ads-detail/offer-ads-detail.component';
import { ChangePasswordComponent } from '../../pages/change-password/change-password.component';
import { LocationComponent } from '../../pages/location/location.component';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { FilterPipe } from 'src/app/pipe/filter.pipe';
import { BlogPriorityComponent } from '../../pages/blog-priority/blog-priority.component';
import { DestinationVideosComponent } from '../../pages/destination-videos/destination-videos.component';
import { InterviewComponent } from '../../pages/interview/interview.component';
import { TrendingNewsComponent } from '../../pages/trending-news/trending-news.component';
import { FaqComponent } from '../../pages/faq/faq.component';
import { TopDestinationComponent } from '../../pages/top-destination/top-destination.component';
import { HomeComponent } from '../../pages/home/home.component';
import { TemporaryPageComponent } from '../../pages/temporary-page/temporary-page.component';

@NgModule({
  declarations: [
    DashboardComponent,
    MapComponent,
    ThemePageComponent,
    OfferAdsComponent,
    TravelCategorySubcategoryComponent,
    WhatsNewComponent,
    TravelUtilityComponent,
    NewsEventsComponent,
    DestinationComponent,
    TravelGuruExpertTravelersComponent,
    UserListPageComponent,
    PostPageComponent,
    ContactDetailsComponent,
    BlogComponent,
    PageComponent,
    BannerComponent,
    AboutUsComponent,
    SafeHtmlPipe,
    FilterPipe,
    BannerDetailComponent,
    BlogDetailComponent,
    NewsComponent,
    EventComponent,
    CurrentNewsComponent,
    UpcommingNewsComponent,
    NewsDetailComponent,
    EventDetailComponent,
    CurrentNewsDetailComponent,
    UpcommingNewsDetailComponent,
    ThemeDetailComponent,
    UserProfileComponent,
    OfferAdsComponent,
    OfferAdsDetailComponent,
    ChangePasswordComponent,
    LocationComponent,
    BlogPriorityComponent,
    HomeComponent,
    DestinationVideosComponent,
    InterviewComponent,
    TrendingNewsComponent,
    FaqComponent,
    TopDestinationComponent,
    TemporaryPageComponent,

  ],
  imports: [
    CommonModule,
    PrivateRoutingModule,
    SharedModule,
    DragDropModule,
    
  ]
})
export class PrivateModule { }
