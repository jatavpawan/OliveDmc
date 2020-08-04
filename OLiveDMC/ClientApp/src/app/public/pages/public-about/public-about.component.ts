import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

declare var $: any;
@Component({
  selector: 'app-public-about',
  templateUrl: './public-about.component.html',
  styleUrls: ['./public-about.component.css']
})
export class PublicAboutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    // $('.owl-carousel').owlCarousel();

   // Loader
$(window).on('load', function () {
  $('.loader').fadeOut(1000);
});

//for header sticky
$(window).scroll(function(){
var scroll = $(window).scrollTop();
if (scroll >= 100) {
  $("body").addClass("sticky");
}
else{ 
  $("body").removeClass("sticky");
}
});


//for about us team mambers START
$('#about-team-members').owlCarousel({
loop: true,
margin: 20,
dots:false,
nav: true,
autoplay: true,
autoplaySpeed:3000,
navText: ['&#8592;', '&#8594;'],
responsive: {
  0: {
    items: 1
  },
  600: {
    items: 2
  },
  1000: {
    items: 3
  }
}
});
//for about us team mambers END



  }

}
