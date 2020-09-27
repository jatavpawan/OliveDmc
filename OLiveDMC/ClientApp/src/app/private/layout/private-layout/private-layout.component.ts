import { Component, OnInit, ElementRef } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
declare const $: any;


@Component({
  selector: 'app-private-layout',
  templateUrl: './private-layout.component.html',
  styleUrls: ['./private-layout.component.scss']
})
export class PrivateLayoutComponent implements OnInit {

  private listTitles: any[];
  location: Location;
  private toggleButton: any;
  private sidebarVisible: boolean;
  userData: any;
  menuItems: any[];


  constructor( location: Location,  private element: ElementRef, private router: Router, private authService: AuthenticationService ) {
    this.location = location;
        this.sidebarVisible = false;
    
    this.userData = JSON.parse( this.authService.getUserdata());
  }

  ngOnInit(){
    this.listTitles = [
      { path: '/private/dashboard', title: 'Dashboard',  icon: 'pe-7s-graph', class: '' },
      { path: '/private/temporary', title: 'Temporary',  icon: 'pe-7s-graph', class: '' },
      { path: '/private/latest-event', title: 'Latest Event',  icon: 'pe-7s-graph', class: '' },
      { path: '/private/home', title: 'Home',  icon: 'pe-7s-graph', class: '' },
      { path: '/private/map', title: 'Destination',  icon:'pe-7s-map-marker', class: '' },
      { path: '/private/theme', title: 'Theme',  icon:'pe-7s-user', class: '' },
      { path: '/private/offer-ads', title: 'Offer or Ads',  icon:'pe-7s-note2', class: '' },
      { path: '/private/travel-category-subcategory', title: 'Profile Category',  icon:'pe-7s-news-paper', class: '' },
      { path: '/private/blog-category', title: 'Blog Category',  icon:'pe-7s-news-paper', class: '' },
      { path: '/private/whats-new', title: 'What’s New',  icon:'pe-7s-science', class: '' },
      { path: '/private/travel-utility', title: 'Travel Utility',  icon:'pe-7s-note2', class: '' },
      { path: '/private/news-events', title: 'New’s and events',  icon:'pe-7s-news-paper', class: '' },
      // { path: '/private/destination', title: 'Destination',  icon:'pe-7s-note2', class: '' },
      { path: '/private/travel-guru-expert-travelers', title: 'Travel Guru and Expert Travelers',  icon:'pe-7s-note2', class: '' },
      { path: '/private/user', title: 'User',  icon:'pe-7s-note2', class: '' },
      { path: '/private/post', title: 'Post',  icon:'pe-7s-note2', class: '' },
      { path: '/private/contact-details', title: 'Contact details',  icon:'pe-7s-note2', class: '' },
      { path: '/private/page', title: 'Page',  icon:'pe-7s-note2', class: '' },
      { path: '/private/blog', title: 'Blog',  icon:'pe-7s-note2', class: '' },
      { path: '/private/banner', title: 'Banner',  icon:'pe-7s-note2', class: '' },
      { path: '/private/about-us', title: 'About Us',  icon:'pe-7s-note2', class: '' },
      { path: '/private/blog-detail/:blogId', title: 'Blog Detail',  icon:'pe-7s-note2', class: '' },
      { path: '/private/banner-detail/:bannerId', title: 'Banner Detail',  icon:'pe-7s-note2', class: '' },
      { path: '/private/event', title: 'Event',  icon:'pe-7s-note2', class: '' },
      { path: '/private/news', title: 'News',  icon:'pe-7s-note2', class: '' },
      { path: '/private/current-news', title: 'Current News',  icon:'pe-7s-note2', class: '' },
      { path: '/private/upcomming-news', title: 'Upcomming News',  icon:'pe-7s-note2', class: '' },
      { path: '/private/news-detail/:newsId', title: 'News Detail',  icon:'pe-7s-note2', class: '' },
      { path: '/private/event-detail/:eventId', title: 'Event Detail',  icon:'pe-7s-note2', class: '' },
      { path: '/private/current-news-detail/:currentNewsId', title: 'Current News Detail',  icon:'pe-7s-note2', class: '' },
      { path: '/private/upcomming-news-detail/:upcommingNewsId', title: 'Upcomming News Detail',  icon:'pe-7s-note2', class: '' },
      { path: '/private/user-profile', title: 'User Profile',  icon:'pe-7s-note2', class: '' },
      { path: '/private/location', title: 'Location',  icon:'pe-7s-note2', class: '' },
      { path: '/private/blog-priority', title: 'Blog Priority',  icon:'pe-7s-note2', class: '' },
      { path: '/private/faq', title: 'FAQ',  icon:'pe-7s-note2', class: '' },
      { path: '/private/festival', title: 'Festival',  icon:'pe-7s-note2', class: '' },
      { path: '/private/destination-videos', title: 'Destination Videos',  icon:'pe-7s-note2', class: '' },
      { path: '/private/interview', title: 'Interview',  icon:'pe-7s-note2', class: '' },
      { path: '/private/trending news', title: 'Trending News',  icon:'pe-7s-note2', class: '' },
      { path: '/private/top-destination', title: 'Top destination',  icon:'pe-7s-note2', class: '' },
      
      { path: '/private/home/destination-videos', title: 'Destination Videos',  icon:'pe-7s-note2', class: '' },
      { path: '/private/home/interview', title: 'Interview',  icon:'pe-7s-note2', class: '' },
      { path: '/private/home/trending-news', title: 'Trending News',  icon:'pe-7s-note2', class: '' },
      { path: '/private/home/top-destination', title: 'Top destination',  icon:'pe-7s-note2', class: '' },
      { path: '/private/home/theme', title: 'Theme',  icon:'pe-7s-note2', class: '' },
      { path: '/private/WhatsNew/interview', title: 'Interview',  icon:'pe-7s-note2', class: '' },
      { path: '/private/WhatsNew/newDestination', title: 'New Destinations',  icon:'pe-7s-note2', class: '' },
      { path: '/private/our-team-member', title: 'Team Member',  icon:'pe-7s-note2', class: '' },
      { path: '/private/aboutus-introduction', title: 'About Us Introduction',  icon:'pe-7s-note2', class: '' },
      { path: '/private/aboutus-statement', title: 'About Us Statement',  icon:'pe-7s-note2', class: '' },
      { path: '/private/travel-utility-query', title: 'Travel Utility Query',  icon:'pe-7s-note2', class: '' },
      { path: '/private/contact-us', title: 'Contact Us',  icon:'pe-7s-note2', class: '' },
      { path: '/private/privacy-policy', title: 'Privacy Policy',  icon:'pe-7s-note2', class: '' },
      { path: '/private/skills', title: 'Skills',  icon:'pe-7s-note2', class: '' },
      { path: '/private/areaOfExpertise', title: 'Area Of Expertise',  icon:'pe-7s-note2', class: '' },
      { path: '/private/student-career', title: 'Student Career',  icon:'pe-7s-note2', class: '' },
      { path: '/private/fresher-career', title: 'Fresher Career',  icon:'pe-7s-note2', class: '' },
      { path: '/private/professional-career', title: 'Professional Career',  icon:'pe-7s-note2', class: '' },
      
    ]
    this.menuItems = [
      { path: '/private/dashboard', title: 'Dashboard',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/temporary', title: 'Temporary',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      { path: '/private/home/destination-videos', title: 'Home',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      { path: '/private/map', title: 'Destination',  icon:'pe-7s-map-marker', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/WhatsNew/interview', title: 'WhatsNew',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
     
      // { path: '/private/latest-event', title: 'Latest Event',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/festival', title: 'Festival',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/our-team-member', title: 'Team Member',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/aboutus-introduction', title: 'About Us Introduction',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/aboutus-statement', title: 'About Us Statement',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/travel-utility-query', title: 'Travel Utility Query',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/contact-us', title: 'Contact Us',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/privacy-policy', title: 'Privacy Policy',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '', title: 'Destination',  icon:'pe-7s-note2', class: '', id:"Destination", datatarget:"#Destination",
      //   child: [ 
      //     {path: '/private/map', title: 'Map',  icon:'pe-7s-map-marker', class: '', firstChar: 'M'},
      //   ] 
      // },
      // { path: '/private/theme', title: 'Theme',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/offer-ads', title: 'Offer or Ads',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/blog-category', title: 'Blog Category',  icon:'pe-7s-news-paper', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/whats-new', title: 'What’s New',  icon:'pe-7s-science', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/travel-utility', title: 'Travel Utility',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/news-events', title: 'New’s and events',  icon:'pe-7s-news-paper', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/destination', title: 'Destination',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      
      // <------------------------------------------developer pages Start------------------------------------> 
      // { path: '/private/travel-category-subcategory', title: 'Profile Category',  icon:'pe-7s-news-paper', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/travel-guru-expert-travelers', title: 'Travel Guru and Expert Travelers',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/user', title: 'User',  icon:'pe-7s-user', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/post', title: 'Post',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/contact-details', title: 'Contact details',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/page', title: 'Page',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      
      // <------------------------------------------developer Pages End------------------------------------> 
      
      
      // { path: '/private/blog', title: 'Blog',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/blog-priority', title: 'Blog Priority',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/faq', title: 'FAQ',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/destination-videos', title: 'Destination Videos',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/interview', title: 'Interview',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/trending news', title: 'Trending News',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/top-destination', title: 'Top destination',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/banner', title: 'Banner',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/about-us', title: 'About Us',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '', title: 'Settings',  icon:'pe-7s-note2', class: '',id: "Settings", datatarget: "#Settings",
      //   child: [ 
      //     {path: '/private/blog', title: 'Blog',  icon:'pe-7s-note2', class: '', firstChar: 'B'},
      //     {path: '/private/banner', title: 'Banner',  icon:'pe-7s-note2', class: '',  firstChar: 'B'},
      //   ] 
      // },
    ];
  
    const navbar: HTMLElement = this.element.nativeElement;
    this.toggleButton = navbar.getElementsByClassName('navbar-toggle')[0];
  }
  sidebarOpen() {
      const toggleButton = this.toggleButton;
      const body = document.getElementsByTagName('body')[0];
      setTimeout(function(){
          toggleButton.classList.add('toggled');
      }, 500);
      body.classList.add('nav-open');

      this.sidebarVisible = true;
  };
  sidebarClose() {
      const body = document.getElementsByTagName('body')[0];
      this.toggleButton.classList.remove('toggled');
      this.sidebarVisible = false;
      body.classList.remove('nav-open');
  };
  sidebarToggle() {
      // const toggleButton = this.toggleButton;
      // const body = document.getElementsByTagName('body')[0];
      if (this.sidebarVisible === false) {
          this.sidebarOpen();
      } else {
          this.sidebarClose();
      }
  };

  getTitle(){
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if(titlee.charAt(0) === '#'){
        titlee = titlee.slice( 1 );
    }

    for(var item = 0; item < this.listTitles.length; item++){
        if(this.listTitles[item].path === titlee){
            return this.listTitles[item].title;
        }
    }
    return 'Dashboard';
  }

  logout(){
    localStorage.removeItem("LoggedInUser");
    localStorage.removeItem("id_token");
    this.router.navigate(['landing'])
  }

  testing(){
    this.authService.testing().subscribe(resp=>{

    })
  }

  isMobileMenu() {
    if ($(window).width() > 991) {
        return false;
    }
    return true;
  }
}
