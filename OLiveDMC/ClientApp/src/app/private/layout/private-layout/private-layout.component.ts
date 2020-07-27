import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router, NavigationStart, NavigationEnd } from '@angular/router';
import { Location, LocationStrategy, PathLocationStrategy, PopStateEvent } from '@angular/common';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-private-layout',
  templateUrl: './private-layout.component.html',
  styleUrls: ['./private-layout.component.css']
})
export class PrivateLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
}
