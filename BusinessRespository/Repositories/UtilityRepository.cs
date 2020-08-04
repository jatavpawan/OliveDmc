using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class UtilityRepository:IUtilityRepository
    {
        private TravelOliveContext Context;

        public UtilityRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateUtility(vmUtility obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string ImagePath = string.Empty;
                if (obj.Image != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    ImagePath = obj.Image != null ? prefixpath + "_" + obj.Image.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.Image != null) uploadcls.fileUpload(obj.Image, @"Uploads\Utility\image", ImagePath);

                }

                if (obj.Id > 0)
                {
                    var UtilityObj = Context.TravelUtility.Where(z => z.Id == obj.Id).FirstOrDefault();
                    UtilityObj.UtilityType = obj.UtilityType;
                    UtilityObj.Description = obj.Description;
                    UtilityObj.CountryId = obj.CountryId;
                    UtilityObj.StateId = obj.StateId;
                    UtilityObj.CityId = obj.CityId;
                    UtilityObj.Status = obj.Status;
                    UtilityObj.Video = obj.Video;

                    UtilityObj.RecUpd = "U";

                    UtilityObj.UpdatedBy = obj.UpdatedBy;
                    UtilityObj.UpdatedDate = DateTime.Now;
                    if (obj.Image != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Utility\image", UtilityObj.Image);
                        UtilityObj.Image = ImagePath;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    var UtilityObj = Context.TravelUtility.Where(z => z.UtilityType == obj.UtilityType).FirstOrDefault();

                    if (UtilityObj == null)
                    {
                        var UtilityDetail = new TravelUtility
                        {
                            UtilityType = obj.UtilityType,
                            Description = obj.Description,
                            CountryId = obj.CountryId,
                            StateId = obj.StateId,
                            CityId = obj.CityId,
                            Status = obj.Status,
                            Image = ImagePath,
                            Video = obj.Video,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now

                        };
                        Context.TravelUtility.Add(UtilityDetail);
                        Context.SaveChanges();
                    }
                    else
                    {
                        UtilityObj.UtilityType = obj.UtilityType;
                        UtilityObj.Description = obj.Description;
                        UtilityObj.CountryId = obj.CountryId;
                        UtilityObj.StateId = obj.StateId;
                        UtilityObj.CityId = obj.CityId;
                        UtilityObj.Status = obj.Status;
                        UtilityObj.Image = ImagePath;
                        UtilityObj.Video = obj.Video;
                        UtilityObj.RecUpd = "U";
                        UtilityObj.UpdatedBy = obj.UpdatedBy;
                        UtilityObj.UpdatedDate = DateTime.Now;

                        Context.SaveChanges();
                    }
                    
                    result.message = "Successfully Saved";
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


        public ResponseModel GetAllUtility()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TravelUtility> resultValue = new List<TravelUtility>();
                resultValue = Context.TravelUtility.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Utility";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteUtility(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TravelUtility> lst = new List<TravelUtility>();
                if (Id > 0)
                {
                    var UtilityDetail = Context.TravelUtility.Where(z => z.Id == Id).FirstOrDefault();
                    UtilityDetail.RecUpd = "D";
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

        public string fileUploadInUtility(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Utility\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel getUtilityDetailByUtilityType(string UtilityType)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                //List<vmUtilityDetail> UtilityDetail = new List<vmUtilityDetail>();
                vmUtilityDetail UtilityDetail = new vmUtilityDetail();
                if (UtilityType != string.Empty)
                {
                    //var resultValue = Context.TravelUtility.Where(z => z.RecUpd != "D" && z.UtilityType == UtilityType).FirstOrDefault();

                    

                    var innerJoin = from city in Context.City
                                    join travelUtility in Context.TravelUtility
                                    on city.Id equals travelUtility.CityId
                                    join state in  Context.State 
                                    on travelUtility.StateId equals state.Id 
                                    join country in Context.Country
                                    on travelUtility.CountryId equals country.Id
                                    select new vmUtilityDetail
                                    {
                                        Id = travelUtility.Id,
                                        Description = travelUtility.Description,
                                        Status = travelUtility.Status,
                                        Image = travelUtility.Image,
                                        CountryId = travelUtility.CountryId,
                                        CountryName = country.CountryName,
                                        StateId = travelUtility.StateId,
                                        StateName = state.StateName,
                                        CityId = travelUtility.CityId,
                                        CityName = city.CityName,
                                        RecUpd = travelUtility.RecUpd,
                                        CreatedDate = travelUtility.CreatedDate,
                                        CreatedBy = travelUtility.CreatedBy,
                                        UpdatedDate = travelUtility.UpdatedDate,
                                        UpdatedBy = travelUtility.UpdatedBy,
                                        UtilityType = travelUtility.UtilityType,
                                        Video = travelUtility.Video
                                    };
                                      
                    UtilityDetail = innerJoin.Where(z => z.RecUpd != "D" && z.UtilityType == UtilityType).FirstOrDefault();
                    //UtilityDetail = innerJoin.Where(z => z.RecUpd != "D").ToList();
                }

                result.data = UtilityDetail;
                result.status = Status.Success;
                result.message = "Utility Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInUtility(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Utility\Video", imageFile);

            }

            return imageFile;
        }


        public void deleteVideoInUtility(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Utility\Video", oldVideoName);

            }
        }




    }
}
