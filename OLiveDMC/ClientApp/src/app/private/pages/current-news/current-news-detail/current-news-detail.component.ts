import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NewsService } from 'src/app/providers/NewsService/news.service';
import { CurrentNewsService } from 'src/app/providers/CurrentNewsService/current-news.service';


@Component({
  selector: 'app-current-news-detail',
  templateUrl: './current-news-detail.component.html',
  styleUrls: ['./current-news-detail.component.css']
})
export class CurrentNewsDetailComponent implements OnInit {


  currentNewsId: any; 
  currentNews: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private currentNewsService: CurrentNewsService,

  ) { 

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.currentNewsId != null && resp.currentNewsId != undefined){
              this.currentNewsService.GetCurrentNewsDetailByCurrentNewsId(resp.currentNewsId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.currentNews = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }


}
