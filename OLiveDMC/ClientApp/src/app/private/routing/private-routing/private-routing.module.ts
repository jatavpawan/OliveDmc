import { AuthGuard } from './../../../security/auth.guard';
import { ContactDetailsComponent } from './../../pages/contact-details/contact-details.component';
import { PostPageComponent } from './../../pages/post-page/post-page.component';
import { UserListPageComponent } from './../../pages/user-list-page/user-list-page.component';
import { TravelGuruExpertTravelersComponent } from './../../pages/travel-guru-expert-travelers/travel-guru-expert-travelers.component';
import { DestinationComponent } from './../../pages/destination/destination.component';
import { NewsEventsComponent } from './../../pages/news-events/news-events.component';
import { TravelUtilityComponent } from './../../pages/travel-utility/travel-utility.component';
import { ThemePageComponent } from './../../pages/theme-page/theme-page.component';
import { WhatsNewComponent } from './../../pages/whats-new/whats-new.component';
import { TravelCategorySubcategoryComponent } from './../../pages/travel-category-subcategory/travel-category-subcategory.component';
import { OfferAdsComponent } from './../../pages/offer-ads/offer-ads.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { MapComponent } from '../../pages/map/map.component';
import { BannerComponent } from '../../pages/banner/banner.component';
import { AboutUsComponent } from '../../pages/about-us/about-us.component';
import { PageComponent } from '../../pages/page/page.component';
import { BlogComponent } from '../../pages/blog/blog.component';
import { BannerDetailComponent } from '../../pages/banner/banner-detail/banner-detail.component';
import { BlogDetailComponent } from '../../pages/blog/blog-detail/blog-detail.component';
import { NewsComponent } from '../../pages/news/news.component';
import { EventComponent } from '../../pages/event/event.component';
import { CurrentNewsComponent } from '../../pages/current-news/current-news.component';
import { UpcommingNewsComponent } from '../../pages/upcomming-news/upcomming-news.component';
import { NewsDetailComponent } from '../../pages/news/news-detail/news-detail.component';
import { EventDetailComponent } from '../../pages/event/event-detail/event-detail.component';
import { CurrentNewsDetailComponent } from '../../pages/current-news/current-news-detail/current-news-detail.component';
import { UpcommingNewsDetailComponent } from '../../pages/upcomming-news/upcomming-news-detail/upcomming-news-detail.component';
import { ThemeDetailComponent } from '../../pages/theme-page/theme-detail/theme-detail.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { OfferAdsDetailComponent } from '../../pages/offer-ads/offer-ads-detail/offer-ads-detail.component';
import { ChangePasswordComponent } from '../../pages/change-password/change-password.component';
import { LocationComponent } from '../../pages/location/location.component';
import { BlogPriorityComponent } from '../../pages/blog-priority/blog-priority.component';
import { HomeComponent } from '../../pages/home/home.component';
import { FaqComponent } from '../../pages/faq/faq.component';
import { DestinationVideosComponent } from '../../pages/destination-videos/destination-videos.component';
import { InterviewComponent } from '../../pages/interview/interview.component';
import { TrendingNewsComponent } from '../../pages/trending-news/trending-news.component';
import { TopDestinationComponent } from '../../pages/top-destination/top-destination.component';
import { TemporaryPageComponent } from '../../pages/temporary-page/temporary-page.component';
import { LatestEventComponent } from '../../pages/latest-event/latest-event.component';
import { LatestEventDetailComponent } from '../../pages/latest-event/latest-event-detail/latest-event-detail.component';
import { InterviewInWhatsnewComponent } from '../../pages/interview-in-whatsnew/interview-in-whatsnew.component';
import { NewdestinationsInWhatsnewComponent } from '../../pages/newdestinations-in-whatsnew/newdestinations-in-whatsnew.component';
import { FestivalComponent } from '../../pages/festival/festival.component';
import { OurTeamMemberComponent } from '../../pages/our-team-member/our-team-member.component';
import { PrivacyPolicyComponent } from '../../pages/privacy-policy/privacy-policy.component';
import { AboutusIntroductionComponent } from '../../pages/aboutus-introduction/aboutus-introduction.component';
import { AboutusStatementComponent } from '../../pages/aboutus-statement/aboutus-statement.component';
import { TravelUtilityQueryComponent } from '../../pages/travel-utility-query/travel-utility-query.component';
import { ContactUsComponent } from '../../pages/contact-us/contact-us.component';
import { BlogCategoryComponent } from '../../pages/blog-category/blog-category.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'map',
    component: MapComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'theme',
    component: ThemePageComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'blog-category',
    component: BlogCategoryComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'theme-detail/:themeId',
    component: ThemeDetailComponent,
    canActivate: [AuthGuard]
  
  },

  {
    path: 'offer-ads',
    component: OfferAdsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'offerAds-detail/:offerAdsId',
    component: OfferAdsDetailComponent,
    canActivate: [AuthGuard]
  
  },

  {
    path: 'travel-category-subcategory',
    component: TravelCategorySubcategoryComponent,
    canActivate: [AuthGuard]
  
  },
  // {
  //   path: 'whats-new',
  //   component: WhatsNewComponent,
  //   canActivate: [AuthGuard]
  
  // },
  {
    path: 'travel-utility',
    component: TravelUtilityComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'news-events',
    component: NewsEventsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'destination',
    component: DestinationComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'travel-guru-expert-travelers',
    component: TravelGuruExpertTravelersComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'user',
    component: UserListPageComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'user-profile',
    component: UserProfileComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'change-password',
    component: ChangePasswordComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'post',
    component: PostPageComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'contact-details',
    component: ContactDetailsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'page',
    component: PageComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'blog',
    component: BlogComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'blog-detail/:blogId',
    component: BlogDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'banner',
    component: BannerComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'banner-detail/:bannerId',
    component: BannerDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'about-us',
    component: AboutUsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'news',
    component: NewsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'news-detail/:newsId',
    component: NewsDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'event',
    component: EventComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'event-detail/:eventId',
    component: EventDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'current-news',
    component: CurrentNewsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'current-news-detail/:currentNewsId',
    component: CurrentNewsDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'upcomming-news',
    component: UpcommingNewsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'upcomming-news-detail/:upcommingNewsId',
    component: UpcommingNewsDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'location',
    component: LocationComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'blog-priority',
    component: BlogPriorityComponent,
    canActivate: [AuthGuard]
  
  },
  // {
  //   path: 'home',
  //   component: HomeComponent,
  //   canActivate: [AuthGuard]
  
  // },
  {
    path: 'faq',
    component: FaqComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'destination-videos',
    component: DestinationVideosComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'interview',
    component: InterviewComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'trending news',
    component: TrendingNewsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'top-destination',
    component: TopDestinationComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'temporary',
    component: TemporaryPageComponent,
    canActivate: [AuthGuard]
  
  },
  
  {
    path: 'festival',
    component: FestivalComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'our-team-member',
    component: OurTeamMemberComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'privacy-policy',
    component: PrivacyPolicyComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'aboutus-introduction',
    component: AboutusIntroductionComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'aboutus-statement',
    component: AboutusStatementComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'travel-utility-query',
    component: TravelUtilityQueryComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'contact-us',
    component: ContactUsComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'home',
    component: HomeComponent,
    children: [
      {
        path: '',
        component: DestinationVideosComponent,
        canActivate: [AuthGuard]

      },
      {
        path: 'destination-videos',
        component: DestinationVideosComponent,
        canActivate: [AuthGuard]
      
      },
      {
        path: 'interview',
        component: InterviewComponent,
        canActivate: [AuthGuard]
      
      },
      {
        path: 'trending-news',
        component: TrendingNewsComponent,
        canActivate: [AuthGuard]
      
      },
      {
        path: 'top-destination',
        component: TopDestinationComponent,
        canActivate: [AuthGuard]
      
      },
      {
        path: 'theme',
        component: ThemePageComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'latest-event',
        component: LatestEventComponent,
        canActivate: [AuthGuard]
      
      },
    ]
  
  },

  // {
  //   path: 'latest-event',
  //   component: LatestEventComponent,
  //   canActivate: [AuthGuard]
  
  // },
  {
    path: 'latest-event-detail/:eventId',
    component: LatestEventDetailComponent,
    canActivate: [AuthGuard]
  
  },
  {
    path: 'WhatsNew',
    component: WhatsNewComponent,
    children: [
      {
        path: '',
        component: InterviewInWhatsnewComponent,
        canActivate: [AuthGuard]

      },
      {
        path: 'interview',
        component: InterviewInWhatsnewComponent,
        canActivate: [AuthGuard]
      
      },
      {
        path: 'newDestination',
        component: NewdestinationsInWhatsnewComponent,
        canActivate: [AuthGuard]
      
      }
    ]
  
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
export class PrivateRoutingModule { }
