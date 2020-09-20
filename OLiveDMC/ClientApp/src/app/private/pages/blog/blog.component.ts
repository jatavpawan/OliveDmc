import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { BlogService } from 'src/app/providers/BlogService/blog.service';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { BlogCategoryService } from 'src/app/providers/BlogCategoryService/blog-category.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  blogForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  blogs:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_blog: boolean = false;
  blogId: string;
  tinymceConfig: any;
  tooltipText:string ="this blog is show or hide to the user";
  characterCount:number = 0;
  categories:Array<any> = [];

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

  constructor( 
    private formBuilder : FormBuilder,
    private  blogService: BlogService, 
    private spinner: NgxSpinnerService,
    private categoryService: BlogCategoryService,
    private authService: AuthenticationService,
    ) {

    this.blogForm = this.formBuilder.group({
      userId: [0],
      title: ['', Validators.required],
      shortDescription: ['', Validators.required],
      description: ['', Validators.required],
      category: ['0', Validators.required],
      approvalStatus: [true],
      status: [true],
      featuredImage: [''],
    })
    
    var loginUserData = JSON.parse (authService.getUserdata());
    this.blogForm.get('userId').setValue(loginUserData.id);
    this.GetAllCategory();
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.blogService.fileUploadInBlog(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/Blog/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllBlog();
  }

 
  preview(file) {
    if(this.edit_blog == true){
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

  submitBlogData(){
    debugger
    if(this.blogForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_blog == true ? formData.append('Id', this.blogId) : formData.append('Id', '0'); 
      this.blogId = '0';
      if( (this.edit_blog == false) || (this.edit_blog == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }
      formData.append('userId', this.blogForm.get('userId').value);
      formData.append('Title', this.blogForm.get('title').value);
      formData.append('Category', this.blogForm.get('category').value);
      formData.append('Description', this.blogForm.get('description').value);
      formData.append('ShortDescription', this.blogForm.get('shortDescription').value);
      formData.append('Status', this.blogForm.get('status').value);
      formData.append('ApprovalStatus', this.blogForm.get('approvalStatus').value);

      this.blogService.AddUpdateBlog(formData).subscribe(resp=>{
        this.spinner.hide();
     
        if(resp.status == Status.Success){
         if(this.edit_blog == true){
          Swal.fire(
            'Updated!',
            'Your Blog has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Blog has been Added.',
            'success'
          )
         }
          
          this.edit_blog = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetBlogForm();
          this.GetAllBlog();
        }
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        }  
      })    
    }
  }

  GetAllBlog(){
    this.spinner.show();

    this.blogService.GetAllBlog().subscribe(resp=>{
      this.spinner.hide();
      if(resp.status == Status.Success){
          this.blogs = resp.data;
      } 
      else{
      this.spinner.hide();

        // Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  editBlog(blog){

    this.blogForm.get('userId').setValue(blog.userId);
    this.blogForm.get('title').setValue(blog.title);
    this.blogForm.get('category').setValue(blog.category);
    this.blogForm.get('description').setValue(blog.description);
    this.blogForm.get('status').setValue(blog.status);
    this.blogForm.get('approvalStatus').setValue(blog.approvalStatus);
    this.blogForm.get('shortDescription').setValue(blog.shortDescription);
   
    this.blogId = ''+blog.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/Blog/image/'+blog.featuredImage;
    this.edit_blog = true;
  }

  deleteBlog(id){

    this.spinner.show()
    this.blogService.deleteBlog(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllBlog();  
        Swal.fire(
          'Deleted!',
          'Your Blog has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(blogId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Blog!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteBlog(blogId);
      }

    })
  }

  resetBlogForm(){  

    this.blogForm.setValue({
      userId: '0',
      title: '', 
      category: '0', 
      shortDescription: '',
      description: '', 
      approvalStatus: true, 
      status: true, 
      featuredImage: '', 
    })

  }

  shortDescriptionCharacterCount(event): boolean{
    if(this.blogForm.get('shortDescription').value.length >=200  && event.keyCode != 8 ){
      let shortDescription:string = this.blogForm.get('shortDescription').value;
      this.blogForm.get('shortDescription').setValue(shortDescription.substring(0,200));
      this.characterCount =  this.blogForm.get('shortDescription').value.length;
      return false;
    }
    this.characterCount =  this.blogForm.get('shortDescription').value.length;
    return true;
  }

  GetAllCategory(){
    this.categoryService.GetAllBlogCategory().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.categories = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }
}




