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
    class TrendingNewsRepository: ITrendingNewsRepository
    {
        private TravelOliveContext Context;

        public TrendingNewsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateTrendingNews(VmTrendingNews obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Home\TrendingNews\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var TrendingNewsObj = Context.TrendingNews.Where(z => z.Id == obj.Id && z.RecUpd != "D").FirstOrDefault();
                    TrendingNewsObj.Title = obj.Title;
                    TrendingNewsObj.Description = obj.Description;
                    TrendingNewsObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    TrendingNewsObj.RecUpd = "U";
                    TrendingNewsObj.UpdatedBy = obj.UpdatedBy;
                    TrendingNewsObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Home\TrendingNews\image", TrendingNewsObj.FeaturedImage);
                        TrendingNewsObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.TrendingNews.Where(z => z.TrendingNewsName == obj.TrendingNewsName).Any();


                    if (!Context.TrendingNews.Where(z => z.Title == obj.Title && z.RecUpd != "D" ).Any())
                    {
                        var TrendingNewsDetail = new TrendingNews
                        {
                            Title = obj.Title,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.TrendingNews.Add(TrendingNewsDetail);
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


        public ResponseModel GetAllTrendingNews()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TrendingNews> resultValue = new List<TrendingNews>();
                resultValue = Context.TrendingNews.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for TrendingNews";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteTrendingNews(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TrendingNews> lst = new List<TrendingNews>();
                if (Id > 0)
                {
                    var TrendingNewsDetail = Context.TrendingNews.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Home\TrendingNews\image", TrendingNewsDetail.FeaturedImage);
                    TrendingNewsDetail.RecUpd = "D";
                    //Context.TrendingNews.Remove(TrendingNewsDetail);
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

        public string fileUploadInTrendingNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\TrendingNews\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetTrendingNewsDetailByTrendingNewsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var TrendingNewsDetail = new TrendingNews();
                if (Id > 0)
                {
                    TrendingNewsDetail = Context.TrendingNews.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = TrendingNewsDetail;
                result.status = Status.Success;
                result.message = "TrendingNews Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInTrendingNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\TrendingNews\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInTrendingNews(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Home\TrendingNews\Video", oldVideoName);

            }
        }
    }
}
