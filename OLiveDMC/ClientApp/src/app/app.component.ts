import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
// export class AppComponent implements OnInit{
export class AppComponent{
  title = 'app';
    
//   cities2 = [
//     {id: 1, name: 'Vilnius'},
//     {id: 2, name: 'Kaunas'},
//     {id: 3, name: 'Pavilnys', disabled: true},
//     {id: 4, name: 'Pabradė'},
//     {id: 5, name: 'Klaipėda'}
// ];
  // constructor(private spinner: NgxSpinnerService) { }

  // ngOnInit() {
  //   /** spinner starts on init */
  //   this.spinner.show();
 
  //   setTimeout(() => {
  //     /** spinner ends after 5 seconds */
  //     this.spinner.hide();
  //   }, 5000);
  // }
}
