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

    class UserCoverImageRepository : IUserCoverImageRepository
    {
        private TravelOliveContext Context;

        public UserCoverImageRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateUserCoverImage(vmUserCoverImage obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string Image = string.Empty;
                if (obj.Image != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    Image = obj.Image != null ? prefixpath + "_" + obj.Image.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.Image != null) uploadcls.fileUpload(obj.Image, @"Uploads\SocialMedia\UserCoverImage\image", Image);

                }

                if (obj.Id > 0)
                {
                    var UserCoverImageObj = Context.UserCoverImage.Where(z => z.Id == obj.Id).FirstOrDefault();
                    UserCoverImageObj.UserId = obj.UserId;
                    UserCoverImageObj.RecUpd = "U";
                    UserCoverImageObj.UpdatedBy = obj.UpdatedBy;
                    UserCoverImageObj.UpdatedDate = DateTime.Now;
                    if (obj.Image != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\SocialMedia\UserCoverImage\image", UserCoverImageObj.Image);
                        UserCoverImageObj.Image = Image;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.UserCoverImage.Where(z => z.UserCoverImageName == obj.UserCoverImageName).Any();


                       var UserCoverImageDetail = new UserCoverImage
                        {
                            UserId = obj.UserId,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            Image = Image
                        };
                        Context.UserCoverImage.Add(UserCoverImageDetail);
                        Context.SaveChanges();
                        result.message = "Successfully Saved";
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

        public ResponseModel GetAllUserCoverImage()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserCoverImage> resultValue = new List<UserCoverImage>();
                resultValue = Context.UserCoverImage.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for UserCoverImage";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteUserCoverImage(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<UserCoverImage> lst = new List<UserCoverImage>();
                if (Id > 0)
                {
                    var UserCoverImageDetail = Context.UserCoverImage.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\SocialMedia\UserCoverImage\image", UserCoverImageDetail.Image);
                    UserCoverImageDetail.RecUpd = "D";
                    //Context.UserCoverImage.Remove(UserCoverImageDetail);
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

        public ResponseModel GetUserCoverImageByUserId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UserCoverImageDetail = new UserCoverImage();
                if (Id > 0)
                {
                    UserCoverImageDetail = Context.UserCoverImage.Where(z => z.UserId == Id).FirstOrDefault();
                }

                result.data = UserCoverImageDetail;
                result.status = Status.Success;
                result.message = "UserCoverImage Detail";
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
