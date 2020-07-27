import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from 'src/app/providers/BlogService/blog.service';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { BannerService } from 'src/app/providers/BannerService/banner.service';

@Component({
  selector: 'app-banner-detail',
  templateUrl: './banner-detail.component.html',
  styleUrls: ['./banner-detail.component.css']
})
export class BannerDetailComponent implements OnInit {

 
  bannerId: any; 
  banner: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private bannerService: BannerService,

  ) { 

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.bannerId != null && resp.bannerId != undefined){
              this.bannerService.GetBannerDetailByBannerId(resp.bannerId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.banner = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }
}
