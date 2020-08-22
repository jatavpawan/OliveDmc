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
    class NewDestinationsInWhatsNewRepository : INewDestinationsInWhatsNewRepository
    {
        private TravelOliveContext Context;

        public NewDestinationsInWhatsNewRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateNewDestinationsInWhatsNew(vmNewDestinationsInWhatsNew obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\NewDestinationsInWhatsNew\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var NewDestinationsInWhatsNewObj = Context.NewDestinationsInWhatsNew.Where(z => z.Id == obj.Id).FirstOrDefault();
                    NewDestinationsInWhatsNewObj.Title = obj.Title;
                    NewDestinationsInWhatsNewObj.Location = obj.Location;
                    NewDestinationsInWhatsNewObj.ShortDescription = obj.ShortDescription;
                    NewDestinationsInWhatsNewObj.Description = obj.Description;
                    NewDestinationsInWhatsNewObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    NewDestinationsInWhatsNewObj.RecUpd = "U";
                    NewDestinationsInWhatsNewObj.Video = obj.Video;
                    NewDestinationsInWhatsNewObj.UpdatedBy = obj.UpdatedBy;
                    NewDestinationsInWhatsNewObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\NewDestinationsInWhatsNew\image", NewDestinationsInWhatsNewObj.FeaturedImage);
                        NewDestinationsInWhatsNewObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.NewDestinationsInWhatsNew.Where(z => z.NewDestinationsInWhatsNewName == obj.NewDestinationsInWhatsNewName).Any();


                    if (!Context.NewDestinationsInWhatsNew.Where(z => z.Title == obj.Title && z.RecUpd != "D").Any())
                    {
                        var NewDestinationsInWhatsNewDetail = new NewDestinationsInWhatsNew
                        {
                            Title = obj.Title,
                            Location = obj.Location,
                            ShortDescription = obj.ShortDescription,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.NewDestinationsInWhatsNew.Add(NewDestinationsInWhatsNewDetail);
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


        public ResponseModel GetAllNewDestinationsInWhatsNew()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<NewDestinationsInWhatsNew> resultValue = new List<NewDestinationsInWhatsNew>();
                resultValue = Context.NewDestinationsInWhatsNew.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for NewDestinationsInWhatsNew";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteNewDestinationsInWhatsNew(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<NewDestinationsInWhatsNew> lst = new List<NewDestinationsInWhatsNew>();
                if (Id > 0)
                {
                    var NewDestinationsInWhatsNewDetail = Context.NewDestinationsInWhatsNew.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\NewDestinationsInWhatsNew\image", NewDestinationsInWhatsNewDetail.FeaturedImage);
                    NewDestinationsInWhatsNewDetail.RecUpd = "D";
                    //Context.NewDestinationsInWhatsNew.Remove(NewDestinationsInWhatsNewDetail);
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

        public string fileUploadInNewDestinationsInWhatsNew(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\NewDestinationsInWhatsNew\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetNewDestinationsInWhatsNewDetailByDestinationsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var NewDestinationsInWhatsNewDetail = new NewDestinationsInWhatsNew();
                if (Id > 0)
                {
                    NewDestinationsInWhatsNewDetail = Context.NewDestinationsInWhatsNew.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = NewDestinationsInWhatsNewDetail;
                result.status = Status.Success;
                result.message = "NewDestinationsInWhatsNew Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInNewDestinationsInWhatsNew(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\NewDestinationsInWhatsNew\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInNewDestinationsInWhatsNew(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\NewDestinationsInWhatsNew\Video", oldVideoName);

            }
        }

        public ResponseModel GetAllNewDestinationsInWhatsNewFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<NewDestinationsInWhatsNew> resultValue = new List<NewDestinationsInWhatsNew>();
                resultValue = Context.NewDestinationsInWhatsNew.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for NewDestinationsInWhatsNew";
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
