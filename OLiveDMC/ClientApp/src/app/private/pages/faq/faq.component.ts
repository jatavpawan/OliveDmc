import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { FaqService } from 'src/app/providers/FAQ/faq.service';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FaqComponent implements OnInit {



  faqForm: FormGroup;
  faqs:any =[];
  apiendpoint:string = environment.apiendpoint;
  edit_faq: boolean = false;
  faqId: string;
  tinymceConfig: any;
  tooltipText:string ="this FAQ is show or hide to the user";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

  constructor( 
    private formBuilder : FormBuilder,
    private  faqService: FaqService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.faqForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
    })
    
  }

  ngOnInit(): void {
    debugger;
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.faqService.fileUploadInFaq(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/FAQ/image/"+resp.data; 
          success(url);
      })
    }

    this.GetAllFaq();
  }

  submitFaqData(){
    debugger;
    if(this.faqForm.valid){
      this.spinner.show();
      let dataobj  = {
        Id  : this.edit_faq == true ?  this.faqId : '0',
        ...this.faqForm.value
      }
      // this.edit_faq == true ? formData.append('Id', this.faqId) : formData.append('Id', '0'); 
      // this.faqId = '0';
      // formData.append('Title', this.faqForm.get('title').value);
      // formData.append('Description', this.faqForm.get('description').value);
      // formData.append('ShowInFrontEnd', this.faqForm.get('showInFrontEnd').value);

      this.faqService.AddUpdateFaq(dataobj).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_faq == true){
          Swal.fire(
            'Updated!',
            'Your FAQ has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your FAQ has been Added.',
            'success'
          )
         }
          
          this.edit_faq = false;
          this.resetFaqForm();
          // this.faqForm.reset();
          // this.faqForm.get('description').setValue('');
          this.GetAllFaq();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllFaq(){
    debugger;
    this.faqService.GetAllFaq().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.faqs = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editFaq(faq){
    debugger;
    this.faqForm.get('title').setValue(faq.title);
    this.faqForm.get('description').setValue(faq.description);
    this.faqForm.get('showInFrontEnd').setValue(faq.showInFrontEnd);
   
    this.faqId = ''+faq.id; 
    this.edit_faq = true;
  }

  deleteFaq(id){
    debugger;
    this.spinner.show()
    this.faqService.deleteFaq(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllFaq();  
        Swal.fire(
          'Deleted!',
          'Your FAQ has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(faqId){
    debugger;
    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this FAQ!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteFaq(faqId);
      }

    })
  }

  gotoDetailPage(faq){
    debugger;
    this.router.navigate(['/private/faq-detail', faq.id]);
  }

  resetFaqForm(){
    this.faqForm.setValue({
      title: '', 
      description: '', 
      showInFrontEnd: false, 
    })

  }

}
 