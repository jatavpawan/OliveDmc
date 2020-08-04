import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  // private canvas: HTMLCanvasElement;
  private canvas: any;
  @ViewChild('canvas') canvasRef: ElementRef;
  @ViewChild('video') video: ElementRef;
  file:any;


  constructor(private window: Window) { }

  ngOnInit(): void {
  }

 
  ngAfterViewInit() {
    this.canvas = this.canvasRef!.nativeElement;
  }


   capture() {
    // var canvas = document.getElementById('canvas') ;     
    // var video = document.getElementById('video');
    debugger;
    console.log("this.file", this.file);
    this.canvas.width = this.video.nativeElement.videoWidth;
    this.canvas.height = this.video.nativeElement.videoHeight;
    // this.canvas.width = 1000;
    // this.canvas.height = 500;
    console.log("this.canvas.width", this.canvas.width);
    this.canvas.getContext('2d').drawImage(this.video.nativeElement, 0, 0, this.video.nativeElement.videoWidth, this.video.nativeElement.videoHeight);  
    // this.canvas.getContext('2d').drawImage(this.video.nativeElement, 0, 0, 1000, 500);  
    // var fullQuality = this.canvas.toDataURL('image/jpeg', 1.0);
    var base64_image = this.canvas.toDataURL();
    
    let base64image =base64_image;
    var byteString = window.atob(''+base64image);
    console.log(byteString);
    var ab = new ArrayBuffer(byteString.length);
    var ia = new Uint8Array(ab);
    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }
    var blob = new Blob([ia], { type: 'image/jpeg'});
    // let url = base_url+'/uploads/'+element.small;
    // let urlfilename = url.match(/.*\/(.*)$/)[1];
    // let extension = url.split(/\#|\?/)[0].split('.').pop().trim();
    // let type = extension == "png" ? "image/png" : extension == "jpg" || extension == "jpeg" ? "image/jpeg" : extension == "gif" ? "image/gif" : " ";

    // if(type != " "){
      var file = new File([blob], "shubham.png", {type: 'image/png'});
      // this.uploadedFiles.push(file);
    // }

    // console.log(fullQuality);
    
    // this.canvas.toBlob(blob => {
    //   const img = new Image();
    //   // debugger;
    //   var url1:any =  window.URL;
    //   img.src = url1.createObjectUrl(blob);
    //   this.file = new File([blob], "file_name", {lastModified: 1534584790000});

    //   console.log('src',url1.createObjectUrl(blob));
    //   let reader = new FileReader();
    //   reader.readAsDataURL(blob); // converts the blob to base64 and calls onload

    //   reader.onload = function() {
    //     // link.href = reader.result; // data url
    //     // link.click();
    //     console.log("reader.result", reader.result);
    //   };


    //   // let base64image =element.base64_image;
    //   // var byteString = atob(base64image);
    //   // console.log(byteString);
    //   // var ab = new ArrayBuffer(byteString.length);
    //   // var ia = new Uint8Array(ab);
    //   // for (var i = 0; i < byteString.length; i++) {
    //   //     ia[i] = byteString.charCodeAt(i);
    //   // }
    //   // var blob = new Blob([ia], { type: 'image/jpeg'});
    //   // let url = base_url+'/uploads/'+element.small;
    //   // let urlfilename = url.match(/.*\/(.*)$/)[1];
    //   // let extension = url.split(/\#|\?/)[0].split('.').pop().trim();
    //   // let type = extension == "png" ? "image/png" : extension == "jpg" || extension == "jpeg" ? "image/jpeg" : extension == "gif" ? "image/gif" : " ";
  
    //   // if(type != " "){
    //   //   var file = new File([blob], urlfilename, {type: type});
    //   //   this.uploadedFiles.push(file);
    //   // }
    //   // window.saveAs(blob, 'image.png');
    // });

    
  }




}
