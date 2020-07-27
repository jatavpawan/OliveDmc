import { Component, OnInit } from '@angular/core';
declare const $: any;

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit(): void {
    this.menuItems = [
      { path: '/private/dashboard', title: 'Dashboard',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '/private/temporary', title: 'Temporary',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      { path: '/private/home/destination-videos', title: 'Home',  icon: 'pe-7s-graph', class: '', child: [], id: "", datatarget: "" },
      // { path: '', title: 'Destination',  icon:'pe-7s-note2', class: '', id:"Destination", datatarget:"#Destination",
      //   child: [ 
      //     {path: '/private/map', title: 'Map',  icon:'pe-7s-map-marker', class: '', firstChar: 'M'},
      //   ] 
      // },
      { path: '/private/map', title: 'Destination',  icon:'pe-7s-map-marker', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/theme', title: 'Theme',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/offer-ads', title: 'Offer or Ads',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/travel-category-subcategory', title: 'Profile Category',  icon:'pe-7s-news-paper', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/whats-new', title: 'What’s New',  icon:'pe-7s-science', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/travel-utility', title: 'Travel Utility',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/news-events', title: 'New’s and events',  icon:'pe-7s-news-paper', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/destination', title: 'Destination',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/travel-guru-expert-travelers', title: 'Travel Guru and Expert Travelers',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/user', title: 'User',  icon:'pe-7s-user', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/post', title: 'Post',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/contact-details', title: 'Contact details',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/page', title: 'Page',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/blog', title: 'Blog',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/blog-priority', title: 'Blog Priority',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/faq', title: 'FAQ',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/destination-videos', title: 'Destination Videos',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/interview', title: 'Interview',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/trending news', title: 'Trending News',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      { path: '/private/top-destination', title: 'Top destination',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/banner', title: 'Banner',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '/private/about-us', title: 'About Us',  icon:'pe-7s-note2', class: '',child: [], id: "", datatarget: "" },
      // { path: '', title: 'Settings',  icon:'pe-7s-note2', class: '',id: "Settings", datatarget: "#Settings",
      //   child: [ 
      //     {path: '/private/blog', title: 'Blog',  icon:'pe-7s-note2', class: '', firstChar: 'B'},
      //     {path: '/private/banner', title: 'Banner',  icon:'pe-7s-note2', class: '',  firstChar: 'B'},
      //   ] 
      // },
    ];
  }

  isMobileMenu() {
    if ($(window).width() > 991) {
        return false;
    }
    return true;
  }
}
