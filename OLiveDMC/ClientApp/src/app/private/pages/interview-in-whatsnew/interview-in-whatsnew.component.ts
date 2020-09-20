import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { Router } from '@angular/router';
import { InterviewInWhatsnewService } from 'src/app/providers/InterviewInWhatsNew/interview-in-whatsnew.service';

@Component({
  selector: 'app-interview-in-whatsnew',
  templateUrl: './interview-in-whatsnew.component.html',
  styleUrls: ['./interview-in-whatsnew.component.css']
})
export class InterviewInWhatsnewComponent implements OnInit {

  interviewForm: FormGroup;
  previewUrl: any = null;
  fileUploaded: boolean = false;
  file: any;
  interviews: any = [];
  apiendpoint: string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_interview: boolean = false;
  interviewId: string;
  tinymceConfig: any;
  tooltipText: string = "this Interview is show or hide to the user";
  tooltipVideoText: string = "only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  tooltipImagetext: string = "this Image  is show or hide In User Panel ";
  tooltipVideotext: string = "this Video  is show or hide In User Panel ";
  videoUrl: string = "";
  videoName: string = "";

  characterCount: number = 0;


  constructor(
    private formBuilder: FormBuilder,
    private interviewService: InterviewInWhatsnewService,
    private router: Router,
    private spinner: NgxSpinnerService,
  ) {

    this.interviewForm = this.formBuilder.group({
      title: ['', Validators.required],
      shortDescription: ['', Validators.required],
      description: ['', Validators.required],
      showInFrontEnd: [false],
      imageShowInFront: [false],
      videoShowInFront: [false],
      featuredImage: [''],
      video: [''],

    })

  }

