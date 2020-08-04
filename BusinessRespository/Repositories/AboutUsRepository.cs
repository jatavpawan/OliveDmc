using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class AboutUsRepository: IAboutUsRepository
    {
        private TravelOliveContext Context;

        public AboutUsRepository (TravelOliveContext _context)
        {
            Context = _context;
        }

        //public void AddUpdateAboutUsDetail(vmAboutUsDetail obj)
        //{
        //    AboutUs aboutusObj = new AboutUs();
        //    aboutusObj.Description = obj.Description;
        //    aboutusObj.Status = obj.Status;
        //    aboutusObj.CreatedDate = DateTime.Now;
        //    aboutusObj.CreatedBy = 1;
        //    aboutusObj.UpdatedDate = DateTime.Now;
        //    aboutusObj.UpdatedBy = 1;
        //    Context.AboutUs.Add(aboutusObj);
        //    Context.SaveChanges();
        //}


        public ResponseModel AddUpdateAboutUsDetail(AboutUs obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var aboutusObj = Context.AboutUs.Where(z => z.Id == obj.Id).FirstOrDefault();
                    aboutusObj.Status = obj.Status;
                    aboutusObj.Description = obj.Description;
                    aboutusObj.RecUpd = "U";
                    aboutusObj.UpdatedBy = obj.UpdatedBy;
                    aboutusObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;
                }
                else
                {
                   var aboutusObj = Context.AboutUs.FirstOrDefault();

                    if(aboutusObj == null)
                    {
                       obj.CreatedDate = DateTime.Now;
                       obj.CreatedBy = obj.CreatedBy;
                       obj.RecUpd = "C";
                       Context.AboutUs.Add(obj);
                       result.message = "Successfully Saved";

                    }
                    else
                    {
                        aboutusObj.Status = obj.Status;
                        aboutusObj.Description = obj.Description;
                        aboutusObj.RecUpd = "U";
                        aboutusObj.UpdatedBy = obj.UpdatedBy;
                        aboutusObj.UpdatedDate = DateTime.Now;
                        result.message = "Successfully Updated";
                    }

                    Context.SaveChanges();
                   
                     result.status = Status.Success;
                    
                }




            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public List<vmGetAboutUsDetail> GetAboutUsDetail()
        {
            List<vmGetAboutUsDetail> aboutUsObj;
            aboutUsObj = Context.AboutUs.Where(z => z.RecUpd != "D").Select(x => new vmGetAboutUsDetail
            {
                Id = x.Id,
                Description = x.Description,
                Status = x.Status,

            }).ToList();
                 
            return aboutUsObj;
        }


        public ResponseModel deleteAboutUsInfo(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AboutUs> lst = new List<AboutUs>();
                if (Id > 0)
                {
                    var AboutUsDetail = Context.AboutUs.Where(z => z.Id == Id).FirstOrDefault();
                    AboutUsDetail.RecUpd = "D";
                    //Context.AboutUs.Remove(AboutUsDetail);
                    Context.SaveChanges();
                }

                result.data = lst;
                result.status = Status.Success;
                result.message = "delete successfully";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
        
        public string fileUploadInAboutUs(vmfileInfo obj)
        {
           
                string imageFile = string.Empty;
                if (obj.fileInfo != null)
                {
                    imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\AboutUS\image", imageFile);

                }

           return imageFile;
        }



    }


}
