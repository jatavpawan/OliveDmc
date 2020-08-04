import { Component, OnInit, NgZone, ChangeDetectorRef } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4maps from "@amcharts/amcharts4/maps";
import am4geodata_worldLow from "@amcharts/amcharts4-geodata/worldLow";
import am4geodata_worldHigh from "@amcharts/amcharts4-geodata/worldHigh";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import { environment } from 'src/environments/environment';
import { allCountryData } from '../../shared/AllCountryData';
import am4geodata_continentsLow from "@amcharts/amcharts4-geodata/continentsLow";
import { debug } from 'util';


am4core.useTheme(am4themes_animated);

@Component({
  selector: 'app-travel-guru-expert-travelers',
  templateUrl: './travel-guru-expert-travelers.component.html',
  styleUrls: ['./travel-guru-expert-travelers.component.css']
})
export class TravelGuruExpertTravelersComponent implements OnInit {

  chart: am4maps.MapChart;
  countryColor: any;
  map_title: string = "World";

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

  asiaCountries:any;


  constructor(
    private zone: NgZone,
    private ref: ChangeDetectorRef
  ) {
    // debugger;
    // let countrylist:Array<any> = [];
    // for (var id in this.countries) {
    //   // debugger;
    //   if (this.countries.hasOwnProperty(id)) {
    //     var country = this.countries[id];
        
    //     if (country.continent == "Asia")
    //       countrylist = [...countrylist, id];
    //   }
    // }

    // let worldcountries = am4geodata_worldLow;
    // this.asiaCountries =  worldcountries.features.filter(item =>  countrylist.includes(item.id) );


  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.zone.runOutsideAngular(() => {
      /* Create map instance */
      let chart = am4core.create("chartdiv", am4maps.MapChart);
      chart.logo.height = -15;
      chart.projection = new am4maps.projections.Miller();

      var self = this;

      let restoreContinents = function () {
        hideCountries();
        chart.goHome();
      };

      // Zoom control
      chart.zoomControl = new am4maps.ZoomControl();
      chart.zoomControl.slider.height = 100;

      let homeButton = new am4core.Button();
      homeButton.events.on("hit", function () {
        // restoreContinents();
        continentsSeries.show();
        countriesSeries.hide();
        stateSeries.hide();
        chart.goHome();

        // continentsSeries.include = ["africa", "asia", "oceania", "europe", "northAmerica", "southAmerica",];
        initializeContinentSeriesData();
      });

      homeButton.icon = new am4core.Sprite();
      // homeButton.padding(7, 5, 7, 5);
      homeButton.width = 30;
      homeButton.icon.path = "M16,8 L14,8 L14,16 L10,16 L10,10 L6,10 L6,16 L2,16 L2,8 L0,8 L8,0 L16,8 Z M16,8";
      homeButton.marginBottom = 10;
      homeButton.padding(5, 5, 5, 5);
      homeButton.align = "right";
      homeButton.marginRight = 15;
      homeButton.parent = chart.zoomControl;
      homeButton.insertBefore(chart.zoomControl.plusButton);

      // Shared 
      // let hoverColorHex = "#ff0000"; //continent hover color
      let hoverColorHex = "#de3e4a"; //continent hover color
      let hoverColor = am4core.color(hoverColorHex);
      let hideCountries = function () {
        countryTemplate.hide();
      };

      let initializeContinentSeriesData = function () {
        // continentsSeries.include = ["africa","asia", "oceania","europe","northAmerica","southAmerica",];
        continentsSeries.data = [
          {
            "id": "africa",
            "color": chart.colors.getIndex(0)
          },
          {
            "id": "asia",
            "color": chart.colors.getIndex(1),
            "zoomLevel": 2,
            "zoomGeoPoint": {
              "latitude": 46,
              "longitude": 89
            }
          }
          , {
            "id": "oceania",
            "color": chart.colors.getIndex(2)
          }, {
            "id": "europe",
            "color": chart.colors.getIndex(3)
          }, {
            "id": "northAmerica",
            "color": chart.colors.getIndex(4)
          }, {
            "id": "southAmerica",
            "color": chart.colors.getIndex(5)
          }
        ];
      };
      debugger;

      // Continents 
      let continentsSeries = chart.series.push(new am4maps.MapPolygonSeries());
      continentsSeries.geodata = am4geodata_continentsLow;
      continentsSeries.useGeodata = true;
      continentsSeries.exclude = ["antarctica"];
      // continentsSeries.exclude = ["antarctica", "africa", "oceania","europe","northAmerica","southAmerica",];
      continentsSeries.events.on("inited", function () {
        initializeContinentSeriesData();
      });
      // var initEventHandler = function (event) { event.chart.zoomOut = function () { debugger; }; };

      let continentTemplate = continentsSeries.mapPolygons.template;
      continentTemplate.tooltipText = "{name}";
      continentTemplate.properties.fillOpacity = 0.8; // Reduce conflict with back to continents map label
      continentTemplate.propertyFields.fill = "color";
      continentTemplate.nonScalingStroke = true;
      let temporary;
      let temporary2;
      // let continentNameList: Array<string>;
      let continentNameList: Array<string> = ["africa", "asia", "oceania", "europe", "northAmerica", "southAmerica"];
      let temp: any;
      let newContinentNameList: Array<string>;
      continentTemplate.events.on("hit", function (event) {
        debugger;
        // continentNameList = ["africa", "asia", "oceania", "europe", "northAmerica", "southAmerica"]
        temp = event.target.dataItem.dataContext;
        newContinentNameList = continentNameList.filter(continentName => continentName != temp.id);
        // continentsSeries.include = [...newContinentNameList];
        // continentsSeries.include.push(temp.id);
        var countrylist = [];
        var selectContinentCountrylist = [];
        debugger;
        if (temporary === event.target) {
          debugger;
          if (!countriesSeries.visible) countriesSeries.visible = true;
          chart.zoomToMapObject(event.target);
          
          // countrylist.forEach(item => {
          //   countriesSeries.getPolygonById(item).hide();
          // })
          countryTemplate.show();
          countriesSeries.show();



        }
        else {
          chart.zoomToMapObject(event.target);

          newContinentNameList.forEach(item => {
            continentsSeries.getPolygonById(item).hide();
            // continentsSeries.exclude.push(item);

          })
          //  continentsSeries.exclude.push("africa");
          //  continentsSeries.hide();



          temporary = event.target;
          debugger;
          for (var id in self.countries) {
            // debugger;
            if (self.countries.hasOwnProperty(id)) {
              var country = self.countries[id];
              if (country.continent != temp.id.charAt(0).toUpperCase()+temp.id.substring(1))
                countrylist = [...countrylist, id];
              else
              selectContinentCountrylist = [...countrylist, id];

            }
          }
          



        }
      });

      let contintentHover = continentTemplate.states.create("hover");
      contintentHover.properties.fill = hoverColor;
      contintentHover.properties.stroke = hoverColor;

      continentsSeries.dataFields.zoomLevel = "zoomLevel";
      continentsSeries.dataFields.zoomGeoPoint = "zoomGeoPoint";

      // countrySeries.geodataSource.events.on("done", function (ev) {
      //   worldSeries.hide();
      //   countrySeries.show();
      // });
      // Countries
      let countriesSeries = chart.series.push(new am4maps.MapPolygonSeries());
      // let countries = countriesSeries.mapPolygons;
      let countries = countriesSeries.mapPolygons.template;
      // countriesSeries.visible = false; // start off as hidden
      debugger;
      countriesSeries.geodata = am4geodata_worldLow;
      // countriesSeries.geodata = this.asiaCountries;
      countriesSeries.useGeodata = true;
      countriesSeries.exclude = ["AQ"];

      countriesSeries.geodataSource.events.on("done", function (ev) {
        continentsSeries.hide();
        countriesSeries.show();
      });

      // Hide each country so we can fade them in
      countriesSeries.events.once("inited", function () {
        hideCountries();
        // countriesSeries.hide();
      });
      // let countryTemplate = countries.template;
      debugger;
      let countryTemplate = countriesSeries.mapPolygons.template;
      countryTemplate.applyOnClones = true;
      countryTemplate.fill = am4core.color("#a791b4");
      countryTemplate.fillOpacity = 0.3; // see continents underneath, however, country shapes are more detailed than continents.
      countryTemplate.strokeOpacity = 0.5;
      countryTemplate.nonScalingStroke = true;
      // countryTemplate.tooltipText = "{name} {valuess}";
      countryTemplate.tooltipText = "{name}";

      // countryTemplate.fill = am4core.color("#eee");
      countryTemplate.fill = am4core.color("#bfb0b0");
      // countryTemplate.fill = am4core.color("#ffffff");
      countryTemplate.propertyFields.fill = "color";
      countryTemplate.propertyFields.id = "id";

      // let lastSelected;
      countryTemplate.events.on("hit", function (event) {
        debugger;
        // chart.zoomToMapObject(event.target);


        debugger;
        // if (lastSelected === event.target) {

          // This line serves multiple purposes:
          // 1. Clicking a country twice actually de-activates, the line below
          //    de-activates it in advance, so the toggle then re-activates, making it
          //    appear as if it was never de-activated to begin with.
          // 2. Previously activated countries should be de-activated.
          // lastSelected.isActive = false;
          // lastSelected = undefined;

          // ev.target.series.chart.zoomToMapObject(ev.target);
          let temp: any = event.target.dataItem.dataContext;

          // if (temp.map != undefined) {
          //   self.showDestinationInfo = true;
          //   self.destinationCountryId = temp.id;
          //   self.map_title = temp.name;
          //   self.GetCountryInfoByCountryCode(self.destinationCountryId);
          //   self.ref.detectChanges();
          // }

          var map = temp.map;
          if (map) {
            event.target.isHover = false;
            stateSeries.geodataSource.url = "https://www.amcharts.com/lib/4/geodata/json/" + map + ".json";
            stateSeries.geodataSource.load();
            // button.show();
          }

          if (temp.id == "IN") {
            stateTemplate.show();
            stateSeries.show();

            // stateSeries.include= ['IN-MP', 'IN-RJ', 'IN-PB']
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

            stateSeries.data = country_data;
          }
          else {
          stateTemplate.show();
          stateSeries.show();

            stateSeries.data = [];
            //  countrySeries = chart.series.push(new am4maps.MapPolygonSeries());
            stateSeries.useGeodata = true;
            stateSeries.geodataSource.url = "https://www.amcharts.com/lib/4/geodata/json/" + map + ".json";
            stateSeries.geodataSource.load();
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
          stateTemplate.fill = am4core.color(self.countryColor);



        // }
        chart.maxZoomLevel = 50;
        event.target.series.chart.zoomToMapObject(event.target);
        // if (lastSelected !== event.target) {
        //   lastSelected = event.target;
        // }

      });

      let countryHover = countryTemplate.states.create("hover");
      countryHover.properties.fill = hoverColor;
      countryHover.properties.fillOpacity = 0.8; // Reduce conflict with back to continents map label
      countryHover.properties.stroke = hoverColor;
      countryHover.properties.strokeOpacity = 1;

      // Create State specific series (but hide it for now)
      var stateSeries = chart.series.push(new am4maps.MapPolygonSeries());
      stateSeries.useGeodata = true;
      stateSeries.hide();
      stateSeries.geodataSource.events.on("done", function (ev) {
        continentsSeries.hide();
        countriesSeries.hide();
        stateSeries.show();
      });

      var stateTemplate = stateSeries.mapPolygons.template;
      stateTemplate.tooltipText = "{name} \n packages: {packages} \n capital city : {capital_city} \n value : {value}";
      stateTemplate.nonScalingStroke = true;
      stateTemplate.strokeOpacity = 0.5;
      stateTemplate.fill = am4core.color("#6771dc");

      var hs = stateTemplate.states.create("hover");
      hs.properties.fill = am4core.color("#BC8F8F");   // comment

      //Set min/max fill color for each area
      stateSeries.heatRules.push({
        property: "fill",
        target: stateSeries.mapPolygons.template,
        min: chart.colors.getIndex(1).brighten(1),
        max: chart.colors.getIndex(1).brighten(-0.3)
      });



      // Set up click events 
      // Country click events 
      stateTemplate.events.on("hit", function (ev) {
        console.log("hit state data of country", ev.target.dataItem.dataContext);
      });



      // Set up data for countries
       var data:Array<any> = [];
       for (var id in self.countries) {
         if (self.countries.hasOwnProperty(id)) {
           var country = self.countries[id];
          //  if(country.continent == "Asia"){
            if (country.maps.length) {
              data.push({
                id: id,
                // color: chart.colors.getIndex(self.continents[country.continent_code]),
                map: country.maps[0],
                valuess: "30 packages in ",
              });
            }
            else {
              data.push({
                id: id,
                // color: chart.colors.getIndex(self.continents[country.continent_code]),
                valuess: "30 packages in ",
                zoomLevel: 20,

              });
            }
          //  }

         }
       }
       countriesSeries.data = data;

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



}
