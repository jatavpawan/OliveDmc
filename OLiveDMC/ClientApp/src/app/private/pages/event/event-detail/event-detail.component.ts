import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { EventService } from 'src/app/providers/EventService/event.service';


@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {

  
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
