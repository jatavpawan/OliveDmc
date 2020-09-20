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
    class EventRepository: IEventRepository
    {
        private TravelOliveContext Context;

        public EventRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateEvent(vmEvent obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Event\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var EventObj = Context.Event.Where(z => z.Id == obj.Id).FirstOrDefault();
                    EventObj.Title = obj.Title;
                    EventObj.ShortDescription = obj.ShortDescription;
                    EventObj.Description = obj.Description;
                    EventObj.Status = obj.Status;
                    EventObj.VideoShowInFront = obj.VideoShowInFront;
                    EventObj.ImageShowInFront = obj.ImageShowInFront;
                    EventObj.RecUpd = "U";
                    EventObj.Video = obj.Video;
                    EventObj.UpdatedBy = obj.UpdatedBy;
                    EventObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Event\image", EventObj.FeaturedImage);
                        EventObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.Event.Where(z => z.EventName == obj.EventName).Any();


                    if (!Context.Event.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var EventDetail = new Event
                        {
                            Title = obj.Title,
                            ShortDescription = obj.ShortDescription,
                            Description = obj.Description,
                            Status = obj.Status,
                            ImageShowInFront = obj.ImageShowInFront,
                            VideoShowInFront = obj.VideoShowInFront,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.Event.Add(EventDetail);
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


        public ResponseModel GetAllEvent()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Event> resultValue = new List<Event>();
                resultValue = Context.Event.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Event";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteEvent(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Event> lst = new List<Event>();
                if (Id > 0)
                {
                    var EventDetail = Context.Event.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Event\image", EventDetail.FeaturedImage);
                    EventDetail.RecUpd = "D";
                    //Context.Event.Remove(EventDetail);
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

        public string fileUploadInEvent(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Event\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetEventDetailByEventId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var EventDetail = new Event();
                if (Id > 0)
                {
                    EventDetail = Context.Event.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = EventDetail;
                result.status = Status.Success;
                result.message = "Event Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInEvent(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Event\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInEvent(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Event\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllEventInFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Event> resultValue = new List<Event>();
                resultValue = Context.Event.Where(z => z.RecUpd != "D" && z.Status == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Event";
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
