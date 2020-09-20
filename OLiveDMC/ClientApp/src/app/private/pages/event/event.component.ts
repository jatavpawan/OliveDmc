import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { AuthenticationService } from 'src/app/providers/authentication/authentication.service';
import { EventService } from 'src/app/providers/EventService/event.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

  eventForm: FormGroup;
  previewUrl: any = null;
  fileUploaded: boolean = false;
  file: any;
  events: any = [];
  apiendpoint: string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_event: boolean = false;
  eventId: string;
  tinymceConfig: any;
  tooltipText: string = "this Event is show or hide to the user";
  tooltipVideoText: string = "only MP4 Video is supported and Video maximum size can be 10MB";
  tooltipImagetext: string = "this Image  is show or hide In User Panel ";
  tooltipVideotext: string = "this Video  is show or hide In User Panel ";
  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }
  videoUrl: string = "";
  videoName: string = "";
  characterCount: number = 0;

  constructor(
    private formBuilder: FormBuilder,
    private eventService: EventService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private authService: AuthenticationService,
  ) {

    this.eventForm = this.formBuilder.group({
      title: ['', Validators.required],
      shortDescription: ['', Validators.required],
      description: ['', Validators.required],
      status: [false],
      imageShowInFront: [false],
      videoShowInFront: [false],
      featuredImage: [''],
      video: [''],

    })

  }

  ngOnInit(): void {
    var self = this;
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob());
      self.eventService.fileUploadInEvent(formdata).subscribe(resp => {
        let url = self.apiendpoint + "Uploads/Event/image/" + resp.data;
        success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllEvent();
  }


  preview(file) {
    if (this.edit_event == true) {
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

  submitEventData() {
    if (this.eventForm.valid) {
      this.spinner.show();

      let formData = new FormData();
      this.edit_event == true ? formData.append('Id', this.eventId) : formData.append('Id', '0');
      this.eventId = '0';
      if ((this.edit_event == false) || (this.edit_event == true && this.editfileUploaded == true)) {
        formData.append('FeaturedImage', this.file);
      }
      else {
        formData.append('FeaturedImage', null);
      }
      formData.append('Title', this.eventForm.get('title').value);
      formData.append('shortDescription', this.eventForm.get('shortDescription').value);
      formData.append('Description', this.eventForm.get('description').value);
      formData.append('Status', this.eventForm.get('status').value);
      formData.append('ImageShowInFront', this.eventForm.get('imageShowInFront').value);
      formData.append('VideoShowInFront', this.eventForm.get('videoShowInFront').value);
      formData.append('Video', this.videoName);

      this.eventService.AddUpdateEvent(formData).subscribe(resp => {

        if (resp.status == Status.Success) {
          if (this.edit_event == true) {
            Swal.fire(
              'Updated!',
              'Your Event has been Updated.',
              'success'
            )
          }
          else {
            Swal.fire(
              'Added!',
              'Your Event has been Added.',
              'success'
            )
          }

          this.edit_event = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          this.resetEventForm();
          // this.eventForm.reset();
          // this.eventForm.get('description').setValue('');
          this.videoName = "";
          this.videoUrl = "";
          this.GetAllEvent();
        }
        else {
          this.spinner.hide();
          Swal.fire('Oops...', resp.message, 'warning');
        }
      })
    }
  }

  GetAllEvent() {
    this.eventService.GetAllEvent().subscribe(resp => {
      if (resp.status == Status.Success) {
        this.events = resp.data;
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })
  }

  editEvent(event) {
    if (this.videoName != "") {
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.eventForm.get('title').setValue(event.title);
    this.eventForm.get('shortDescription').setValue(event.shortDescription);
    this.eventForm.get('description').setValue(event.description);
    this.eventForm.get('status').setValue(event.status);
    this.eventForm.get('imageShowInFront').setValue(event.imageShowInFront);
    this.eventForm.get('videoShowInFront').setValue(event.videoShowInFront);

    this.eventId = '' + event.id;
    this.videoName = event.video;
    this.previewUrl = this.apiendpoint + 'Uploads/Event/image/' + event.featuredImage;
    this.edit_event = true;
  }

  deleteEvent(id) {

    this.spinner.show()
    this.eventService.deleteEvent(id).subscribe(resp => {
      if (resp.status == Status.Success) {
        this.GetAllEvent();
        Swal.fire(
          'Deleted!',
          'Your Event has been deleted.',
          'success'
        )
      }
      else {
        Swal.fire('Oops...', resp.message, 'error');
      }
    })
  }

  openConfirmDialog(eventId) {

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Event!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteEvent(eventId);
      }

    })
  }

  changeVideo(file) {
    debugger;
    let oldVideoName: string = this.videoName;
    let files = file.files[0]

    if (files.size <= 10485760 && files.type == "video/mp4") {
      console.log(`video size is : ${files.size / 1048576}MB`)
      const formdata = new FormData();
      formdata.append("fileInfo", files);
      this.spinner.show();
      this.eventService.videoUploadInEvent(formdata).subscribe(resp => {
        this.spinner.hide();
        if (resp.status == Status.Success) {
          this.videoUrl = this.apiendpoint + "Uploads/Event/Video/" + resp.data;
          this.videoName = resp.data;

          if (oldVideoName != "") {
            this.deleteVideoFromPhysicalLocation(oldVideoName)
          }
        }

      })
    }

    else {
      this.eventForm.get('video').setValue(null);
      files.size > 10485760 && Swal.fire('Upload Failed', "Video Size Exceed To 10MB", 'warning');
      files.type != "video/mp4" && Swal.fire('Upload Failed', "Only MP4 video is supported", 'warning');
    }

  }
  //--------------paste---------------

  deleteVideoFromPhysicalLocation(oldVideoName: string) {
    debugger;
    this.eventService.deleteVideoInEvent(oldVideoName).subscribe(resp => {
      if (resp.status == Status.Success) {
        console.log("previous Video Delete Successfully ");
      }
    })
  }

  gotoDetailPage(event) {
    if (this.videoName != "") {
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
    this.router.navigate(['/private/event-detail', event.id]);
  }

  ngOnDestroy() {
    if (this.videoName != "" && this.edit_event == false) {
      this.deleteVideoFromPhysicalLocation(this.videoName);
    }
  }

  resetEventForm() {
    this.eventForm.setValue({
      title: '',
      shortDescription: '',
      description: '',
      status: false,
      imageShowInFront: false,
      videoShowInFront: false,
      featuredImage: '',
      video: '',
    })
  }

  shortDescriptionCharacterCount(event): boolean {
    if (this.eventForm.get('shortDescription').value.length >= 200 && event.keyCode != 8) {
      let shortDescription: string = this.eventForm.get('shortDescription').value;
      this.eventForm.get('shortDescription').setValue(shortDescription.substring(0, 200));
      this.characterCount = this.eventForm.get('shortDescription').value.length;
      return false;
    }
    this.characterCount = this.eventForm.get('shortDescription').value.length;
    return true;
  }


  eventShowInFrontAction(event){
    debugger;
    if(this.eventForm.get('featuredImage').value == '' && event == true ){
      Swal.fire('Event Show ',"Feature Image is required To Event Show In Front",'warning');
      this.eventForm.get('status').setValue(false);
    }
  }
  
  imageShowInFrontAction(event){
    debugger;
    if(this.eventForm.get('featuredImage').value == '' && event == true ){
      Swal.fire('Event Image Show ',"Feature Image is required To Event Image Show In Front",'warning');
      this.eventForm.get('imageShowInFront').setValue(false);
    }
  }
  
  videoShowInFrontAction(event){
    debugger;
    if( this.videoName == '' && event == true ){
      Swal.fire('Event Video Show ',"Video is required To Event Video  Show In Front",'warning');
      this.eventForm.get('videoShowInFront').setValue(false);
    }
  }

}
