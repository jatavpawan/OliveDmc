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
    class DestinationVideosRepository: IDestinationVideosRepository
    {
        private TravelOliveContext Context;

        public DestinationVideosRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateDestinationVideos(VmDestinationVideos obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Home\DestinationVideos\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var DestinationVideosObj = Context.DestinationVideos.Where(z => z.Id == obj.Id).FirstOrDefault();
                    DestinationVideosObj.Title = obj.Title;
                    DestinationVideosObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    DestinationVideosObj.RecUpd = "U";
                    DestinationVideosObj.Video = obj.Video;
                    DestinationVideosObj.UpdatedBy = obj.UpdatedBy;
                    DestinationVideosObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Home\DestinationVideos\image", DestinationVideosObj.FeaturedImage);
                        DestinationVideosObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.DestinationVideos.Where(z => z.DestinationVideosName == obj.DestinationVideosName).Any();


                    if (!Context.DestinationVideos.Where(z => z.Title == obj.Title && z.RecUpd != "D" ).Any())
                    {
                        var DestinationVideosDetail = new DestinationVideos
                        {
                            Title = obj.Title,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.DestinationVideos.Add(DestinationVideosDetail);
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


        public ResponseModel GetAllDestinationVideos()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<DestinationVideos> resultValue = new List<DestinationVideos>();
                resultValue = Context.DestinationVideos.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for DestinationVideos";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteDestinationVideos(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<DestinationVideos> lst = new List<DestinationVideos>();
                if (Id > 0)
                {
                    var DestinationVideosDetail = Context.DestinationVideos.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Home\DestinationVideos\image", DestinationVideosDetail.FeaturedImage);
                    DestinationVideosDetail.RecUpd = "D";
                    //Context.DestinationVideos.Remove(DestinationVideosDetail);
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


        public ResponseModel GetDestinationVideosDetailByDestinationVideosId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var DestinationVideosDetail = new DestinationVideos();
                if (Id > 0)
                {
                    DestinationVideosDetail = Context.DestinationVideos.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = DestinationVideosDetail;
                result.status = Status.Success;
                result.message = "DestinationVideos Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInDestinationVideos(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\DestinationVideos\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInDestinationVideos(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Home\DestinationVideos\Video", oldVideoName);

            }
        }
    }
}
