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
    class CurrentNewsRepository: ICurrentNewsRepository
    {
        private TravelOliveContext Context;

        public CurrentNewsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateCurrentNews(vmCurrentNews obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\CurrentNews\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var CurrentNewsObj = Context.CurrentNews.Where(z => z.Id == obj.Id).FirstOrDefault();
                    CurrentNewsObj.Title = obj.Title;
                    CurrentNewsObj.Description = obj.Description;
                    CurrentNewsObj.Status = obj.Status;
                    CurrentNewsObj.RecUpd = "U";
                    CurrentNewsObj.Video = obj.Video;
                    CurrentNewsObj.UpdatedBy = obj.UpdatedBy;
                    CurrentNewsObj.UpdatedDate = DateTime.Now;

                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\CurrentNews\image", CurrentNewsObj.FeaturedImage);
                        CurrentNewsObj.FeaturedImage = FeaturedImage;
                    }
                    

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    if (!Context.CurrentNews.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var CurrentNewsDetail = new CurrentNews
                        {
                            Title = obj.Title,
                            Description = obj.Description,
                            Status = obj.Status,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.CurrentNews.Add(CurrentNewsDetail);
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


        public ResponseModel GetAllCurrentNews()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<CurrentNews> resultValue = new List<CurrentNews>();
                resultValue = Context.CurrentNews.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for CurrentNews";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteCurrentNews(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<CurrentNews> lst = new List<CurrentNews>();
                if (Id > 0)
                {
                    var CurrentNewsDetail = Context.CurrentNews.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\CurrentNews\image", CurrentNewsDetail.FeaturedImage);
                    CurrentNewsDetail.RecUpd = "D";
                    //Context.CurrentNews.Remove(CurrentNewsDetail);
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

        public string fileUploadInCurrentNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\CurrentNews\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetCurrentNewsDetailByCurrentNewsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var CurrentNewsDetail = new CurrentNews();
                if (Id > 0)
                {
                    CurrentNewsDetail = Context.CurrentNews.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = CurrentNewsDetail;
                result.status = Status.Success;
                result.message = "CurrentNews Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInCurrentNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\CurrentNews\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInCurrentNews(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\CurrentNews\Video", oldVideoName);

            }
        }

    }
}
