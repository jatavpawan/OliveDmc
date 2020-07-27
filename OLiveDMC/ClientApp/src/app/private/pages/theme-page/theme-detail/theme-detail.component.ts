import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { ThemeService } from 'src/app/providers/theme.service';

@Component({
  selector: 'app-theme-detail',
  templateUrl: './theme-detail.component.html',
  styleUrls: ['./theme-detail.component.css']
})
export class ThemeDetailComponent implements OnInit {


  
  themeId: any; 
  theme: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private themeService: ThemeService,

  ) { 
    

     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.themeId != null && resp.themeId != undefined){
              this.themeService.GetThemeDetailByThemeId(resp.themeId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.theme = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }
}
