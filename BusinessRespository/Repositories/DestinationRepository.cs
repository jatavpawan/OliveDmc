using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class DestinationRepository :IDestinationRepository
    {
        private TravelOliveContext Context;

        public DestinationRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateDestinationInCountry(Destination obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var DestinationObj = Context.Destination.Where(z => z.Id == obj.Id).FirstOrDefault();
                    DestinationObj.CountryCode = obj.CountryCode;
                    DestinationObj.AboutCountry = obj.AboutCountry;
                    DestinationObj.TopAttraction = obj.TopAttraction;
                    DestinationObj.TopDestination = obj.TopDestination;
                    DestinationObj.Visadetail = obj.Visadetail;
                    DestinationObj.HowToReach = obj.HowToReach;
                    DestinationObj.Miscellaneous = obj.Miscellaneous;
                    DestinationObj.Video = obj.Video;
                    DestinationObj.RecUpd = "U";
                    DestinationObj.UpdatedBy = 1;
                    DestinationObj.UpdatedDate = DateTime.Now;

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (!Context.Destination.Where(z => z.CountryCode == obj.CountryCode && z.RecUpd != "D").Any())
                    {
                        obj.RecUpd = "C";
                        obj.CreatedBy = 1;
                        obj.CreatedDate = DateTime.Now;

                        Context.Destination.Add(obj);
                        Context.SaveChanges();
                        result.message = "Successfully Saved";
                        result.status = Status.Success;
                    }
                    else
                    {

                        result.message = "Record already Exists";
                        result.status = Status.Warning;
                    }

                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }


        public ResponseModel GetCountryInfoByCountryCode(string countryCode)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                Destination destinationObj = null;
                destinationObj = Context.Destination.Where(x => x.CountryCode == countryCode && x.RecUpd != "D" ).FirstOrDefault();
                if (destinationObj == null)
                {
                    result.message = "Record Not Found";
                    result.status = Status.Warning;
                }

                else
                {
                    result.message = "Successfully Return Country Info By Country Code";
                    result.status = Status.Success;
                }
                result.data = destinationObj;
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteCountryInfoById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Destination> lst = new List<Destination>();
                if (Id > 0)
                {
                    var DestinationDetail = Context.Destination.Where(z => z.Id == Id).FirstOrDefault();
                    DestinationDetail.RecUpd = "D";
                    //Context.Destination.Remove(DestinationDetail);
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

        public ResponseModel GetAllDestinationCountry()
        {
            ResponseModel result = new ResponseModel();
            try
            {

                List<Destination> destinationList = new List<Destination>();
                destinationList = Context.Destination.Where(z => z.RecUpd != "D").ToList();
                if (destinationList.Count == 0)
                {
                    result.message = "Any Record Not Found";
                    result.status = Status.Warning;
                }

                else
                {
                    result.message = "List For All Destination Country";
                    result.status = Status.Success;
                }
                result.data = destinationList;
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string fileUploadInDestination(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Map\image", imageFile);

            }

            return imageFile;
        }

        public string videoUploadInDestination(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Map\Video", imageFile);

            }

            return imageFile;
        }


    }
}
