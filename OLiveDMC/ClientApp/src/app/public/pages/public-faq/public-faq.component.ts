import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

declare var $: any;

@Component({
  selector: 'app-public-faq',
  templateUrl: './public-faq.component.html',
  styleUrls: ['./public-faq.component.css']
})
export class PublicFaqComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
     //ACCORDION WITH TOGGLE ICONS//

     function toggleIcon(e) {
      $(e.target)
        .prev('.panel-heading')
        .find(".more-less")
        .toggleClass('fa fa-plus fa fa-minus');
    }
    $('.panel-group').on('hidden.bs.collapse', toggleIcon);
    $('.panel-group').on('shown.bs.collapse', toggleIcon);
  }

}
