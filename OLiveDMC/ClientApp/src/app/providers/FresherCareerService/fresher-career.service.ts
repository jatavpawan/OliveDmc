import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/model/ResponseModel';
import { DataService } from '../dataservice/data.service';

@Injectable({
  providedIn: 'root'
})
export class FresherCareerService {

  constructor(
    private dataService: DataService,
    private http : HttpClient
  ) { }

  AddUpdateFresherCareer(data){
    return <Observable<ResponseModel>> this.dataService.postFormData('FresherCareer/AddUpdateFresherCareer', data);
  }


  GetAllFresherCareer()
  {
    return <Observable<ResponseModel>> this.dataService.getData('FresherCareer/GetAllFresherCareer');
  }
  
  GetFresherCareerById(FresherCareerId)
  {
    return <Observable<ResponseModel>> this.dataService.getData('FresherCareer/GetFresherCareerDetailByFresherCareerId?id='+FresherCareerId);
  }
  
  deleteFresherCareer(FresherCareerId)
  {
    return <Observable<ResponseModel>> this.dataService.getData('FresherCareer/deleteFresherCareer?Id='+FresherCareerId);
  }

  // getImage(imageUrl: string) {
  //   return this.http.get(imageUrl, {observe: 'response', responseType: 'blob'}).map((res) => {
  //       return new Blob([res.body], {type: res.headers.get('Content-Type')});
  //     })
  // }
 
}
