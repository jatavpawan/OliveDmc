import { Injectable } from '@angular/core';
import { DataService } from '../dataservice/data.service';
import { ResponseModel } from 'src/app/model/ResponseModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AboutUsService {

  constructor( private dataService: DataService) { }

  // <----------------------About-us------------------------------------------------->
  
  AddUpdateAboutUsDetail(data)
  {
    return <Observable<ResponseModel>> this.dataService.postData('AboutUs/AddUpdateAboutUsDetail', data);
  }
  removeAboutUsDetail(id)
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUs/deleteAboutUsInfo?Id='+id);
  }
  
  GetAboutUsDetail()
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUs/GetAboutUsDetail');
  }
 
  fileUploadInAboutUs(data)
  {
    return <Observable<ResponseModel>> this.dataService.postFormData('AboutUs/fileUploadInAboutUs', data);
  }

  // <----------------------About-us-Introduction------------------------------------------------->

  AddUpdateAboutUsIntroductionDetail(data)
  {
    return <Observable<ResponseModel>> this.dataService.postFormData('AboutUsIntroduction/AddUpdateAboutUsIntroductionDetail', data);
  }
  deleteAboutUsIntroductionInfo(id)
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsIntroduction/deleteAboutUsIntroductionInfo?Id='+id);
  }
  
  GetAboutUsIntroductionDetail()
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsIntroduction/GetAboutUsIntroductionDetail');
  }
 
  fileUploadInAboutUsIntroduction(data)
  {
    return <Observable<ResponseModel>> this.dataService.postFormData('AboutUsIntroduction/fileUploadInAboutUsIntroduction', data);
  }


  // <----------------------About-us-Statement------------------------------------------------->
  AddUpdateAboutUsStatement(data){
    return <Observable<ResponseModel>> this.dataService.postFormData('AboutUsStatement/AddUpdateAboutUsStatement', data);
  }


  GetAllAboutUsStatement()
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsStatement/GetAllAboutUsStatement');
  }
  
  GetAboutUsStatementDetailByAboutUsStatementId(AboutUsStatementId)
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsStatement/GetAboutUsStatementDetailByAboutUsStatementId?id='+AboutUsStatementId);
  }
 
  editAboutUsStatement(data)
  {
    return <Observable<ResponseModel>> this.dataService.postData('AboutUsStatement/AddUpdateAboutUsStatement', data);
  }
 
  deleteAboutUsStatement(AboutUsStatementId)
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsStatement/deleteAboutUsStatement?Id='+AboutUsStatementId);
  }
 
  fileUploadInAboutUsStatement(data)
  {
    return <Observable<ResponseModel>> this.dataService.postFormData('AboutUsStatement/fileUploadInAboutUsStatement', data);
  }
 
  videoUploadInAboutUsStatement(data)
  {
    return <Observable<ResponseModel>> this.dataService.postFormData('AboutUsStatement/videoUploadInAboutUsStatement', data);
  }

  deleteVideoInAboutUsStatement(oldVideoName:string){
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsStatement/deleteVideoInAboutUsStatement?oldVideoName='+oldVideoName);
  }

  GetAllAboutUsStatementinFrontEnd()
  {
    return <Observable<ResponseModel>> this.dataService.getData('AboutUsStatement/GetAllAboutUsStatementinFrontEnd');
  }


}
