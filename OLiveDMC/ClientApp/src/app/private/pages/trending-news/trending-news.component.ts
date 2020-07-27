import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { TrendingNewsService } from 'src/app/providers/TrendingNews/trending-news.service';

@Component({
  selector: 'app-trending-news',
  templateUrl: './trending-news.component.html',
  styleUrls: ['./trending-news.component.css']
})
export class TrendingNewsComponent implements OnInit {



  trendingNewsForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  trendingNewses:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_trendingNews: boolean = false;
  trendingNewsId: string;
  tinymceConfig: any;
  tooltipText:string ="this Trending News is show or hide to the user";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

  constructor( 
    private formBuilder : FormBuilder,
    private  trendingNewsService: TrendingNewsService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.trendingNewsForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
      featuredImage: [''],
    })
    
  }

  ngOnInit(): void {
    debugger;
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.trendingNewsService.fileUploadInTrendingNews(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/Home/TrendingNews/image/"+resp.data; 
          success(url);
      })
    }

    this.GetAllTrendingNews();
  }

 
  preview(file) {
    debugger;
    if(this.edit_trendingNews == true){
       this.editfileUploaded = true;
    }

    let files = file.files[0] 
    var mimeType = files.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(files); 
    reader.onload = (_event) => { 
      this.previewUrl = reader.result; 
    }

    this.file = files;  
    this.fileUploaded = true;
  }

  submitTrendingNewsData(){
    debugger;

    if(this.trendingNewsForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_trendingNews == true ? formData.append('Id', this.trendingNewsId) : formData.append('Id', '0'); 
      this.trendingNewsId = '0';
      if( (this.edit_trendingNews == false) || (this.edit_trendingNews == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.trendingNewsForm.get('title').value);
      formData.append('Description', this.trendingNewsForm.get('description').value);
      formData.append('ShowInFrontEnd', this.trendingNewsForm.get('showInFrontEnd').value);


      this.trendingNewsService.AddUpdateTrendingNews(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_trendingNews == true){
          Swal.fire(
            'Updated!',
            'Your Trending News has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Trending News has been Added.',
            'success'
          )
         }
          
          this.edit_trendingNews = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetTrendingNewsForm();
          // this.trendingNewsForm.reset();
          // this.trendingNewsForm.get('description').setValue('');
          this.GetAllTrendingNews();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllTrendingNews(){
    debugger;

    this.trendingNewsService.GetAllTrendingNews().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.trendingNewses = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editTrendingNews(trendingNews){
    debugger;
    this.trendingNewsForm.get('title').setValue(trendingNews.title);
    this.trendingNewsForm.get('description').setValue(trendingNews.description);
    this.trendingNewsForm.get('showInFrontEnd').setValue(trendingNews.showInFrontEnd);
   
    this.trendingNewsId = ''+trendingNews.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/Home/TrendingNews/image/'+trendingNews.featuredImage;
    this.edit_trendingNews = true;
  }

  deleteTrendingNews(id){
    debugger;

    this.spinner.show()
    this.trendingNewsService.deleteTrendingNews(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllTrendingNews();  
        Swal.fire(
          'Deleted!',
          'Your Trending News has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(trendingNewsId){
    debugger;

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this News!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteTrendingNews(trendingNewsId);
      }

    })
  }


  gotoDetailPage(trendingNews){
    debugger;
    this.router.navigate(['/private/trending-news-detail', trendingNews.id]);
  }

  resetTrendingNewsForm(){
    this.trendingNewsForm.setValue({
      title: '', 
      description: '', 
      showInFrontEnd: false, 
      featuredImage: '', 
    })
  }

}
 