import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { UpcommingNewsService } from 'src/app/providers/UpcommingNewsService/upcomming-news.service';

@Component({
  selector: 'app-upcomming-news-detail',
  templateUrl: './upcomming-news-detail.component.html',
  styleUrls: ['./upcomming-news-detail.component.css']
})
export class UpcommingNewsDetailComponent implements OnInit {

  upcommingNewsId: any; 
  upcommingNews: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private upcommingNewsService: UpcommingNewsService,

  ) { 
    

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.upcommingNewsId != null && resp.upcommingNewsId != undefined){
              this.upcommingNewsService.GetUpcommingNewsDetailByUpcommingNewsId(resp.upcommingNewsId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.upcommingNews = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }

}
