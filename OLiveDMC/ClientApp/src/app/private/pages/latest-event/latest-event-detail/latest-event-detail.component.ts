import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { EventService } from 'src/app/providers/EventService/event.service';

@Component({
  selector: 'app-latest-event-detail',
  templateUrl: './latest-event-detail.component.html',
  styleUrls: ['./latest-event-detail.component.css']
})
export class LatestEventDetailComponent implements OnInit {

 
  eventId: any; 
  event: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private eventService: EventService,

  ) { 

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.eventId != null && resp.eventId != undefined){
              this.eventService.GetEventDetailByEventId(resp.eventId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.event = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }


}
