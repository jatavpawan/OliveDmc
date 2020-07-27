import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OfferAdsService } from 'src/app/providers/OfferAdsService/offer-ads.service';
import { environment } from 'src/environments/environment';
import { Status } from 'src/app/model/ResponseModel';

@Component({
  selector: 'app-offer-ads-detail',
  templateUrl: './offer-ads-detail.component.html',
  styleUrls: ['./offer-ads-detail.component.css']
})
export class OfferAdsDetailComponent implements OnInit {

  
  offerAdsId: any; 
  apiendpoint:any;
  offerAds: any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private offerAdsService: OfferAdsService,

  ) { 
    

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.offerAdsId != null && resp.offerAdsId != undefined){
              this.offerAdsService.GetOfferAdsDetailByOfferAdsId(resp.offerAdsId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                  this.offerAds = resp.data;
                  console.log(this.offerAds.createdDate);
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }

}
