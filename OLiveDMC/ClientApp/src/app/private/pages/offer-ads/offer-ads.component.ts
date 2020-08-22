import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { OfferAdsService } from 'src/app/providers/OfferAdsService/offer-ads.service';
import { ShareService } from 'src/app/providers/ShareService/share.service';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-offer-ads',
  templateUrl: './offer-ads.component.html',
  styleUrls: ['./offer-ads.component.css']
})
export class OfferAdsComponent implements OnInit {

  
  offerAdsForm: FormGroup;
  previewUrl:any = null;
  fileUploaded:boolean = false;
  file: any;
  offerAds:Array<any> =[];
  pages:Array<any> =[];
  apiendpoint:string = environment.apiendpoint;
  editfileUploaded: boolean = false;
  edit_offerAds: boolean = false;
  offerAdsId: string;
  tinymceConfig: any;
  tooltipText:string ="this Offer And Ads is show or hide to the user";

  tooltipOptions = {
    'placement': 'top',
    'show-delay': 500
  }

   value:any = ['Athens'];
   _disabledV:string = '0';
   disabled:boolean = false;
   items:Array<string> = ['Amsterdam', 'Antwerp', 'Athens', 'Barcelona',
    'Berlin', 'Birmingham', 'Bradford', 'Bremen', 'Brussels', 'Bucharest',
    'Budapest', 'Cologne', 'Copenhagen', 'Dortmund', 'Dresden', 'Dublin', 'Düsseldorf',
    'Essen', 'Frankfurt', 'Genoa', 'Glasgow', 'Gothenburg', 'Hamburg', 'Hannover',
    'Helsinki', 'Leeds', 'Leipzig', 'Lisbon', 'Łódź', 'London', 'Kraków', 'Madrid',
    'Málaga', 'Manchester', 'Marseille', 'Milan', 'Munich', 'Naples', 'Palermo',
    'Paris', 'Poznań', 'Prague', 'Riga', 'Rome', 'Rotterdam', 'Seville', 'Sheffield',
    'Sofia', 'Stockholm', 'Stuttgart', 'The Hague', 'Turin', 'Valencia', 'Vienna',
    'Vilnius', 'Warsaw', 'Wrocław', 'Zagreb', 'Zaragoza'];
    
    cities2 = [
      {id: 1, name: 'Vilnius'},
      {id: 2, name: 'Kaunas'},
      {id: 3, name: 'Pavilnys', disabled: true},
      {id: 4, name: 'Pabradė'},
      {id: 5, name: 'Klaipėda'}
  ];

  toppings = new FormControl();

  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
  // dropdownList = [];
  dropdownList = [
    { item_id: 1, item_text: 'Mumbai' },
    { item_id: 2, item_text: 'Bangaluru' },
    { item_id: 3, item_text: 'Pune' },
    { item_id: 4, item_text: 'Navsari' },
    { item_id: 5, item_text: 'New Delhi' }
  ];;
  selectedItems = [];
  // dropdownSettings:IDropdownSettings = {};
  
  dropdownSettings:IDropdownSettings = {
    singleSelection: false,
    idField: 'item_id',
    textField: 'item_text',
    selectAllText: 'Select All',
    unSelectAllText: 'UnSelect All',
    itemsShowLimit: 3,
    allowSearchFilter: true
  };;
  
  constructor( 
    private formBuilder : FormBuilder,
    private  offerAdsService: OfferAdsService, 
    private  shareService: ShareService, 
    private spinner: NgxSpinnerService,
    ) {

      // this.dropdownList = [
      //   { item_id: 1, item_text: 'Mumbai' },
      //   { item_id: 2, item_text: 'Bangaluru' },
      //   { item_id: 3, item_text: 'Pune' },
      //   { item_id: 4, item_text: 'Navsari' },
      //   { item_id: 5, item_text: 'New Delhi' }
      // ];
      this.selectedItems = [
        { item_id: 3, item_text: 'Pune' },
        { item_id: 4, item_text: 'Navsari' }
      ];
      // this.dropdownSettings = {
      //   singleSelection: false,
      //   idField: 'item_id',
      //   textField: 'item_text',
      //   selectAllText: 'Select All',
      //   unSelectAllText: 'UnSelect All',
      //   itemsShowLimit: 3,
      //   allowSearchFilter: true
      // };

    this.offerAdsForm = this.formBuilder.group({
      title: ['', Validators.required],
      // pageId: ['', Validators.required],
      pageId: [ [1], Validators.required],
      image: [''],
      showInFrontEnd: [''],
    })

    
  }
  expression(){
    debugger;
  }

