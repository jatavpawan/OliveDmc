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
    class NewsRepository: INewsRepository
    {
        private TravelOliveContext Context;

        public NewsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateNews(vmNews obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\News\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var NewsObj = Context.News.Where(z => z.Id == obj.Id).FirstOrDefault();
                    NewsObj.Title = obj.Title;
                    NewsObj.ShortDescription = obj.ShortDescription;
                    NewsObj.Description = obj.Description;
                    NewsObj.Status = obj.Status;
                    NewsObj.RecUpd = "U";
                    NewsObj.Video = obj.Video;
                    NewsObj.UpdatedBy = obj.UpdatedBy;
                    NewsObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\News\image", NewsObj.FeaturedImage);
                        NewsObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.News.Where(z => z.NewsName == obj.NewsName).Any();


                    if (!Context.News.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var NewsDetail = new News
                        {
                            Title = obj.Title,
                            ShortDescription = obj.ShortDescription,
                            Description = obj.Description,
                            Status = obj.Status,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.News.Add(NewsDetail);
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


        public ResponseModel GetAllNews()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<News> resultValue = new List<News>();
                resultValue = Context.News.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for News";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteNews(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<News> lst = new List<News>();
                if (Id > 0)
                {
                    var NewsDetail = Context.News.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\News\image", NewsDetail.FeaturedImage);
                    NewsDetail.RecUpd = "D";
                    //Context.News.Remove(NewsDetail);
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

        public string fileUploadInNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\News\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetNewsDetailByNewsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var NewsDetail = new News();
                if (Id > 0)
                {
                    NewsDetail = Context.News.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = NewsDetail;
                result.status = Status.Success;
                result.message = "News Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\News\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInNews(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\News\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllNewsinFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<News> resultValue = new List<News>();
                resultValue = Context.News.Where(z => z.RecUpd != "D" && z.Status == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for News";
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
