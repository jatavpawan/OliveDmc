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
    class AboutUsStatementRepository : IAboutUsStatementRepository
    {
        private TravelOliveContext Context;

        public AboutUsStatementRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateAboutUsStatement(vmAboutUsStatement obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string FeaturedImage = string.Empty;
                if (obj.FeaturedImage != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    FeaturedImage = obj.FeaturedImage != null ? prefixpath + "_" + obj.FeaturedImage.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\AboutUsStatement\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var AboutUsStatementObj = Context.AboutUsStatement.Where(z => z.Id == obj.Id).FirstOrDefault();
                    AboutUsStatementObj.Title = obj.Title;
                    AboutUsStatementObj.Description = obj.Description;
                    AboutUsStatementObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    AboutUsStatementObj.RecUpd = "U";
                    AboutUsStatementObj.UpdatedBy = obj.UpdatedBy;
                    AboutUsStatementObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\AboutUsStatement\image", AboutUsStatementObj.FeaturedImage);
                        AboutUsStatementObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.AboutUsStatement.Where(z => z.AboutUsStatementName == obj.AboutUsStatementName).Any();


                    if (!Context.AboutUsStatement.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var AboutUsStatementDetail = new AboutUsStatement
                        {
                            Title = obj.Title,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.AboutUsStatement.Add(AboutUsStatementDetail);
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


        public ResponseModel GetAllAboutUsStatement()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AboutUsStatement> resultValue = new List<AboutUsStatement>();
                resultValue = Context.AboutUsStatement.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for AboutUsStatement";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteAboutUsStatement(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AboutUsStatement> lst = new List<AboutUsStatement>();
                if (Id > 0)
                {
                    var AboutUsStatementDetail = Context.AboutUsStatement.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\AboutUsStatement\image", AboutUsStatementDetail.FeaturedImage);
                    AboutUsStatementDetail.RecUpd = "D";
                    //Context.AboutUsStatement.Remove(AboutUsStatementDetail);
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

        public string fileUploadInAboutUsStatement(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\AboutUsStatement\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetAboutUsStatementDetailByAboutUsStatementId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var AboutUsStatementDetail = new AboutUsStatement();
                if (Id > 0)
                {
                    AboutUsStatementDetail = Context.AboutUsStatement.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = AboutUsStatementDetail;
                result.status = Status.Success;
                result.message = "AboutUsStatement Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInAboutUsStatement(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\AboutUsStatement\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInAboutUsStatement(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\AboutUsStatement\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllAboutUsStatementinFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AboutUsStatement> resultValue = new List<AboutUsStatement>();
                resultValue = Context.AboutUsStatement.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for AboutUsStatement";
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
