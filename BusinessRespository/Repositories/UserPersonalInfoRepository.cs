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

    class UserPersonalInfoRepository: IUserPersonalInfoRepository
    {
        private TravelOliveContext Context;

        public UserPersonalInfoRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        //public ResponseModel AddUpdateUserPersonalInfo(vmUserPersonalInfo obj)
        //{
        //    ResponseModel result = new ResponseModel();
        //    try
        //    {
        //        var UserPersonalInfoObj = Context.UserPersonalInfo.Where(z => z.UserId == obj.UserId).FirstOrDefault();
        //        if (UserPersonalInfoObj != null)
        //        {

        //            UserPersonalInfoObj.UserId = obj.UserId;
        //            UserPersonalInfoObj.Name = obj.Name;
        //            UserPersonalInfoObj.Email = obj.Email;
        //            UserPersonalInfoObj.Mobile = obj.Mobile;
        //            UserPersonalInfoObj.Birthday = obj.Birthday;
        //            UserPersonalInfoObj.Occupation = obj.Occupation;
        //            UserPersonalInfoObj.Country = obj.Country;
        //            UserPersonalInfoObj.State = obj.State;
        //            UserPersonalInfoObj.City = obj.City;
        //            UserPersonalInfoObj.RecUpd = "U";
        //            UserPersonalInfoObj.UpdatedBy = obj.UpdatedBy;
        //            UserPersonalInfoObj.UpdatedDate = DateTime.Now;
        //            Context.SaveChanges();
        //            result.message = "Successfully Updated";
        //            result.status = Status.Success;

        //        }
        //        else
        //        {


        //            var UserPersonalInfoDetail = new UserPersonalInfo
        //            {

        //                UserId = obj.UserId,
        //                Name = obj.Name,
        //                Email = obj.Email,
        //                Mobile = obj.Mobile,
        //                Birthday = obj.Birthday,
        //                Occupation = obj.Occupation,
        //                Country = obj.Country,
        //                State = obj.State,
        //                City = obj.City,
        //                RecUpd = "C",
        //                CreatedBy = obj.CreatedBy,
        //                CreatedDate = DateTime.Now,
        //            };
        //            Context.UserPersonalInfo.Add(UserPersonalInfoDetail);
        //            Context.SaveChanges();
        //            result.message = "Successfully Saved";
        //            result.status = Status.Success;


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.status = Status.Error;
        //        result.error = ex.Message;
        //    }
        //    return result;
        //}

        public ResponseModel AddUpdateUserPersonalInfo(Registration obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UserPersonalInfoObj = Context.Registration.Where(z => z.Id == obj.Id && z.RoleId == 2 ).FirstOrDefault();
                if (UserPersonalInfoObj != null)
                {

                    UserPersonalInfoObj.FirstName = obj.FirstName;
                    UserPersonalInfoObj.LastName = obj.LastName;
                    UserPersonalInfoObj.EmailId = obj.EmailId;
                    UserPersonalInfoObj.MobileNo = obj.MobileNo;
                    UserPersonalInfoObj.Birthday = obj.Birthday;
                    UserPersonalInfoObj.Occupation = obj.Occupation;
                    UserPersonalInfoObj.Country = obj.Country;
                    UserPersonalInfoObj.State = obj.State;
                    UserPersonalInfoObj.City = obj.City;
                    UserPersonalInfoObj.RecUpd = "U";
                    UserPersonalInfoObj.UpdatedBy = obj.UpdatedBy;
                    UserPersonalInfoObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
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


        //public ResponseModel GetAllUserPersonalInfo()
        //{
        //    ResponseModel result = new ResponseModel();
        //    try
        //    {
        //        List<UserPersonalInfo> resultValue = new List<UserPersonalInfo>();
        //        resultValue = Context.UserPersonalInfo.Where(z => z.RecUpd != "D").ToList();

        //        result.data = resultValue;
        //        result.status = Status.Success;
        //        result.message = "List for UserPersonalInfo";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.status = Status.Error;
        //        result.error = ex.Message;

        //    }
        //    return result;
        //}

        public ResponseModel GetAllUserPersonalInfo()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Registration> resultValue = new List<Registration>();
                //  resultValue = Context.Registration.Where(z => z.RecUpd != "D" && z.RoleId == 2).ToList();
                //resultValue = Context.userNetworkConnection();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for UserPersonalInfo";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        //public ResponseModel deleteUserPersonalInfo(int? Id)
        //{
        //    ResponseModel result = new ResponseModel();
        //    try
        //    {
        //        List<UserPersonalInfo> lst = new List<UserPersonalInfo>();
        //        if (Id > 0)
        //        {
        //            var UserPersonalInfoDetail = Context.UserPersonalInfo.Where(z => z.Id == Id).FirstOrDefault();
        //            UserPersonalInfoDetail.RecUpd = "D";
        //            Context.SaveChanges();
        //        }

        //        result.data = lst;
        //        result.status = Status.Success;
        //        result.message = "delete successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.status = Status.Error;
        //        result.error = ex.Message;

        //    }
        //    return result;
        //}

        public ResponseModel deleteUserPersonalInfo(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Registration> lst = new List<Registration>();
                if (Id > 0)
                {
                    var UserPersonalInfoDetail = Context.Registration.Where(z => z.Id == Id).FirstOrDefault();
                    UserPersonalInfoDetail.RecUpd = "D";
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


        //public ResponseModel GetUserPersonalInfoByUserId(int? Id)
        //{
        //    ResponseModel result = new ResponseModel();
        //    try
        //    {
        //        var UserPersonalInfoDetail = new UserPersonalInfo();
        //        if (Id > 0)
        //        {
        //            UserPersonalInfoDetail = Context.UserPersonalInfo.Where(z => z.UserId == Id).FirstOrDefault();
        //        }

        //        result.data = UserPersonalInfoDetail;
        //        result.status = Status.Success;
        //        result.message = "User Personal Info Detail";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.status = Status.Error;
        //        result.error = ex.Message;

        //    }
        //    return result;
        //}


        public ResponseModel GetUserPersonalInfoByUserId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var UserPersonalInfoDetail = new vmUserPersonalSocialInfo();
                if (Id > 0)
                {
                    UserPersonalInfoDetail = Context.Registration.Where(z => z.Id == Id).Select(x => new vmUserPersonalSocialInfo {

                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        EmailId = x.EmailId,
                        MobileNo = x.MobileNo,
                        Category = x.Category,
                        TravelEnthuiast = x.TravelEnthuiast,
                        Gmcid = x.Gmcid,
                        CreatedDate = x.CreatedDate,
                        CreatedBy = x.CreatedBy,
                        UpdatedDate = x.UpdatedDate,
                        UpdatedBy = x.UpdatedBy,
                        RoleId = x.RoleId,
                        Birthday = x.Birthday,
                        Occupation = x.Occupation,
                        Country = x.Country,
                        State = x.State,
                        City = x.City,
                        AboutDescription = x.AboutDescription,
                        ProfileImg = x.ProfileImg,
                        CoverImage = x.CoverImage,
                        RecUpd = x.RecUpd,
                        FriendCount = Context.UserFriends.Where(z => z.UserId == Id).Count(),
                        PostCount = Context.UserPost.Where(z => z.UserId == Id).Count(),
                        VisitCount = x.ProfileVisit,



                    }).FirstOrDefault();
                }

                result.data = UserPersonalInfoDetail;
                result.status = Status.Success;
                result.message = "User Personal Info Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }



        //public ResponseModel AddUpdateUserProfileImage(vmUserProfileImage obj)
        //{
        //    ResponseModel result = new ResponseModel();
        //    try
        //    {
        //        string ProfileImg = string.Empty;
        //        if (obj.ProfileImg != null)
        //        {
        //            var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
        //            ProfileImg = obj.ProfileImg != null ? prefixpath + "_" + obj.ProfileImg.FileName : null;

        //            FileUploadcls uploadcls = new FileUploadcls();
        //            if (obj.ProfileImg != null) uploadcls.fileUpload(obj.ProfileImg, @"Uploads\SocialMedia\UserProfilePic\image", ProfileImg);

        //        }
        //        var UserProfileImgObj = Context.UserPersonalInfo.Where(z => z.UserId == obj.UserId).FirstOrDefault();

        //        if (UserProfileImgObj  != null)
        //        {

        //            UserProfileImgObj .UpdatedDate = DateTime.Now;
        //            if (obj.ProfileImg != null && UserProfileImgObj.ProfileImg != null)
        //            {
        //                FileUploadcls uploadcls = new FileUploadcls();
        //                uploadcls.fileDeleted(@"Uploads\SocialMedia\UserProfilePic\image", UserProfileImgObj .ProfileImg);

        //            }
        //            UserProfileImgObj.ProfileImg = ProfileImg;
        //            Context.SaveChanges();
        //            result.message = "Successfully Updated";
        //            result.status = Status.Success;

        //        }
        //        else
        //        {

        //                var UserPersonalInfoDetail = new UserPersonalInfo
        //                {
        //                    UserId = obj.UserId,
        //                    RecUpd = "C",
        //                    CreatedDate = DateTime.Now,
        //                    ProfileImg = ProfileImg
        //                };
        //                Context.UserPersonalInfo.Add(UserPersonalInfoDetail);
        //                Context.SaveChanges();
        //                result.message = "Successfully Saved";
        //                result.status = Status.Success;


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.status = Status.Error;
        //        result.message = ex.Message;
        //        result.error = ex.Message;
        //    }
        //    return result;
        //}

        public ResponseModel AddUpdateUserProfileImage(vmUserProfileImage obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string ProfileImg = string.Empty;
                if (obj.ProfileImg != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    ProfileImg = obj.ProfileImg != null ? prefixpath + "_" + obj.ProfileImg.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.ProfileImg != null) uploadcls.fileUpload(obj.ProfileImg, @"Uploads\SocialMedia\UserProfilePic\image", ProfileImg);

                }
                var UserProfileImgObj = Context.Registration.Where(z => z.Id  == obj.UserId).FirstOrDefault();

                if (UserProfileImgObj != null)
                {

                    UserProfileImgObj.UpdatedDate = DateTime.Now;
                    if (obj.ProfileImg != null && UserProfileImgObj.ProfileImg != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\SocialMedia\UserProfilePic\image", UserProfileImgObj.ProfileImg);

                    }
                    UserProfileImgObj.ProfileImg = ProfileImg;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
            

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.message = ex.Message;
                result.error = ex.Message;
            }
            return result;
        }

        public ResponseModel AddUpdateUserAboutDescription(vmUserAboutDescription obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
               
                var UserAboutDescriptionObj = Context.Registration.Where(z => z.Id == obj.UserId).FirstOrDefault();

                if (UserAboutDescriptionObj  != null)
                {

                    UserAboutDescriptionObj.AboutDescription = obj.AboutDescription;
                    UserAboutDescriptionObj.RecUpd = "U";
                    UserAboutDescriptionObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
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


        public ResponseModel AddUpdateUserCoverImage(vmUserCoverImg obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string CoverImage = string.Empty;
                if (obj.CoverImage != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    CoverImage = obj.CoverImage != null ? prefixpath + "_" + obj.CoverImage.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.CoverImage != null) uploadcls.fileUpload(obj.CoverImage, @"Uploads\SocialMedia\UserCoverImage\image", CoverImage);

                }
                var UserCoverImageObj = Context.Registration.Where(z => z.Id == obj.UserId).FirstOrDefault();

                if (UserCoverImageObj != null)
                {

                    UserCoverImageObj.UpdatedDate = DateTime.Now;
                    if (obj.CoverImage != null && UserCoverImageObj.CoverImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\SocialMedia\UserCoverImage\image", UserCoverImageObj.CoverImage);
                       
                    }
                    UserCoverImageObj.CoverImage = CoverImage;
                    UserCoverImageObj.RecUpd = "U";
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
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

        public ResponseModel increamentInVisitCount(int? profleUserId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (profleUserId > 0)
                {
                    var UserPersonalInfoDetail = Context.Registration.Where(z => z.Id == profleUserId).FirstOrDefault();
                    UserPersonalInfoDetail.ProfileVisit = UserPersonalInfoDetail.ProfileVisit + 1;
                    Context.SaveChanges();
                }

                result.status = Status.Success;
                result.message = "Increament in User Profile Visit Count Successfully";
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
