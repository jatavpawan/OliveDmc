import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/model/ResponseModel';
import { BlogService } from 'src/app/providers/BlogService/blog.service';
import Swal from 'sweetalert2';
import { NgxSpinnerService } from 'ngx-spinner';
import * as $ from 'jquery';
import { EventService } from 'src/app/providers/EventService/event.service';
import { TrendingNewsService } from 'src/app/providers/TrendingNews/trending-news.service';
import { TopDestinationService } from 'src/app/providers/TopDestination/top-destination.service';
import { environment } from 'src/environments/environment';
import { ThemeService } from 'src/app/providers/theme.service';
import { DestinationVideosService } from 'src/app/providers/DestinationVideos/destination-videos.service';
import { InterviewService } from 'src/app/providers/Interview/interview.service';

declare var $: any;

@Component({
  selector: 'app-public-home',
  templateUrl: './public-home.component.html',
  styleUrls: ['./public-home.component.css']
})
export class PublicHomeComponent implements OnInit {
  blogPriorityList: Array<any> = [];
  events: Array<any> = [];
  trendingNewses: Array<any> = [];
  topDestinations: Array<any> = [];
  apiendpoint: string = environment.apiendpoint;
  blogimgsrcpath: string = "";
  trendingNewsImgsrcPath: string = "";
  eventImgsrcPath: string = "";
  destinationImgsrcPath: string = "";
  themeimgsrcpath: string = "";
  destinationVideoImgsrcpath: string = "";
  interviewImgsrcpath: string = "";
  themes: Array<any> = [];
  destinationVideos: Array<any> = [];
  interviews: Array<any> = [];


  constructor(
    private blogService: BlogService,
    private eventService: EventService,
    private trendingNewsService: TrendingNewsService,
    private topDestinationService: TopDestinationService,
    private themeService: ThemeService,
    private destinationVideosService: DestinationVideosService,
    private interviewService: InterviewService,
    private spinner: NgxSpinnerService,

  ) {
    this.blogimgsrcpath = this.apiendpoint + 'Uploads/Blog/image/';
    this.trendingNewsImgsrcPath = this.apiendpoint + 'Uploads/Home/TrendingNews/image/';
    this.eventImgsrcPath = this.apiendpoint + 'Uploads/Event/image/';
    this.destinationImgsrcPath = this.apiendpoint + 'Uploads/Home/TopDestination/image/';
    this.themeimgsrcpath = this.apiendpoint + 'Uploads/TourTheme/image/';
    this.destinationVideoImgsrcpath = this.apiendpoint + 'Uploads/Home/DestinationVideos/image/';
    this.interviewImgsrcpath = this.apiendpoint + 'Uploads/Home/Interview/image/';
  }

  ngOnInit(): void {

    //for header sticky
    $(window).scroll(function () {
      var scroll = $(window).scrollTop();
      if (scroll >= 100) {
        $("body").addClass("sticky");
      }
      else {
        $("body").removeClass("sticky");
      }
    });



    //for home page slider START
    $(document).ready(function () {
      for (var i = 1; i <= $('.slider__slide').length; i++) {
        $('.slider__indicators').append('<div class="slider__indicator" data-slide="' + i + '"></div>')
      }
      setTimeout(function () {
        $('.slider__wrap').addClass('slider__wrap--hacked');
      }, 1000);
    })

    function goToSlide(number) {
      $('.slider__slide').removeClass('slider__slide--active');
      $('.slider__slide[data-slide=' + number + ']').addClass('slider__slide--active');
    }

    $('.slider__next, .go-to-next').on('click', function () {
      var currentSlide = Number($('.slider__slide--active').data('slide'));
      var totalSlides = $('.slider__slide').length;
      currentSlide++
      if (currentSlide > totalSlides) {
        currentSlide = 1;
      }
      goToSlide(currentSlide);
    })
    //for home page slider END

    var owl = $('.screenshot_slider').owlCarousel({
      loop: true,
      responsiveClass: true,
      nav: true,
      margin: 0,
      autoplayTimeout: 3000,
      smartSpeed: 400,
      autoplay: true,
      center: true,
      navText: ['&#8592;', '&#8594;'],
      responsive: {
        0: {
          items: 1,
        },
        600: {
          items: 3
        },
        1200: {
          items: 3
        }
      }
    });

    /****************************/

    $(document.documentElement).keydown(function (event) {

      // var owl = jQuery("#carousel");

      // handle cursor keys
      if (event.keyCode == 37) {
        // go left
        owl.trigger('prev.owl.carousel', [400]);
        //owl.trigger('owl.prev');
      } else if (event.keyCode == 39) {
        // go right
        owl.trigger('next.owl.carousel', [400]);
        //owl.trigger('owl.next');
      }

    });

    //for destination video slider END

    //for theme Based Packages START
    $('#theme-based').owlCarousel({
      loop: true,
      margin: 20,
      dots: false,
      nav: true,
      autoplay: true,
      autoplaySpeed: 3000,
      navText: ['&#8592;', '&#8594;'],
      responsive: {
        0: {
          items: 1
        },
        600: {
          items: 2
        },
        1000: {
          items: 4
        }
      }
    });
    //for theme Based Packages END

    //for interview video START
    $('#owl-interview-video').owlCarousel({
      loop: true,
      margin: 0,
      dots: false,
      nav: true,
      autoplay: true,
      autoplaySpeed: 2000,
      navText: ['&#8592;', '&#8594;'],
      responsive: {
        0: {
          items: 1
        },
        600: {
          items: 1
        },
        1000: {
          items: 1
        }
      }
    });
    //for interview video END

    this.getBlogPriorityList();
    this.GetAllEvent();
    this.GetAllTrendingNews();
    this.GetAllTopDestination();
    this.GetAllTourTheme();
    this.GetAllDestinationVideo();
    this.GetAllInterview();

  }

  getBlogPriorityList() {
    this.blogService.getAllBlogPriorityList().subscribe(resp => {
      if (resp.status == Status.Success) {
        if (resp.data != undefined && resp.data.length > 6) {
          resp.data.length = 6
        }
        this.blogPriorityList = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })

  }

  GetAllEvent() {
    this.eventService.GetAllEvent().subscribe(resp => {
      if (resp.status == Status.Success) {
        // debugger;
        // if(resp.data != undefined && resp.data.length >4){
        //   resp.data.length = 4
        // }
        this.events = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

  GetAllTrendingNews() {

    this.trendingNewsService.GetAllTrendingNews().subscribe(resp => {
      if (resp.status == Status.Success) {
        if (resp.data != undefined && resp.data.length > 8) {
          resp.data.length = 8
        }
        this.trendingNewses = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

  GetAllTopDestination() {

    this.topDestinationService.GetAllTopDestination().subscribe(resp => {
      if (resp.status == Status.Success) {
        this.topDestinations = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

  GetAllTourTheme() {
    this.themeService.GetAllTourTheme().subscribe(resp => {
      if (resp.status == Status.Success) {
        debugger;
        this.themes = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }


  GetAllDestinationVideo() {
    this.destinationVideosService.GetAllDestinationVideos().subscribe(resp => {
      if (resp.status == Status.Success) {
        debugger;
        this.destinationVideos = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

  GetAllInterview() {
    this.interviewService.GetAllInterview().subscribe(resp => {
      if (resp.status == Status.Success) {
        debugger;
        this.interviews = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

}
