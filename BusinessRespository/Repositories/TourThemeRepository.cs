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
    class TourThemeRepository : ITourThemeRepository
    {
        private TravelOliveContext Context;

        public TourThemeRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateTheme(vmTourTheme obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\TourTheme\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var TourThemeObj = Context.TourTheme.Where(z => z.Id == obj.Id).FirstOrDefault();
                    TourThemeObj.Status = obj.Status;
                    TourThemeObj.Description = obj.Description;
                    TourThemeObj.ThemeName = obj.ThemeName;
                    TourThemeObj.RecUpd = "U";
                    TourThemeObj.Video = obj.Video;
                    TourThemeObj.UpdatedBy = obj.UpdatedBy;
                    TourThemeObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\TourTheme\image", TourThemeObj.FeaturedImage);
                        TourThemeObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.TourTheme.Where(z => z.ThemeName == obj.ThemeName).Any();


                    if (!Context.TourTheme.Where(z => z.ThemeName == obj.ThemeName && z.RecUpd != "D").Any())
                    {
                        var TourThemeDetail = new TourTheme
                        {
                            ThemeName = obj.ThemeName,
                            Description = obj.Description,
                            Status = obj.Status,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.TourTheme.Add(TourThemeDetail);
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


        public ResponseModel GetAllTheme()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TourTheme> resultValue = new List<TourTheme>();
                resultValue = Context.TourTheme.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Tour Theme";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteTourTheme(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TourTheme> lst = new List<TourTheme>();
                if (Id > 0)
                {
                    var TourThemeDetail = Context.TourTheme.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\TourTheme\image", TourThemeDetail.FeaturedImage);
                    TourThemeDetail.RecUpd = "D";

                    //Context.TourTheme.Remove(TourThemeDetail);
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

        public string fileUploadInTourTheme(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\TourTheme\image", imageFile);

            }

            return imageFile;
        }

        public ResponseModel GetThemeDetailByThemeId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var ThemeDetail = new TourTheme();
                if (Id > 0)
                {
                    ThemeDetail = Context.TourTheme.Where(z => z.Id == Id && z.RecUpd != "D").FirstOrDefault();
                }

                result.data = ThemeDetail;
                result.status = Status.Success;
                result.message = "Theme Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInTheme(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\TourTheme\Video", imageFile);

            }

            return imageFile;
        }
        public void deleteVideoInTheme(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\TourTheme\Video", oldVideoName);
                
            }
        }

    }
}
