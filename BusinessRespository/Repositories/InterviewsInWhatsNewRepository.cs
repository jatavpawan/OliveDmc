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
    class InterviewsInWhatsNewRepository : IInterviewsInWhatsNewRepository
    {
        private TravelOliveContext Context;

        public InterviewsInWhatsNewRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateInterviewsInWhatsNew(vmInterviewsInWhatsNew obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\InterviewsInWhatsNew\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var InterviewsInWhatsNewObj = Context.InterviewsInWhatsNew.Where(z => z.Id == obj.Id).FirstOrDefault();
                    InterviewsInWhatsNewObj.Title  = obj.Title;
                    InterviewsInWhatsNewObj.ShortDescription  = obj.ShortDescription;
                    InterviewsInWhatsNewObj.Description = obj.Description;
                    InterviewsInWhatsNewObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    InterviewsInWhatsNewObj.ImageShowInFront = obj.ImageShowInFront;
                    InterviewsInWhatsNewObj.VideoShowInFront = obj.VideoShowInFront;
                    InterviewsInWhatsNewObj.RecUpd = "U";
                    InterviewsInWhatsNewObj.Video = obj.Video;
                    InterviewsInWhatsNewObj.UpdatedBy = obj.UpdatedBy;
                    InterviewsInWhatsNewObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\InterviewsInWhatsNew\image", InterviewsInWhatsNewObj.FeaturedImage);
                        InterviewsInWhatsNewObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.InterviewsInWhatsNew.Where(z => z.InterviewsInWhatsNewName == obj.InterviewsInWhatsNewName).Any();


                    if (!Context.InterviewsInWhatsNew.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var InterviewsInWhatsNewDetail = new InterviewsInWhatsNew
                        {
                            Title = obj.Title,
                            ShortDescription = obj.ShortDescription,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            ImageShowInFront = obj.ImageShowInFront,
                            VideoShowInFront = obj.VideoShowInFront,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.InterviewsInWhatsNew.Add(InterviewsInWhatsNewDetail);
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


        public ResponseModel GetAllInterviewsInWhatsNew()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<InterviewsInWhatsNew> resultValue = new List<InterviewsInWhatsNew>();
                resultValue = Context.InterviewsInWhatsNew.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for InterviewsInWhatsNew";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteInterviewsInWhatsNew(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<InterviewsInWhatsNew> lst = new List<InterviewsInWhatsNew>();
                if (Id > 0)
                {
                    var InterviewsInWhatsNewDetail = Context.InterviewsInWhatsNew.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\InterviewsInWhatsNew\image", InterviewsInWhatsNewDetail.FeaturedImage);
                    InterviewsInWhatsNewDetail.RecUpd = "D";
                    //Context.InterviewsInWhatsNew.Remove(InterviewsInWhatsNewDetail);
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

        public string fileUploadInInterviewsInWhatsNew(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\InterviewsInWhatsNew\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetInterviewsInWhatsNewDetailByInterviewsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var InterviewsInWhatsNewDetail = new InterviewsInWhatsNew();
                if (Id > 0)
                {
                    InterviewsInWhatsNewDetail = Context.InterviewsInWhatsNew.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = InterviewsInWhatsNewDetail;
                result.status = Status.Success;
                result.message = "InterviewsInWhatsNew Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInInterviewsInWhatsNew(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\InterviewsInWhatsNew\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInInterviewsInWhatsNew(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\InterviewsInWhatsNew\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllInterviewsInWhatsNewFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<InterviewsInWhatsNew> resultValue = new List<InterviewsInWhatsNew>();
                resultValue = Context.InterviewsInWhatsNew.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for InterviewsInWhatsNew";
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
