import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

declare var $: any;

@Component({
  selector: 'app-public-destination-finder',
  templateUrl: './public-destination-finder.component.html',
  styleUrls: ['./public-destination-finder.component.css']
})
export class PublicDestinationFinderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    //for theme Based Packages on destionation finder page START
$('#theme-of-pacakge').owlCarousel({
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
      items: 4
    }
  }
  });
  //for theme Based Packages on destionation finder page END

  
//for list of theme Based Packages on destionation finder page START
$('#list-of-top-pacakge').owlCarousel({
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
      items: 4
    }
  }
  });
  //for list of theme Based Packages on destionation finder page END
  }

}
