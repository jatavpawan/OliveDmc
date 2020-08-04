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
    class TopDestinationRepository: ITopDestinationRepository
    {
        private TravelOliveContext Context;

        public TopDestinationRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateTopDestination(VmTopDestination obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string FeaturedImage = string.Empty;
                if (obj.FeaturedImage != null || obj.FeaturedImage != null || obj.FeaturedImage != null || obj.FeaturedImage != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    FeaturedImage = obj.FeaturedImage != null ? prefixpath + "_" + obj.FeaturedImage.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Home\TopDestination\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var TopDestinationObj = Context.TopDestination.Where(z => z.Id == obj.Id).FirstOrDefault();
                    TopDestinationObj.Title = obj.Title;
                    TopDestinationObj.Description = obj.Description;
                    TopDestinationObj.CountryId = obj.CountryId;
                    TopDestinationObj.StateId = obj.StateId;
                    TopDestinationObj.CityId = obj.CityId;
                    TopDestinationObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    TopDestinationObj.RecUpd = "U";
                    TopDestinationObj.UpdatedBy = obj.UpdatedBy;
                    TopDestinationObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Home\TopDestination\image", TopDestinationObj.FeaturedImage);
                        TopDestinationObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.TopDestination.Where(z => z.TopDestinationName == obj.TopDestinationName).Any();


                    if (!Context.TopDestination.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var TopDestinationDetail = new TopDestination
                        {
                            Title = obj.Title,
                            Description = obj.Description,
                            CountryId = obj.CountryId,
                            StateId = obj.StateId,
                            CityId = obj.CityId,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.TopDestination.Add(TopDestinationDetail);
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


        public ResponseModel GetAllTopDestination()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TopDestination> resultValue = new List<TopDestination>();
                resultValue = Context.TopDestination.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for TopDestination";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteTopDestination(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TopDestination> lst = new List<TopDestination>();
                if (Id > 0)
                {
                    var TopDestinationDetail = Context.TopDestination.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Home\TopDestination\image", TopDestinationDetail.FeaturedImage);
                    TopDestinationDetail.RecUpd = "D";
                    //Context.TopDestination.Remove(TopDestinationDetail);
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

        public string fileUploadInTopDestination(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\TopDestination\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetTopDestinationDetailByTopDestinationId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var TopDestinationDetail = new TopDestination();
                if (Id > 0)
                {
                    TopDestinationDetail = Context.TopDestination.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = TopDestinationDetail;
                result.status = Status.Success;
                result.message = "TopDestination Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInTopDestination(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\TopDestination\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInTopDestination(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Home\TopDestination\Video", oldVideoName);

            }
        }

        
        public ResponseModel GetTopDestinationByCountryId(int? CountryId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TopDestination> resultValue = new List<TopDestination>();
                resultValue = Context.TopDestination.Where(z => z.CountryId == CountryId && z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for TopDestination";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

    }
}
