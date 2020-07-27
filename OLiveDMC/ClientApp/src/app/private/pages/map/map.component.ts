import { Component, OnInit, NgZone, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4maps from "@amcharts/amcharts4/maps";
import am4geodata_worldLow from "@amcharts/amcharts4-geodata/worldLow";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Status } from 'src/app/model/ResponseModel';
import Swal from 'sweetalert2'
import { DestinationService } from 'src/app/providers/destinationService/destination.service';
import { commonTinymceConfig } from '../../shared/tinymce-settings';
import { environment } from 'src/environments/environment';
import { allCountryData } from '../../shared/AllCountryData';


am4core.useTheme(am4themes_animated);

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements OnInit {
 
  
  chart: am4maps.MapChart;
  countryColor: any;
  map_title: string = "World";
  mapForm: FormGroup;
  editshowinfo: boolean = false;
  videoUrl: string = "";
  videoName: string = "";


  countries: any = allCountryData;

  continents = {
    "AF": 0,
    "AN": 1,
    "AS": 2,
    "EU": 3,
    "NA": 4,
    "OC": 5,
    "SA": 6
  }

  showDestinationInfo: boolean = false;
  destinationCountryId: any = '';
  editCountryInfo: boolean = false;
  datafound: boolean = false;
  tinymceConfig: any;
  countryObj: any = {
    aboutCountry: "",
    topAttraction: "",
    topDestination: "",
    visadetail: "",
    howToReach: "",
    miscellaneous: "",
  };
  apiendpoint: string = environment.apiendpoint;
  dataNotfound: boolean = false;

  constructor(private zone: NgZone,
    private formBuilder: FormBuilder,
    private destinationService: DestinationService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private ref: ChangeDetectorRef
  ) {

    this.mapForm = this.formBuilder.group({
      id: [0],
      CountryCode: [''],
      aboutCountry: [''],
      topAttraction: [''],
      topDestination: [''],
      visadetail: [''],
      howToReach: [''],
      miscellaneous: [''],
      video: [''],
    })

  }

  ngOnInit() {
    var self = this;
    this.tinymceConfig = commonTinymceConfig;
    this.tinymceConfig.images_upload_handler = function (blobInfo, success, failure) {
      const formdata = new FormData();
      formdata.append("fileInfo", blobInfo.blob());
      self.destinationService.fileUploadInDestination(formdata).subscribe(resp => {
        let url = self.apiendpoint + "Uploads/Map/image/" + resp.data;
        success(url);
      })
    }
  }

  ngAfterViewInit() {
    this.zone.runOutsideAngular(() => {
      /* Create map instance */
      let chart = am4core.create("chartdiv", am4maps.MapChart);
      chart.logo.height = -15;
      chart.projection = new am4maps.projections.Miller();

      // Create map polygon series for world map
      let worldSeries = chart.series.push(new am4maps.MapPolygonSeries());
      worldSeries.useGeodata = true;
      worldSeries.geodata = am4geodata_worldLow;
      worldSeries.exclude = ["AQ"];

      let worldPolygon = worldSeries.mapPolygons.template;
      //  worldPolygon.tooltipText = `{name} 
      //   \n package : {valuess}{name}`;
      worldPolygon.tooltipText = `{name}`;
      worldPolygon.applyOnClones = true;

      worldPolygon.nonScalingStroke = true;
      worldPolygon.strokeOpacity = 0.5;
      worldPolygon.fill = am4core.color("#eee");
      worldPolygon.propertyFields.fill = "color";
      worldPolygon.propertyFields.id = "id";

      // Set up click events 
      // Worlds click events 
      var self = this;
      let lastSelected;
      worldPolygon.events.on("hit", function (ev) {
        debugger;
        // if (lastSelected === ev.target) {
        if (lastSelected !== undefined) {

          // This line serves multiple purposes:
          // 1. Clicking a country twice actually de-activates, the line below
          //    de-activates it in advance, so the toggle then re-activates, making it
          //    appear as if it was never de-activated to begin with.
          // 2. Previously activated countries should be de-activated.
          // lastSelected.isActive = false;
          lastSelected = undefined;

          // ev.target.series.chart.zoomToMapObject(ev.target);
          let temp: any = ev.target.dataItem.dataContext;
          
          if (temp.map != undefined) {
            self.showDestinationInfo = true;
            self.destinationCountryId = temp.id;
            self.map_title = temp.name;
            self.GetCountryInfoByCountryCode(self.destinationCountryId);
            self.ref.detectChanges();
          }

          var map = temp.map;
          if (map) {
            ev.target.isHover = false;
            countrySeries.geodataSource.url = "https://www.amcharts.com/lib/4/geodata/json/" + map + ".json";
            countrySeries.geodataSource.load();
            button.show();
          }

          if (temp.id == "IN") {

            // countrySeries.include= ['IN-MP', 'IN-RJ', 'IN-PB']
            let country_data = [
              { "value": Math.round(Math.random() * 10000) },
              { "name": "Andaman and Nicobar Islands", "id": "IN-AN", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Port Blair", "value": Math.round(Math.random() * 10000) },
              { "name": "Andhra Pradesh", "id": "IN-AP", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Amaravati", "value": Math.round(Math.random() * 10000) },
              { "name": "Arunachal Pradesh", "id": "IN-AR", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "	Itanagar", "value": Math.round(Math.random() * 10000) },
              { "name": "Assam", "id": "IN-AS", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Dispur", "value": Math.round(Math.random() * 10000) },
              { "name": "Bihar", "id": "IN-BR", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "	Patna", "value": Math.round(Math.random() * 10000) },
              { "name": "Chandigarh", "id": "IN-CH", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Chandigarh", "value": Math.round(Math.random() * 10000) },
              { "name": "Chhattisgarh", "id": "IN-CT", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Naya Raipur", "value": Math.round(Math.random() * 10000) },
              { "name": "Daman and Diu", "id": "IN-DD", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Daman", "value": Math.round(Math.random() * 10000) },
              { "name": "Delhi", "id": "IN-DL", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "New Delhi", "value": Math.round(Math.random() * 10000) },
              { "name": "Dadra and Nagar Haveli", "id": "IN-DN", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Daman", "value": Math.round(Math.random() * 10000) },
              { "name": "Goa", "id": "IN-GA", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Panaji", "value": Math.round(Math.random() * 10000) },
              { "name": "Gujarat", "id": "IN-GJ", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Gandhinagar", "value": Math.round(Math.random() * 10000) },
              { "name": "Himachal Pradesh", "id": "IN-HP", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Shimla", "value": Math.round(Math.random() * 10000) },
              { "name": "Haryana", "id": "IN-HR", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Chandigarh", "value": Math.round(Math.random() * 10000) },
              { "name": "Jharkhand", "id": "IN-JH", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "	Ranchi", "value": Math.round(Math.random() * 10000) },
              { "name": "Jammu and Kashmir", "id": "IN-JK", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Srinagar", "value": Math.round(Math.random() * 10000) },
              { "name": "Karnataka", "id": "IN-KA", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Bangalore", "value": Math.round(Math.random() * 10000) },
              { "name": "Kerala", "id": "IN-KL", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Thiruvananthapuram", "value": Math.round(Math.random() * 10000) },
              { "name": "Lakshadweep", "id": "IN-LD", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Kavaratti", "value": Math.round(Math.random() * 10000) },
              { "name": "Maharashtra", "id": "IN-MH", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Mumbai", "value": Math.round(Math.random() * 10000) },
              { "name": "Meghalaya", "id": "IN-ML", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Shillong", "value": Math.round(Math.random() * 10000) },
              { "name": "Manipur", "id": "IN-MN", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Imphal", "value": Math.round(Math.random() * 10000) },
              { "name": "Madhya Pradesh", "id": "IN-MP", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Bhopal", "value": Math.round(Math.random() * 10000) },
              { "name": "Mizoram", "id": "IN-MZ", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Aizawl", "value": Math.round(Math.random() * 10000) },
              { "name": "Nagaland", "id": "IN-NL", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Kohima", "value": Math.round(Math.random() * 10000) },
              { "name": "Odisha", "id": "IN-OR", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Bhubaneswar", "value": Math.round(Math.random() * 10000) },
              { "name": "Punjab", "id": "IN-PB", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Chandigarh", "value": Math.round(Math.random() * 10000) },
              { "name": "Puducherry", "id": "IN-PY", "TYPE": "Union Territory", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Puducherry", "value": Math.round(Math.random() * 10000) },
              { "name": "Rajasthan", "id": "IN-RJ", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Jaipur", "value": Math.round(Math.random() * 10000) },
              { "name": "Sikkim", "id": "IN-SK", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Gangtok", "value": Math.round(Math.random() * 10000) },
              { "name": "Telangana", "id": "IN-TG", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Hyderabad", "value": Math.round(Math.random() * 10000) },
              { "name": "Tamil Nadu", "id": "IN-TN", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Chennai", "value": Math.round(Math.random() * 10000) },
              { "name": "Tripura", "id": "IN-TR", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Agartala", "value": Math.round(Math.random() * 10000) },
              { "name": "Uttar Pradesh", "id": "IN-UP", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Lucknow", "value": Math.round(Math.random() * 10000) },
              { "name": "Uttarakhand", "id": "IN-UT", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Dehradun", "value": Math.round(Math.random() * 10000) },
              { "name": "West Bengal", "id": "IN-WB", "TYPE": "State", "CNTRY": "India", "packages": "available 10 packages", "capital_city": "Kolkata", "value": Math.round(Math.random() * 10000) },
            ]

            countrySeries.data = country_data;
          }
          else {
            countrySeries.data = [];
            //  countrySeries = chart.series.push(new am4maps.MapPolygonSeries());
            countrySeries.useGeodata = true;
            countrySeries.geodataSource.url = "https://www.amcharts.com/lib/4/geodata/json/" + map + ".json";
            countrySeries.geodataSource.load();
          }

          let continent_code_color: any = {
            "EU": "#8067dc",
            "AS": "#6771dc",
            "OC": "#c767dc",
            "AF": "#67b7dc",
            "SA": "#dc67ce",
            "NA": "#a367dc"
          }

          let continent_code: string = self.countries[temp.id].continent_code;
          self.countryColor = continent_code_color[continent_code];
          countryPolygon.fill = am4core.color(self.countryColor);



        }

        ev.target.series.chart.zoomToMapObject(ev.target);
        // if (lastSelected !== ev.target) {
        if (lastSelected === undefined) {
          lastSelected = ev.target;
        }

      });


      var hs = worldPolygon.states.create("hover");
      hs.properties.fill = am4core.color("#BC8F8F");

      // Create country specific series (but hide it for now)
      var countrySeries = chart.series.push(new am4maps.MapPolygonSeries());
      countrySeries.useGeodata = true;
      countrySeries.hide();
      countrySeries.geodataSource.events.on("done", function (ev) {
        worldSeries.hide();
        countrySeries.show();
      });

      var countryPolygon = countrySeries.mapPolygons.template;
      countryPolygon.tooltipText = "{name} \n packages: {packages} \n capital city : {capital_city} \n value : {value}";
      countryPolygon.nonScalingStroke = true;
      countryPolygon.strokeOpacity = 0.5;
      countryPolygon.fill = am4core.color("#6771dc");

      var hs = countryPolygon.states.create("hover");
      hs.properties.fill = am4core.color("#BC8F8F");   // comment

      //Set min/max fill color for each area
      countrySeries.heatRules.push({
        property: "fill",
        target: countrySeries.mapPolygons.template,
        min: chart.colors.getIndex(1).brighten(1),
        max: chart.colors.getIndex(1).brighten(-0.3)
      });



      // Set up click events 
      // Country click events 
      countryPolygon.events.on("hit", function (ev) {
        console.log("hit state data of country", ev.target.dataItem.dataContext);
      });

      // Set up data for countries
      var data = [];
      for (var id in this.countries) {
        if (this.countries.hasOwnProperty(id)) {
          var country = this.countries[id];
          if (country.maps.length) {
            data.push({
              id: id,
              color: chart.colors.getIndex(this.continents[country.continent_code]),
              map: country.maps[0],
              valuess: "30 packages in ",

            });
          }
          else {
            data.push({
              id: id,
              color: chart.colors.getIndex(this.continents[country.continent_code]),
              valuess: "30 packages in ",
            });
          }
        }
      }
      worldSeries.data = data;
      let button = chart.chartContainer.createChild(am4core.Button);
      button.padding(5, 5, 5, 5);
      button.align = "right";
      button.marginRight = 15;
      button.events.on("hit", function () {
        self.map_title = "World";
        self.showDestinationInfo = false;
        self.destinationCountryId = '';
        self.editCountryInfo = false;
        self.videoName = '';
        self.mapForm.get('id').setValue(0);
        self.ref.detectChanges();
        lastSelected = undefined;

        self.ref.detectChanges();
        worldSeries.show();
        countrySeries.hide();
        chart.goHome();
        button.hide();
      });
      button.icon = new am4core.Sprite();
      button.icon.path = "M16,8 L14,8 L14,16 L10,16 L10,10 L6,10 L6,16 L2,16 L2,8 L0,8 L8,0 L16,8 Z M16,8";
      // Add zoom control
      chart.zoomControl = new am4maps.ZoomControl();

      this.chart = chart;

    });
  }

  ngOnDestroy() {

    this.zone.runOutsideAngular(() => {
      if (this.chart) {
        this.chart.dispose();
        am4core.disposeAllCharts();
        this.chart = null;
        this.ref.detectChanges();

      }
    });
  }

  submitDestinationInCountry() {
    debugger;
    if (this.mapForm.valid) {
      this.spinner.show();
      if (this.editCountryInfo == false)
        this.mapForm.get('CountryCode').setValue(this.destinationCountryId);
      this.mapForm.get('video').setValue(this.videoName);


      this.destinationService.AddUpdateDestinationInCountry(this.mapForm.value).subscribe(resp => {
        this.spinner.hide();

        if (resp.status == Status.Success) {
          if (this.editCountryInfo == true) {
            Swal.fire(
              'Updated!',
              'Your Country Data  has been Updated.',
              'success'
            )
          }
          else {
            Swal.fire(
              'Added!',
              'Your Country Data  has been Added.',
              'success'
            )
          }
          this.GetCountryInfoByCountryCode(this.mapForm.get('CountryCode').value);
          this.editCountryInfo = false;
          this.editshowinfo = false;
          // this.mapForm.reset();
        }
        else {
          Swal.fire('Oops...', resp.message, 'error');
        }
      })
    }
  }

  GetCountryInfoByCountryCode(destinationCountryCode: string) {
    this.spinner.show();
    this.destinationService.GetCountryInfoByCountryCode(destinationCountryCode).subscribe(resp => {
      this.spinner.hide();

      if (resp.status == Status.Success) {
        console.log(resp.data);
        this.countryObj = resp.data;
        this.mapForm.get('CountryCode').setValue(this.countryObj.countryCode);
        this.mapForm.get('aboutCountry').setValue(this.countryObj.aboutCountry);
        this.mapForm.get('topAttraction').setValue(this.countryObj.topAttraction);
        this.mapForm.get('topDestination').setValue(this.countryObj.topDestination);
        this.mapForm.get('visadetail').setValue(this.countryObj.visadetail);
        this.mapForm.get('howToReach').setValue(this.countryObj.howToReach);
        this.mapForm.get('miscellaneous').setValue(this.countryObj.miscellaneous);
        this.mapForm.get('id').setValue(this.countryObj.id);
        this.videoName = this.countryObj.video;
        this.editCountryInfo = true;
        this.dataNotfound = false;
        this.ref.detectChanges();
      }
      else {
        this.ResetMapForm();
        this.dataNotfound = true;
        this.ref.detectChanges();

      }
    })
  }


  deleteCountryInfoByCountryCode() {
    let id = this.mapForm.get('id').value;

    Swal.fire({
      title: 'Are you sure?',
      text: "You Want to delete this Record!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.spinner.show();

        this.destinationService.deleteCountryInfoById(id).subscribe(resp => {
          this.spinner.hide();

          if (resp.status == Status.Success) {
            Swal.fire(
              'Deleted!',
              'Your Country Data  has been deleted.',
              'success'
            )

            this.ResetMapForm();
            this.editCountryInfo = false;
            this.videoName = "";
            this.ref.detectChanges();
          }
          else {
            Swal.fire('Oops...', resp.message, 'error');
          }
        })
      }

    })
  }

  ResetMapForm() {
    this.mapForm.reset({
      id: 0,
      CountryCode: '',
      aboutCountry: '',
      topAttraction: '',
      topDestination: '',
      visadetail: '',
      howToReach: '',
      miscellaneous: '',
    });
  }

  changeDetectionCall() {
    this.ref.detectChanges();
  }

  changeShow() {
    this.editshowinfo = !this.editshowinfo

    this.ref.detectChanges();
  }


  changeVideo(file) {
    debugger;
    let files = file.files[0];
    if (files.size <= 10485760 && files.type == "video/mp4") {
      console.log(`video size is : ${files.size / 1048576}MB`)
      const formdata = new FormData();
      formdata.append("fileInfo", files);
      this.spinner.show();
      this.ref.detectChanges();
      this.destinationService.videoUploadInDestination(formdata).subscribe(resp => {
        this.spinner.hide();
        this.ref.detectChanges();

        if (resp.status == Status.Success) {
          this.videoUrl = this.apiendpoint + "Uploads/TourTheme/Video/" + resp.data;
          this.videoName = resp.data;
          this.ref.detectChanges();

        }
      })
      this.ref.detectChanges();
    }
    else {
      this.mapForm.get('video').setValue(null);
      files.size > 10485760 && Swal.fire('Upload Failed', "Video Size Exceed To 10MB", 'warning');
      files.type != "video/mp4" && Swal.fire('Upload Failed', "Only MP4 video is supported", 'warning');

      this.ref.detectChanges();
    }
  }

}
