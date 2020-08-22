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
    class BannerRepository : IBannerRepository
    {
        
            private TravelOliveContext Context;

            public BannerRepository(TravelOliveContext _context)
            {
                Context = _context;
            }

        public ResponseModel AddUpdateBanner(vmBanner obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string ImagePath = string.Empty;
                if (obj.ImagePath != null || obj.ImagePath != null || obj.ImagePath != null || obj.ImagePath != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    ImagePath = obj.ImagePath != null ? prefixpath + "_" + obj.ImagePath.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.ImagePath != null) uploadcls.fileUpload(obj.ImagePath, @"Uploads\Banner\image", ImagePath);

                }

                if (obj.Id > 0)
                {      
                    var BannerObj = Context.Banner.Where(z => z.Id == obj.Id).FirstOrDefault();
                    BannerObj.Title = obj.Title;
                    BannerObj.PageId = obj.PageId;
                    BannerObj.Status = obj.Status;
                    BannerObj.RecUpd = "U";

                    BannerObj.UpdatedBy = obj.UpdatedBy;
                    BannerObj.UpdatedDate = DateTime.Now;
                    if (obj.ImagePath != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Banner\image", BannerObj.ImagePath);
                        BannerObj.ImagePath = ImagePath;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.Banner.Where(z => z.BannerName == obj.BannerName).Any();


                    if (!Context.Banner.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var BannerDetail = new Banner
                        {
                            Title = obj.Title,
                            Status = obj.Status,
                            PageId = obj.PageId,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ImagePath = ImagePath
                        };
                        Context.Banner.Add(BannerDetail);
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


        public ResponseModel GetAllBanner()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Banner> resultValue = new List<Banner>();
                resultValue = Context.Banner.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Banner";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteBanner(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Banner> lst = new List<Banner>();
                if (Id > 0)
                {
                    var BannerDetail = Context.Banner.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Banner\image", BannerDetail.ImagePath);

                    BannerDetail.RecUpd = "D";
                    //Context.Banner.Remove(BannerDetail);
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

        public string fileUploadInBanner(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Banner\image", imageFile);

            }

            return imageFile;
        }

       
       
        public ResponseModel GetBannerDetailByPageId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var BannerDetail = new Banner();
                if (Id > 0)
                {
                    BannerDetail = Context.Banner.Where(z => z.PageId == Id).FirstOrDefault();
                }

                result.data = BannerDetail;
                result.status = Status.Success;
                result.message = "Banner Detail";
            }
            catch (Exception ex)
            { 
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public ResponseModel GetAllPage()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Page> resultValue = new List<Page>();
                resultValue = Context.Page.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Page";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }
        public ResponseModel GetBannerDetailByBannerId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var BannerDetail = new Banner();
                if (Id > 0)
                {
                    BannerDetail = Context.Banner.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = BannerDetail;
                result.status = Status.Success;
                result.message = "Banner Detail";
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
