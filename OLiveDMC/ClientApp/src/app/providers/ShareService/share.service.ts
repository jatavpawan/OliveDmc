import { Injectable } from '@angular/core';
import { DataService } from '../dataservice/data.service';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/model/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class ShareService {

  constructor(private dataService: DataService) { 
  }


  GetAllPage()
  {
    return <Observable<ResponseModel>> this.dataService.getData('Banner/GetAllPage');
  }
}