  ngOnInit(): void {
    debugger;
    var self = this;
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob());
      self.interviewService.fileUploadInInterviewsInWhatsNew(formdata).subscribe(resp => {
        let url = self.apiendpoint + "Uploads/InterviewsInWhatsNew/image/" + resp.data;
        success(url);
      })
    }

    this.GetAllInterview();
  }


  preview(file) {
    debugger;

    if (this.edit_interview == true) {
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

  submitInterviewData() {
    debugger;
    if (this.interviewForm.valid) {
      this.spinner.show();

      let formData = new FormData();
      this.edit_interview == true ? formData.append('Id', this.interviewId) : formData.append('Id', '0');
      this.interviewId = '0';
      if ((this.edit_interview == false) || (this.edit_interview == true && this.editfileUploaded == true)) {
        formData.append('FeaturedImage', this.file);
      }
      else {
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.interviewForm.get('title').value);
      formData.append('ShortDescription', this.interviewForm.get('shortDescription').value);
      formData.append('Description', this.interviewForm.get('description').value);
      formData.append('ShowInFrontEnd', this.interviewForm.get('showInFrontEnd').value);
      formData.append('ImageShowInFront', this.interviewForm.get('imageShowInFront').value);
      formData.append('VideoShowInFront', this.interviewForm.get('videoShowInFront').value);
      formData.append('Video', this.videoName);


      this.interviewService.AddUpdateInterviewsInWhatsNew(formData).subscribe(resp => {

        if (resp.status == Status.Success) {
          if (this.edit_interview == true) {
            Swal.fire(
              'Updated!',
              'Your Interview has been Updated.',
              'success'
            )
          }
          else {
            Swal.fire(
              'Added!',
              'Your Interview has been Added.',
              'success'
            )
          }

          this.edit_interview = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.interviewForm.reset();
          // this.interviewForm.get('description').setValue('');
          this.resetInterviewForm();
          this.videoName = "";
          this.videoUrl = "";
          this.GetAllInterview();
        }
        else {
          this.spinner.hide();
          Swal.fire('Oops...', resp.message, 'warning');
        }
      })
    }
  }

  GetAllInterview() {
    debugger;

    this.interviewService.GetAllInterviewsInWhatsNew().subscribe(resp => {
      if (resp.status == Status.Success) {
        this.interviews = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

  editInterview(Interview) {
    debugger;
    if (this.videoName != "") {
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.interviewForm.get('title').setValue(Interview.title);
    this.interviewForm.get('shortDescription').setValue(Interview.shortDescription);
    this.interviewForm.get('description').setValue(Interview.description);
    this.interviewForm.get('showInFrontEnd').setValue(Interview.showInFrontEnd);
    this.interviewForm.get('imageShowInFront').setValue(Interview.imageShowInFront);
    this.interviewForm.get('videoShowInFront').setValue(Interview.videoShowInFront);

    this.interviewId = '' + Interview.id;
    this.videoName = Interview.video;
    this.previewUrl = this.apiendpoint + 'Uploads/InterviewsInWhatsNew/image/' + Interview.featuredImage;
    this.edit_interview = true;
  }

  deleteInterview(id) {
    debugger;

    this.spinner.show()
    this.interviewService.deleteInterviewsInWhatsNew(id).subscribe(resp => {
      if (resp.status == Status.Success) {
        this.GetAllInterview();
        Swal.fire(
          'Deleted!',
          'Your Interview has been deleted.',
          'success'
        )
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
    })
  }

  openConfirmDialog(interviewId) {
    debugger;

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Interview!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteInterview(interviewId);
      }

    })
  }

  changeVideo(file) {
    debugger;
    let oldVideoName: string = this.videoName;
    let files = file.files[0];
    if (files.size <= 10485760 && files.type == "video/mp4") {
      console.log(`video size is : ${files.size / 1048576}MB`)
      const formdata = new FormData();
      formdata.append("fileInfo", files);
      this.spinner.show();
      this.interviewService.videoUploadInInterviewsInWhatsNew(formdata).subscribe(resp => {
        this.spinner.hide();
        if (resp.status == Status.Success) {
          this.videoUrl = this.apiendpoint + "Uploads/InterviewsInWhatsNew/Video/" + resp.data;
          this.videoName = resp.data;
          if (oldVideoName != "") {
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }

      })
    }
    else {
      this.interviewForm.get('video').setValue(null);
      files.size > 10485760 && Swal.fire('Upload Failed', "Video Size Exceed To 10MB", 'warning');
      files.type != "video/mp4" && Swal.fire('Upload Failed', "Only MP4 video is supported", 'warning');
    }

  }

  deleteVideoFromPhysicalLocation(oldVideoName: string) {
    debugger;
    this.interviewService.deleteVideoInInterviewsInWhatsNew(oldVideoName).subscribe(resp => {
      if (resp.status == Status.Success) {
        console.log("previous Video Delete Successfully ");
      }
    })
  }

  gotoDetailPage(interview) {
    debugger;
    if (this.videoName != "") {
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/interview-detail', interview.id]);
  }

  ngOnDestroy() {
    if (this.videoName != "" && this.edit_interview == false) {
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }


  resetInterviewForm() {
    this.interviewForm.setValue({
      title: '',
      shortDescription: '',
      description: '',
      showInFrontEnd: false,
      imageShowInFront: false,
      videoShowInFront: false,
      featuredImage: '',
      video: '',
    })

  }

  shortDescriptionCharacterCount(event): boolean {
    if (this.interviewForm.get('shortDescription').value.length >= 200 && event.keyCode != 8) {
      let shortDescription: string = this.interviewForm.get('shortDescription').value;
      this.interviewForm.get('shortDescription').setValue(shortDescription.substring(0, 200));
      this.characterCount = this.interviewForm.get('shortDescription').value.length;
      return false;
    }
    this.characterCount = this.interviewForm.get('shortDescription').value.length;
    return true;
  }

  interviewShowInFrontAction(event){
    debugger;
    if(this.interviewForm.get('featuredImage').value == '' && event == true ){
      Swal.fire('Interview Show ',"Feature Image is required To Interview Show In Front",'warning');
      this.interviewForm.get('showInFrontEnd').setValue(false);
    }
  }
  
  imageShowInFrontAction(event){
    debugger;
    if(this.interviewForm.get('featuredImage').value == '' && event == true ){
      Swal.fire('Interview Image Show ',"Feature Image is required To Interview Image Show In Front",'warning');
      this.interviewForm.get('imageShowInFront').setValue(false);
    }
  }
  
  videoShowInFrontAction(event){
    debugger;
    if( this.videoName == '' && event == true ){
      Swal.fire('Interview Video Show ',"Video is required To Interview Video  Show In Front",'warning');
      this.interviewForm.get('videoShowInFront').setValue(false);
    }
  }

}
