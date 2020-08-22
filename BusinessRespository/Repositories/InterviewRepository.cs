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
    class InterviewRepository: IInterviewRepository
    {
        private TravelOliveContext Context;

        public InterviewRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateInterview(VmInterview obj)
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
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\Home\Interview\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var InterviewObj = Context.Interview.Where(z => z.Id == obj.Id).FirstOrDefault();
                    InterviewObj.Name = obj.Name;
                    InterviewObj.Designation = obj.Designation;
                    InterviewObj.ShortDescription = obj.ShortDescription;
                    InterviewObj.Description = obj.Description;
                    InterviewObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    InterviewObj.RecUpd = "U";
                    InterviewObj.Video = obj.Video;
                    InterviewObj.UpdatedBy = obj.UpdatedBy;
                    InterviewObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Home\Interview\image", InterviewObj.FeaturedImage);
                        InterviewObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.Interview.Where(z => z.InterviewName == obj.InterviewName).Any();


                    if (!Context.Interview.Where(z => z.Name == obj.Name && z.RecUpd != "D").Any())
                    {
                        var InterviewDetail = new Interview
                        {
                            Name = obj.Name,
                            Designation = obj.Designation,
                            ShortDescription = obj.ShortDescription,
                            Description = obj.Description,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            Video = obj.Video,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.Interview.Add(InterviewDetail);
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


        public ResponseModel GetAllInterview()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Interview> resultValue = new List<Interview>();
                resultValue = Context.Interview.Where(z => z.RecUpd != "D").OrderByDescending(x => x.CreatedDate).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Interview";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteInterview(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Interview> lst = new List<Interview>();
                if (Id > 0)
                {
                    var InterviewDetail = Context.Interview.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\Home\Interview\image", InterviewDetail.FeaturedImage);
                    InterviewDetail.RecUpd = "D";
                    //Context.Interview.Remove(InterviewDetail);
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

        public string fileUploadInInterview(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\Interview\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetInterviewDetailByInterviewId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var InterviewDetail = new Interview();
                if (Id > 0)
                {
                    InterviewDetail = Context.Interview.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = InterviewDetail;
                result.status = Status.Success;
                result.message = "Interview Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInInterview(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                imageFile = obj.fileInfo != null ? prefixpath + "_" + obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\Home\Interview\Video", imageFile);

            }

            return imageFile;
        }

        public void deleteVideoInInterview(string oldVideoName)
        {

            if (oldVideoName != string.Empty)
            {

                FileUploadcls uploadcls = new FileUploadcls();
                uploadcls.fileDeleted(@"Uploads\Home\Interview\Video", oldVideoName);

            }
        }
    }
}
