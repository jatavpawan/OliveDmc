import { Component, OnInit, NgZone, ChangeDetectorRef } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4maps from "@amcharts/amcharts4/maps";
import am4geodata_worldLow from "@amcharts/amcharts4-geodata/worldLow";
import am4geodata_worldHigh from "@amcharts/amcharts4-geodata/worldHigh";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import { environment } from 'src/environments/environment';
import { allCountryData } from '../../shared/AllCountryData';
import am4geodata_continentsLow from "@amcharts/amcharts4-geodata/continentsLow";


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


  constructor(
    private zone: NgZone,
    private ref: ChangeDetectorRef
  ) {
    debugger;
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
        restoreContinents();
        continentsSeries.include = ["africa", "asia", "oceania", "europe", "northAmerica", "southAmerica",];
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
      let continentNameList: Array<string>;
      let temp: any;
      let newContinentNameList: Array<string>;
      continentTemplate.events.on("hit", function (event) {
        debugger;
        continentNameList = ["africa", "asia", "oceania", "europe", "northAmerica", "southAmerica"]
        temp = event.target.dataItem.dataContext;
        newContinentNameList = continentNameList.filter(continentName => continentName != temp.id);
        // continentsSeries.include = [...newContinentNameList];
        // continentsSeries.include.push(temp.id);
        var countrylist = [];
        var selectContinentCountrylist = [];
        if (temporary === event.target) {
          // if (!countriesSeries.visible) countriesSeries.visible = true;
          chart.zoomToMapObject(event.target);
          countrylist.forEach(item => {
            countriesSeries.getPolygonById(item).hide();
          })
          // selectContinentCountrylist.forEach(item => {
          //   countriesSeries.include.push(item);

          // })
          countryTemplate.show();
          newContinentNameList.forEach(item => {
            continentsSeries.getPolygonById(item).hide();
          })

        }
        else {
          chart.zoomToMapObject(event.target);

          newContinentNameList.forEach(item => {
            continentsSeries.getPolygonById(item).hide();
          })
          temporary = event.target;
          for (var id in self.countries) {
            if (self.countries.hasOwnProperty(id)) {
              var country = self.countries[id];
              if (country.continent != "Asia")
                countrylist = [...countrylist, id];
              // else
              // selectContinentCountrylist = [...countrylist, id];

            }
          }

        }
        // initializeContinentSeriesData();


        // if (!countriesSeries.visible) countriesSeries.visible = true;
        // chart.zoomToMapObject(event.target);
        // // chart.zoomToMapObject(event.target.parent);
        // countryTemplate.show();
      });

      let contintentHover = continentTemplate.states.create("hover");
      contintentHover.properties.fill = hoverColor;
      contintentHover.properties.stroke = hoverColor;

      continentsSeries.dataFields.zoomLevel = "zoomLevel";
      continentsSeries.dataFields.zoomGeoPoint = "zoomGeoPoint";

      // var countrySeries = chart.series.push(new am4maps.MapPolygonSeries());
      // countrySeries.useGeodata = true;
      // countrySeries.hide();
      // countrySeries.geodataSource.events.on("done", function (ev) {
      //   worldSeries.hide();
      //   countrySeries.show();
      // });
      // Countries
      let countriesSeries = chart.series.push(new am4maps.MapPolygonSeries());
      let countries = countriesSeries.mapPolygons;
      // countriesSeries.visible = false; // start off as hidden
      countriesSeries.exclude = ["AQ"];
      countriesSeries.geodata = am4geodata_worldLow;
      countriesSeries.useGeodata = true;

      // countriesSeries.geodataSource.events.on("done", function (ev) {
      //   continentsSeries.hide();
      //   countriesSeries.show();
      // });

      // Hide each country so we can fade them in
      countriesSeries.events.once("inited", function () {
        hideCountries();
      });
      let countryTemplate = countries.template;
      countryTemplate.applyOnClones = true;
      countryTemplate.fill = am4core.color("#a791b4");
      countryTemplate.fillOpacity = 0.3; // see continents underneath, however, country shapes are more detailed than continents.
      countryTemplate.strokeOpacity = 0.5;
      countryTemplate.nonScalingStroke = true;
      countryTemplate.tooltipText = "{name} {valuess}";
      countryTemplate.events.on("hit", function (event) {
        debugger;
        chart.zoomToMapObject(event.target);
      });

      let countryHover = countryTemplate.states.create("hover");
      countryHover.properties.fill = hoverColor;
      countryHover.properties.fillOpacity = 0.8; // Reduce conflict with back to continents map label
      countryHover.properties.stroke = hoverColor;
      countryHover.properties.strokeOpacity = 1;

   // Set up data for countries
  //  var data = [];
  //  for (var id in self.countries) {
  //    if (self.countries.hasOwnProperty(id)) {
  //      var country = self.countries[id];
  //      if (country.maps.length) {
  //        data.push({
  //          id: id,
  //          color: chart.colors.getIndex(self.continents[country.continent_code]),
  //          map: country.maps[0],
  //          valuess: "30 packages in ",

  //        });
  //      }
  //      else {
  //        data.push({
  //          id: id,
  //          color: chart.colors.getIndex(self.continents[country.continent_code]),
  //          valuess: "30 packages in ",
  //        });
  //      }
  //    }
  //  }
  //  countriesSeries.data = data;


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
