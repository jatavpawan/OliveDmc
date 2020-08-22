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
    class AboutUsIntroductionRepository : IAboutUsIntroductionRepository
    {
        private TravelOliveContext Context;

        public AboutUsIntroductionRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateAboutUsIntroductionDetail(vmAboutUsIntroduction obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                string FeaturedImageFirst = string.Empty;
                string FeaturedImageSecond = string.Empty;
                if (obj.FeaturedImageFirst != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    FeaturedImageFirst = obj.FeaturedImageFirst != null ? prefixpath + "_" + obj.FeaturedImageFirst.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.FeaturedImageFirst != null) uploadcls.fileUpload(obj.FeaturedImageFirst, @"Uploads\AboutUsIntroduction\image", FeaturedImageFirst);
                }

                if (obj.FeaturedImageSecond != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    FeaturedImageSecond = obj.FeaturedImageSecond != null ? prefixpath + "_" + obj.FeaturedImageSecond.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.FeaturedImageSecond != null) uploadcls.fileUpload(obj.FeaturedImageSecond, @"Uploads\AboutUsIntroduction\image", FeaturedImageSecond);

                }


                if (obj.Id > 0)
                {
                    var AboutUsIntroductionObj = Context.AboutUsIntroduction.Where(z => z.Id == obj.Id).FirstOrDefault();
                    AboutUsIntroductionObj.Title = obj.Title;
                    AboutUsIntroductionObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    AboutUsIntroductionObj.Description = obj.Description;
                    AboutUsIntroductionObj.RecUpd = "U";
                    AboutUsIntroductionObj.UpdatedBy = obj.UpdatedBy;
                    AboutUsIntroductionObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImageFirst != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\AboutUsIntroduction\image", AboutUsIntroductionObj.FeaturedImageFirst);
                        AboutUsIntroductionObj.FeaturedImageFirst = FeaturedImageFirst;
                    }
                    if (obj.FeaturedImageSecond != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\AboutUsIntroduction\image", AboutUsIntroductionObj.FeaturedImageSecond);
                        AboutUsIntroductionObj.FeaturedImageSecond = FeaturedImageSecond;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;
                }
                else
                {
                    var AboutUsIntroductionObj = Context.AboutUsIntroduction.FirstOrDefault();

                    if (AboutUsIntroductionObj == null)
                    {
                        AboutUsIntroduction aboutObj = new AboutUsIntroduction();
                        aboutObj.Title = obj.Title;
                        aboutObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                        aboutObj.Description = obj.Description;
                        aboutObj.FeaturedImageFirst = FeaturedImageFirst;
                        aboutObj.FeaturedImageSecond = FeaturedImageSecond;
                        aboutObj.CreatedDate = DateTime.Now;
                        aboutObj.CreatedBy = obj.CreatedBy;
                        aboutObj.RecUpd = "C";
                        Context.AboutUsIntroduction.Add(aboutObj);
                        result.message = "Successfully Saved";

                    }
                    else
                    {
                        AboutUsIntroductionObj.Title = obj.Title;
                        AboutUsIntroductionObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                        AboutUsIntroductionObj.Description = obj.Description;
                        AboutUsIntroductionObj.FeaturedImageFirst = FeaturedImageFirst;
                        AboutUsIntroductionObj.FeaturedImageSecond = FeaturedImageSecond;
                        AboutUsIntroductionObj.RecUpd = "U";
                        AboutUsIntroductionObj.UpdatedBy = obj.UpdatedBy;
                        AboutUsIntroductionObj.UpdatedDate = DateTime.Now;
                        
                        result.message = "Successfully Updated";
                    }

                    Context.SaveChanges();
                    result.status = Status.Success;

                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public List<AboutUsIntroduction> GetAboutUsIntroductionDetail()
        {
            List<AboutUsIntroduction> AboutUsIntroductionObj;
            AboutUsIntroductionObj = Context.AboutUsIntroduction.Where(z => z.RecUpd != "D").Select(x => new AboutUsIntroduction
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                FeaturedImageFirst = x.FeaturedImageFirst,
                FeaturedImageSecond = x.FeaturedImageSecond,
                ShowInFrontEnd = x.ShowInFrontEnd,

            }).ToList();

            return AboutUsIntroductionObj;
        }


        public ResponseModel deleteAboutUsIntroductionInfo(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AboutUsIntroduction> lst = new List<AboutUsIntroduction>();
                if (Id > 0)
                {
                    var AboutUsIntroductionDetail = Context.AboutUsIntroduction.Where(z => z.Id == Id).FirstOrDefault();
                    AboutUsIntroductionDetail.RecUpd = "D";
                    //Context.AboutUsIntroduction.Remove(AboutUsIntroductionDetail);
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

        public string fileUploadInAboutUsIntroduction(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;
                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\AboutUsIntroduction\image", imageFile);
            }
            return imageFile;
        }

    }


}

