import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from 'src/app/providers/BlogService/blog.service';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
  styleUrls: ['./blog-detail.component.css']
})
export class BlogDetailComponent implements OnInit {

  blogId: any; 
  blog: any;
  apiendpoint:any;
  constructor(
     private activatedRoute: ActivatedRoute,
     private blogService: BlogService,

  ) { 
     this.apiendpoint = environment.apiendpoint;
      this.activatedRoute.params.subscribe(resp=>{
          if(resp.blogId != null && resp.blogId != undefined){
              this.blogService.GetBlogDetailByBlogId(resp.blogId).subscribe(resp =>{
                 if(resp.status == Status.Success){
                    this.blog = resp.data;
                 }
              })
          }
      })

  }

  ngOnInit(): void {
  }

}
