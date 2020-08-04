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
    class UpcommingNewsRepository: IUpcommingNewsRepository
    {
        private TravelOliveContext Context;

        public UpcommingNewsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateUpcommingNews(vmUpcommingNews obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\UpcommingNews\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var UpcommingNewsObj = Context.UpcommingNews.Where(z => z.Id == obj.Id).FirstOrDefault();
                    UpcommingNewsObj.Title = obj.Title;
                    UpcommingNewsObj.Description = obj.Description;
                    UpcommingNewsObj.Status = obj.Status;
                    UpcommingNewsObj.RecUpd = "U";
                    UpcommingNewsObj.Video = obj.Video;
                    UpcommingNewsObj.UpdatedBy = obj.UpdatedBy;
                    UpcommingNewsObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\UpcommingNews\image", UpcommingNewsObj.FeaturedImage);
                        UpcommingNewsObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.UpcommingNews.Where(z => z.UpcommingNewsName == obj.UpcommingNewsName).Any();


                    if (!Context.UpcommingNews.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var UpcommingNewsDetail = new UpcommingNews
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
                        Context.UpcommingNews.Add(UpcommingNewsDetail);
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


        public ResponseModel GetAllUpcommingNews()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UpcommingNews> resultValue = new List<UpcommingNews>();
                resultValue = Context.UpcommingNews.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for UpcommingNews";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteUpcommingNews(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UpcommingNews> lst = new List<UpcommingNews>();
                if (Id > 0)
                {
                    var UpcommingNewsDetail = Context.UpcommingNews.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\UpcommingNews\image", UpcommingNewsDetail.FeaturedImage);
                    UpcommingNewsDetail.RecUpd = "D";
                    //Context.UpcommingNews.Remove(UpcommingNewsDetail);
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

        public string fileUploadInUpcommingNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\UpcommingNews\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetUpcommingNewsDetailByUpcommingNewsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UpcommingNewsDetail = new UpcommingNews();
                if (Id > 0)
                {
                    UpcommingNewsDetail = Context.UpcommingNews.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = UpcommingNewsDetail;
                result.status = Status.Success;
                result.message = "UpcommingNews Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public string videoUploadInUpcommingNews(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\UpcommingNews\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInUpcommingNews(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\UpcommingNews\Video", oldVideoName);

            }
        }
    }
}
