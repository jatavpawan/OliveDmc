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
    class FestivalRepository : IFestivalRepository
    {
        private TravelOliveContext Context;

        public FestivalRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateFestival(vmFestival obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Festival\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var FestivalObj = Context.Festival.Where(z => z.Id == obj.Id).FirstOrDefault();
                    FestivalObj.Title = obj.Title;
                    FestivalObj.ShortDescription = obj.ShortDescription;
                    FestivalObj.Description = obj.Description;
                    FestivalObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    FestivalObj.ImageShowInFront = obj.ImageShowInFront;
                    FestivalObj.VideoShowInFront = obj.VideoShowInFront;
                    FestivalObj.RecUpd = "U";
                    FestivalObj.Video = obj.Video;
                    FestivalObj.UpdatedBy = obj.UpdatedBy;
                    FestivalObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Festival\image", FestivalObj.FeaturedImage);
                        FestivalObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.Festival.Where(z => z.FestivalName == obj.FestivalName).Any();


                    if (!Context.Festival.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var FestivalDetail = new Festival
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
                        Context.Festival.Add(FestivalDetail);
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


        public ResponseModel GetAllFestival()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Festival> resultValue = new List<Festival>();
                resultValue = Context.Festival.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Festival";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteFestival(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Festival> lst = new List<Festival>();
                if (Id > 0)
                {
                    var FestivalDetail = Context.Festival.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Festival\image", FestivalDetail.FeaturedImage);
                    FestivalDetail.RecUpd = "D";
                    //Context.Festival.Remove(FestivalDetail);
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

        public string fileUploadInFestival(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Festival\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetFestivalDetailByFestivalId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var FestivalDetail = new Festival();
                if (Id > 0)
                {
                    FestivalDetail = Context.Festival.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = FestivalDetail;
                result.status = Status.Success;
                result.message = "Festival Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInFestival(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Festival\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInFestival(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Festival\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllFestivainFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Festival> resultValue = new List<Festival>();
                resultValue = Context.Festival.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Festival";
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
