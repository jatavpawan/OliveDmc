import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { SkillService } from 'src/app/providers/SkillService/skill.service';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent implements OnInit {

  skillForm: FormGroup;
  skills:any =[];
  edit_skill: boolean = false;
  skillId: string;

  constructor( 
    private formBuilder : FormBuilder,
    private  skillService: SkillService, 
    private spinner: NgxSpinnerService,
    ) {

    this.skillForm = this.formBuilder.group({
      id: [0],
      skillName: [''],
    })
    
  }

  ngOnInit(): void {
    this.GetAllSkill();
  }


  submitSkillData(){
    if(this.skillForm.valid){
      this.spinner.show();


      this.skillService.AddUpdateSkills(this.skillForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_skill == true){
          Swal.fire(
            'Updated!',
            'Your Skill has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Skill has been Added.',
            'success'
          )
         }
          
          this.edit_skill = false;
          this.resetSkill();
          this.GetAllSkill();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  resetSkill(){
    this.skillForm.setValue({
      id: 0,
      skillName: ''
    })
  }

  GetAllSkill(){
    this.skillService.GetAllSkills().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.skills = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editSkill(skill){

    this.skillForm.get('id').setValue(skill.id);
    this.skillForm.get('skillName').setValue(skill.skillName);
    this.edit_skill = true;
  }

  deleteSkill(id){

    this.spinner.show()
    this.skillService.deleteSkills(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllSkill();  
        Swal.fire(
          'Deleted!',
          'Your Skill has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(skillId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Skill!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteSkill(skillId);
      }

    })
  }
}

