import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Status } from 'src/app/model/ResponseModel';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2'
import { LocationService } from 'src/app/providers/LocationService/location.service';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {

  
  countryForm: FormGroup;
  countries:any =[];
  edit_country: boolean = false;
  countryId: string;
  
  stateForm: FormGroup;
  states:any =[];
  edit_state: boolean = false;
  stateId: string;
  
  cityForm: FormGroup;
  cities:any =[];
  edit_city: boolean = false;
  cityId: string;
  formWizardName:string = 'Country'

  continents = [
    {
      continentCode : "AF",
      continentName : "Africa"
    },
    {
      continentCode : "AN",
      continentName : "Antarctica"
    },
    {
      continentCode : "AS",
      continentName : "Asia"
    },
    {
      continentCode : "EU",
      continentName : "Europe"
    },
    {
      continentCode : "NA",
      continentName : "North America"
    },
    {
      continentCode : "OC",
      continentName : "Oceania"
    },
    {
      continentCode : "SA",
      continentName : "South America"
    },
  ]
  statesLoad: any = [];
  addStateFlag: boolean= false;



  constructor( 
    private formBuilder : FormBuilder,
    private  locationService: LocationService, 
    private spinner: NgxSpinnerService,
    ) {

    this.countryForm = this.formBuilder.group({
      id: [0],
      countryName: [''],
      continentCode: [''],
      continentName: [''],
    })
    
    this.stateForm = this.formBuilder.group({
      id: [0],
      stateName: [''],
      countryId: [0],
    })
    
    this.cityForm = this.formBuilder.group({
      id: [0],
      cityName: [''],
      stateId: [0],
      countryId: [0],
    })
    
  }

  ngOnInit(): void {
    this.GetAllCountry();
  }


  submitCountryData(){
    debugger;
    if(this.countryForm.valid){
      this.spinner.show();

      let continentCode =  this.countryForm.get('continentCode').value;
      let index =   this.continents.findIndex(x => x.continentCode  == continentCode)
      let continentName =  this.continents[index].continentName;
      this.countryForm.get('continentName').setValue(continentName);

      this.locationService.AddUpdateCountry(this.countryForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_country == true){
          Swal.fire(
            'Updated!',
            'Your Country has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your Country has been Added.',
            'success'
          )
         }
          
          this.edit_country = false;
          this.resetCountry();
          this.GetAllCountry();
        }
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        } 
      })    
    }
  }

  resetCountry(){
    this.countryForm.setValue({
      id: 0,
      countryName: '',
      continentCode: '',
      continentName: '',
    })
  }

  GetAllCountry(){
    debugger;
    this.locationService.GetAllCountry().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.countries = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editCountry(country){
    debugger;
    this.countryForm.get('id').setValue(country.id);
    this.countryForm.get('countryName').setValue(country.countryName);
    this.countryForm.get('continentCode').setValue(country.continentCode);
    this.countryForm.get('continentName').setValue(country.continentName);
    this.edit_country = true;
  }

  deleteCountry(id){

    debugger;
    this.spinner.show()
    this.locationService.deleteCountry(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllCountry();  
        Swal.fire(
          'Deleted!',
          'Your Country has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialogCountry(countryId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Country!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteCountry(countryId);
      }

    })
  }

  // -----------------------------------------------State Methods--------------------------------------------------
  
  
  submitStateData(){
    if(this.stateForm.valid){
      this.spinner.show();


      this.locationService.AddUpdateState(this.stateForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_state == true){
          Swal.fire(
            'Updated!',
            'Your State has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your State has been Added.',
            'success'
          )
         }
          
          this.edit_state = false;
          this.resetState();
          this.GetAllState();
        }
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        }  
      })    
    }
  }

  resetState(){
    this.stateForm.setValue({
      id: 0,
      stateName: '',
      countryId: 0
    })
    
    
  }

  GetAllState(){
    debugger;
    this.locationService.GetAllState().subscribe(resp=>{
      debugger;
      if(resp.status == Status.Success){
          this.states = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editState(state){
    debugger;
    this.stateForm.get('id').setValue(state.id);
    this.stateForm.get('stateName').setValue(state.stateName);
    this.stateForm.get('countryId').setValue(state.countryId);
    this.edit_state = true;
  }

  deleteState(id){

    this.spinner.show()
    this.locationService.deleteState(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllState();  
        Swal.fire(
          'Deleted!',
          'Your State has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialogState(stateId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this State!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteState(stateId);
      }

    })
  }


  // -----------------------------------------------City Methods--------------------------------------------------


  submitCityData(){
    if(this.cityForm.valid){
      this.spinner.show();


      this.locationService.AddUpdateCity(this.cityForm.value).subscribe(resp=>{
     
        if(resp.status == Status.Success){
         if(this.edit_city == true){
          Swal.fire(
            'Updated!',
            'Your City has been Updated.',
            'success'
          )
         }
         else{
          Swal.fire(
            'Added!',
            'Your City has been Added.',
            'success'
          )
         }
         this.statesLoad = [];
          this.edit_city = false;
          this.resetCity();
          this.GetAllCity();
        } 
        else{
          this.spinner.hide();
          Swal.fire('Oops...' ,resp.message,'warning');
        }
      })    
    }
  }

  resetCity(){
    this.cityForm.setValue({
      id: 0,
      cityName: '',
      stateId: 0,
      countryId: 0,
    })
  }

  GetAllCity(){
    debugger;
    this.locationService.GetAllCity().subscribe(resp=>{
      if(resp.status == Status.Success){
          this.cities = resp.data;
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
      this.spinner.hide();
    })    
  }

  editCity(city){
    debugger;
    this.statesLoad= [];
    this.spinner.show();
    this.locationService.GetStateByCountryId(city.countryId).subscribe(resp => {
      debugger;
      this.spinner.hide();
      if(resp.status == Status.Success){
        this.statesLoad = resp.data;
        this.cityForm.get('id').setValue(city.id);
        this.cityForm.get('stateId').setValue(city.stateId);
        this.cityForm.get('cityName').setValue(city.cityName);
        this.cityForm.get('countryId').setValue(city.countryId);
      }
    })
    
    this.edit_city = true;
  }

  deleteCity(id){

    this.spinner.show()
    this.locationService.deleteCity(id).subscribe(resp=>{
      if(resp.status == Status.Success){
        this.GetAllCity();  
        Swal.fire(
          'Deleted!',
          'Your City has been deleted.',
          'success'
        )
      } 
      else{
        Swal.fire('Oops...', resp.message, 'error');
      }
    })    
  }

  openConfirmDialogCity(cityId){

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this City!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.deleteCity(cityId);
      }

    })
  }


  changeInFormWizard(WizardName:string){
   this.formWizardName = WizardName;

   WizardName == 'Country'  && this.GetAllCountry();
   WizardName == 'State'  && this.GetAllState();
   if(WizardName == 'City'){
    this.GetAllCity();
    this.statesLoad = [];
   }

  }

  changeCountryInCity(){
    debugger;
    this.spinner.show();
    let countryId =  this.cityForm.get('countryId').value;
    this.locationService.GetStateByCountryId(countryId).subscribe(resp => {
      debugger;
      this.spinner.hide();
         if(resp.status == Status.Success){
           this.statesLoad = resp.data;
           resp.data == [] ? this.addStateFlag = true : this.addStateFlag = false;
         }
    })
  }
}






