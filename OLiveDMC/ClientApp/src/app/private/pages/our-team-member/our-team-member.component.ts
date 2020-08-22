import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { Router } from '@angular/router';
import { TeamMemberService } from 'src/app/providers/TeamMemberService/team-member.service';

@Component({
  selector: 'app-our-team-member',
  templateUrl: './our-team-member.component.html',
  styleUrls: ['./our-team-member.component.css']
})
export class OurTeamMemberComponent implements OnInit {

 

  teamMemberForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  teamMembers:any =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_teamMember: boolean = false;
  teamMemberId: string;
  tooltipText:string ="this Team Member is show or hide to the user";
  tooltipVideoText:string ="only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  
  constructor( 
    private formBuilder : FormBuilder,
    private  teamMemberService: TeamMemberService, 
    private  router: Router, 
    private spinner: NgxSpinnerService,
    ) {

    this.teamMemberForm = this.formBuilder.group({
      name : ['', Validators.required],
      designation: ['', Validators.required],
      featuredImage: [''],
      showInFrontEnd: [false],
    })
    
  }

  ngOnInit(): void {
    this.GetAllTeamMember();
  }

 
  preview(file) {

    if(this.edit_teamMember == true){
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

  submitTeamMemberData(){
    debugger;
    if(this.teamMemberForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_teamMember == true ? formData.append('Id', this.teamMemberId) : formData.append('Id', '0'); 
      this.teamMemberId = '0';
     
      if( (this.edit_teamMember == false) || (this.edit_teamMember == true && this.editfileUploaded == true)){
        formData.append('FeaturedImage', this.file);
      }
      else{
        formData.append('FeaturedImage', null);
      }

      formData.append('Name', this.teamMemberForm.get('name').value);
      formData.append('Designation', this.teamMemberForm.get('designation').value);
      formData.append('ShowInFrontEnd', this.teamMemberForm.get('showInFrontEnd').value);

      this.teamMemberService.AddUpdateTeamMember(formData).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_teamMember == true){
          Swal.fire(
            'Updated!',
            'Your Team Member has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Team Member has been Added.',
            'success'
          )
         }
          
          this.edit_teamMember = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetTeamMemberForm();
          this.GetAllTeamMember();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllTeamMember(){

    this.teamMemberService.GetAllTeamMember().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.teamMembers = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editTeamMember(teamMember){
    this.teamMemberForm.get('name').setValue(teamMember.name);
    this.teamMemberForm.get('designation').setValue(teamMember.designation);
    this.teamMemberForm.get('showInFrontEnd').setValue(teamMember.showInFrontEnd);
   
    this.teamMemberId = ''+teamMember.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/TeamMemberInAboutUs/image/'+teamMember.featuredImage;
    this.edit_teamMember = true;
  }

  deleteTeamMember(id){

    this.spinner.show()
    this.teamMemberService.deleteTeamMember(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllTeamMember();  
        Swal.fire(
          'Deleted!',
          'Your Team Member has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(teamMemberId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Team Member!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteTeamMember(teamMemberId);
      }

    })
  }

  gotoDetailPage(teamMember){
    this.router.navigate(['/private/teamMember-detail', teamMember.id]);
  }

  resetTeamMemberForm(){
    this.teamMemberForm.setValue({
      name: '', 
      designation: '', 
      featuredImage: '', 
      showInFrontEnd: false, 
    })
  }

}

