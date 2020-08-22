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
    class LatestEventRepository : ILatestEventRepository
    {
        private TravelOliveContext Context;

        public LatestEventRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateLatestEvent(vmLatestEvent obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\LatestEvent\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var LatestEventObj = Context.LatestEvent.Where(z => z.Id == obj.Id).FirstOrDefault();
                    LatestEventObj.Title = obj.Title;
                    LatestEventObj.Description = obj.Description;
                    LatestEventObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    LatestEventObj.Location = obj.Location;
                    LatestEventObj.RecUpd = "U";
                    LatestEventObj.Video = obj.Video;
                    LatestEventObj.UpdatedBy = obj.UpdatedBy;
                    LatestEventObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\LatestEvent\image", LatestEventObj.FeaturedImage);
                        LatestEventObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.LatestEvent.Where(z => z.LatestEventName == obj.LatestEventName).Any();


                    if (!Context.LatestEvent.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var LatestEventDetail = new LatestEvent
                        {
                            Title = obj.Title,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            Location = obj.Location,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.LatestEvent.Add(LatestEventDetail);
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


        public ResponseModel GetAllLatestEvent()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<LatestEvent> resultValue = new List<LatestEvent>();
                resultValue = Context.LatestEvent.Where(z => z.RecUpd != "D").OrderByDescending(x => x.CreatedDate).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for LatestEvent";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteLatestEvent(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<LatestEvent> lst = new List<LatestEvent>();
                if (Id > 0)
                {
                    var LatestEventDetail = Context.LatestEvent.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\LatestEvent\image", LatestEventDetail.FeaturedImage);
                    LatestEventDetail.RecUpd = "D";
                    //Context.LatestEvent.Remove(LatestEventDetail);
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

        public string fileUploadInLatestEvent(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\LatestEvent\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetLatestEventDetailByEventId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var LatestEventDetail = new LatestEvent();
                if (Id > 0)
                {
                    LatestEventDetail = Context.LatestEvent.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = LatestEventDetail;
                result.status = Status.Success;
                result.message = "LatestEvent Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInLatestEvent(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\LatestEvent\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInLatestEvent(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\LatestEvent\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllLatestEventInFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<LatestEvent> resultValue = new List<LatestEvent>();
                resultValue = Context.LatestEvent.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).OrderByDescending(x => x.CreatedDate).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for LatestEvent";
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
