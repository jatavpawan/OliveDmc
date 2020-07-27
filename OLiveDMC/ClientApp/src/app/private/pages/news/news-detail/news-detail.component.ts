import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NewsService } from 'src/app/providers/NewsService/news.service';

@Component({
  selector: 'app-news-detail',
  templateUrl: './news-detail.component.html',
  styleUrls: ['./news-detail.component.css']
})
export class NewsDetailComponent implements OnInit {

 
  newsId: any; 
  news: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private newsService: NewsService,

  ) { 

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.newsId != null && resp.newsId != undefined){
              this.newsService.GetNewsDetailByNewsId(resp.newsId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.news = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }

}
