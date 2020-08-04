import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as $ from 'jquery';

declare var $: any;

@Component({
  selector: 'app-public-layout',
  templateUrl: './public-layout.component.html',
  styleUrls: ['./public-layout.component.scss']
})
export class PublicLayoutComponent implements OnInit {

  showheader: boolean = true;
  href: string;
  showfooter: boolean = true;
 

  constructor(private router: Router) {

    this.href = this.router.url;
    if (
      this.href == "/public/login"
      || this.href == "/public/signUp"
      || this.href == "/public/sendmail-forgotpassword"
    ){
       this.showheader = false;
       this.showfooter = false;
    }
    else{
       this.showheader =  true;
       this.showfooter =  true;
    }
      console.log("header url", this.router.url);
  }



  ngOnInit(): void {
    $('.closeIcn > span, .overlay ').click(function () {
      $('body').removeClass('open-menu');
    });


    $('.mobile-nav ').click(function () {
      $('body').toggleClass('open-menu');
    });


    //for dropdown in service start
    $(".dropdown-link").click(function () {
      $("body").toggleClass("main");
    });
    //for dropdown in service end

    //Responsive menu slide

    $(document).ready(function () {
      $('.parent span').click(function () {
        $(this).parent('.parent').siblings().removeClass('active');
        $(this).parent('.parent').toggleClass('active');
        $(this).parent('.parent').siblings().children('ul').slideUp();
        $(this).parent('.parent').children('ul').slideToggle();
      });
    });

  }

  
  hideHeader(){
     this.showheader =  false;
      
      $(".footer-bg").css("display", "none");
  }
}
