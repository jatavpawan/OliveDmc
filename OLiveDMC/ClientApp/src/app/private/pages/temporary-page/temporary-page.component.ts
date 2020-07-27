import { Component, OnInit, NgZone, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4maps from "@amcharts/amcharts4/maps";
import am4geodata_worldLow from "@amcharts/amcharts4-geodata/worldLow";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import { allCountryData } from '../../shared/AllCountryData';

@Component({
  selector: 'app-temporary-page',
  templateUrl: './temporary-page.component.html',
  styleUrls: ['./temporary-page.component.css']
})
export class TemporaryPageComponent implements OnInit {

  chart: am4maps.MapChart;
  countries: any = allCountryData;
  countryColor: any;

  continents = {
    "AF": 0,
    "AN": 1,
    "AS": 2,
    "EU": 3,
    "NA": 4,
    "OC": 5,
    "SA": 6
  }


  constructor(private zone: NgZone,
    private ref: ChangeDetectorRef
  ) {
  }

  ngOnInit() {
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
      worldSeries.data = [{
          "id": "IN",
          "zoomLevel": 12,
          "zoomGeoPoint": {
            "latitude": -41,
            "longitude": 173
          }
        }, {
          "id": "RU",
          "zoomLevel": 12,
          "zoomGeoPoint": {
            "latitude": 62,
            "longitude": 96
          }
      }] 

      let worldPolygon = worldSeries.mapPolygons.template;
      //  worldPolygon.tooltipText = `{name} 
      //   \n package : {valuess}{name}`;
      worldPolygon.tooltipText = `{name}`;
      worldPolygon.applyOnClones = true;
      worldPolygon.nonScalingStroke = true;
      worldPolygon.strokeOpacity = 0.5;
      worldPolygon.fill = am4core.color("#eee");
      // worldPolygon.stroke = am4core.color("#eee");
      worldPolygon.propertyFields.fill = "color";
      worldPolygon.propertyFields.id = "id";

      // Set up click events 
      // Worlds click events 
      var self = this;
      let lastSelected;
      worldPolygon.events.on("hit", function (ev) {
        debugger;
        if (lastSelected === ev.target) {

          // This line serves multiple purposes:
          // 1. Clicking a country twice actually de-activates, the line below
          //    de-activates it in advance, so the toggle then re-activates, making it
          //    appear as if it was never de-activated to begin with.
          // 2. Previously activated countries should be de-activated.
          // lastSelected.isActive = false;
          lastSelected = undefined;

          // ev.target.series.chart.zoomToMapObject(ev.target);
          let temp: any = ev.target.dataItem.dataContext;
          
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
          countryPolygon.stroke = am4core.color(self.countryColor);



        }

        ev.target.series.chart.zoomToMapObject(ev.target);
        if (lastSelected !== ev.target) {
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
    // am4core.disposeAllCharts();
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
