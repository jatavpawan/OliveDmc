import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { ProfileCategoryService } from 'src/app/providers/ProfileCategoryService/profile-category.service';

@Component({
  selector: 'app-travel-category-subcategory',
  templateUrl: './travel-category-subcategory.component.html',
  styleUrls: ['./travel-category-subcategory.component.css']
})
export class TravelCategorySubcategoryComponent implements OnInit {

  categoryForm: FormGroup;
  categories:any =[];
  edit_category: boolean = false;
  categoryId: string;

  constructor( 
    private formBuilder : FormBuilder,
    private  categoryService: ProfileCategoryService, 
    private spinner: NgxSpinnerService,
    ) {

    this.categoryForm = this.formBuilder.group({
      id: [0],
      categoryName: [''],
    })
    
  }

  ngOnInit(): void {
    this.GetAllCategory();
  }


  submitCategoryData(){
    if(this.categoryForm.valid){
      this.spinner.show();


      this.categoryService.AddUpdateProfileCategory(this.categoryForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_category == true){
          Swal.fire(
            'Updated!',
            'Your Category has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Category has been Added.',
            'success'
          )
         }
          
          this.edit_category = false;
          this.resetCategory();
          this.GetAllCategory();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  resetCategory(){
    this.categoryForm.setValue({
      id: 0,
      categoryName: ''
    })
  }

  GetAllCategory(){
    this.categoryService.GetAllProfileCategory().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.categories = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editCategory(category){

    this.categoryForm.get('id').setValue(category.id);
    this.categoryForm.get('categoryName').setValue(category.categoryName);
    this.edit_category = true;
  }

  deleteCategory(id){

    this.spinner.show()
    this.categoryService.deleteProfileCategory(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllCategory();  
        Swal.fire(
          'Deleted!',
          'Your Category has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(categoryId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Category!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteCategory(categoryId);
      }

    })
  }
}