  ngOnInit(): void {
    var self = this; 
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const  formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob()); 
      self.offerAdsService.fileUploadInOfferAds(formdata).subscribe(resp=>{
        let url = self.apiendpoint+"Uploads/OfferAds/image/"+resp.data; 
          success(url);
      })
    }

    // this.apiendpoint = environment.apiendpoint;
    this.GetAllOfferAds();
    this.GetAllPage();


    
  }

  GetAllPage(){
    debugger;
    this.shareService.GetAllPage().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.pages = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }
 
  preview(file) {
    if(this.edit_offerAds == true){
       this.editfileUploaded = true;
    }

    let files = file.files[0] 
    var mimeType = files.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(files); 
    reader.onload = (_OfferAds) => { 
      this.previewUrl = reader.result; 
    }

    this.file = files;  
    this.fileUploaded = true;
  }

  submitOfferAdsData(){
    debugger;
    if(this.offerAdsForm.valid){
      this.spinner.show();

      let formData = new FormData();
      this.edit_offerAds == true ? formData.append('Id', this.offerAdsId) : formData.append('Id', '0'); 
      this.offerAdsId = '0';
      if( (this.edit_offerAds == false) || (this.edit_offerAds == true && this.editfileUploaded == true)){
        formData.append('image', this.file);
      }
      else{
        formData.append('image', null);
      }
      formData.append('Title', this.offerAdsForm.get('title').value);
      // formData.append('PageId', this.offerAdsForm.get('pageId').value);
      formData.append('PageId', this.offerAdsForm.value.pageId.toString());
      formData.append('ShowInFrontEnd', this.offerAdsForm.get('showInFrontEnd').value);

      this.offerAdsService.AddUpdateOfferAds(formData).subscribe(resp=>{
        this.spinner.hide();
        if(resp.status == Status.Success){
         if(this.edit_offerAds == true){
          Swal.fire(
            'Updated!',
            'Your Offer And Ads has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Offer And Ads has been Added.',
            'success'
          )
         }
          
          this.edit_offerAds = false;
          this.editfileUploaded = false;
          this.fileUploaded = false;
          this.file = undefined;
          // this.offerAdsForm.reset();
          this.resetOfferAdsForm();
          this.GetAllOfferAds();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  GetAllOfferAds(){
    
    this.offerAdsService.GetAllOfferAds().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.offerAds = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editOfferAds(offerAds){
    debugger;
    this.offerAdsForm.get('title').setValue(offerAds.title);
    // this.offerAdsForm.get('pageId').setValue(offerAds.pageId);
    let newpageId = offerAds.pageId.split(',').map(item =>{
      return Number (item);
   });

    this.offerAdsForm.get('pageId').setValue(newpageId);
    this.offerAdsForm.get('showInFrontEnd').setValue(offerAds.showInFrontEnd);
   
    this.offerAdsId = ''+offerAds.id; 
    this.previewUrl =  this.apiendpoint+'Uploads/OfferAds/image/'+offerAds.image;
    this.edit_offerAds = true;
  }

  deleteOfferAds(id){

    this.spinner.show()
    this.offerAdsService.deleteOfferAds(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllOfferAds();  
        Swal.fire(
          'Deleted!',
          'Your Offer And Ads has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialog(offerAdsId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Offer And Ads!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteOfferAds(offerAdsId);
      }

    })
  }

  resetOfferAdsForm(){
    this.offerAdsForm.setValue({
      title: '', 
      pageId: '', 
      showInFrontEnd: '', 
      image: '', 
    })
  }

  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
 
  //  get disabledV():string {
  //   return this._disabledV;
  // }

  //  set disabledV(value:string) {
  //   this._disabledV = value;
  //   this.disabled = this._disabledV === '1';
  // }

  //  selected(value:any) {
  //   console.log('Selected value is: ', value);
  // }

  //  removed(value:any) {
  //   console.log('Removed value is: ', value);
  // }

  //  refreshValue(value:any) {
  //   this.value = value;
  // }

  //  itemsToString(value:Array<any> = []) {
  //   return value
  //     .map(item => {
  //     return item.text;
  //   }).join(',');
  // }

}
