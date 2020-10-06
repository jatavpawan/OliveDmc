using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRespository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private TravelOliveContext Context;
        public LoginRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        //public List<Registration_result> RegisterUser(vmRegistration obj, out string resultValue)
        //{
        //    resultValue = "";
        //    //  return Context.userRegistrtion(obj, out resultValue);
        //    var d = new List<Registration_result>();
        //    return d;

        //}


        public ResponseModel RegisterUser(vmRegistration obj)
        {
            ResponseModel response;

            var checkEmail = Context.Registration.Where(z => z.EmailId == obj.EmailId).FirstOrDefault();
            if (checkEmail != null)
            {
                response = new ResponseModel
                {
                    status = Status.Warning,
                    message = "Email Address already exists."
                };
                return response;
            }
            var checkMobile = Context.Registration.Where(z => z.MobileNo == obj.MobileNo).FirstOrDefault();
            if (checkMobile != null)
            {
                response = new ResponseModel
                {
                    status = Status.Warning,
                    message = "Mobile Number already exists."
                };
                return response;
            }



            Registration reg = new Registration();
            reg.FirstName = obj.FirstName; 
            reg.LastName = obj.LastName; 
            reg.EmailId = obj.EmailId; 
            reg.MobileNo= obj.MobileNo; 
            reg.Category= obj.Category;
            reg.RoleId = 2;
            reg.TravelEnthuiast = obj.TravelEnthuiast;
            reg.CreatedDate = DateTime.Now;
            reg.CreatedBy = 1;
            reg.UpdatedDate = DateTime.Now;
            reg.UpdatedBy = 1;
            reg.Otp = AuthUtilities.GenerateOTPNo();
            Context.Registration.Add(reg);
            Context.SaveChanges();

            //----------------after Registeration save
            UserRegLogin usrLogin = new UserRegLogin();
            var registredUser = Context.Registration.Where(z => z.EmailId == obj.EmailId).FirstOrDefault();
            usrLogin.RegistrationId = registredUser.Id;
            usrLogin.Username = obj.EmailId;
            usrLogin.Password = obj.Password;
            usrLogin.RoleId = 2;
            usrLogin.CreatedDate = DateTime.Now;
            usrLogin.CreatedBy = 1;
            usrLogin.UpdatedDate = DateTime.Now;
            usrLogin.UpdatedBy = 1;
            Context.UserRegLogin.Add(usrLogin);
            Context.SaveChanges();


            response = new ResponseModel
            {
                data = registredUser,
                status = Status.Success,
                message = " User Registered  successfully"
            };

            return response;


        }
        public ResponseModel LoginUser(vmLoginUser obj)
        {
            ResponseModel response = new ResponseModel();
            Registration userRegInfo = null;
            //vmUserInfo userInfo = null;

            if (!string.IsNullOrEmpty(obj.Email))
            {
                UserRegLogin userLoginInfo = null;
                userLoginInfo = Context.UserRegLogin.Where(z => (z.Username == obj.Email) && (z.Password == obj.Password) ).FirstOrDefault();
                
                if(userLoginInfo != null)
                {
                    userRegInfo = Context.Registration.Where(z => z.Id == userLoginInfo.RegistrationId).Select(x => new Registration
                    {

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

                    }).FirstOrDefault();

                    if(userLoginInfo.IsOtpVerify == true)
                    {
                        response.data = userRegInfo;
                        response.status = Status.Success;
                    }
                    else
                    {
                        response.data = userRegInfo;
                        response.status = Status.Warning;
                        response.message = "please verify your email by Otp";
                    }

                  
                }
              

            }
            else
            {
                response.data = null;
                response.status = Status.Error;
                response.message = "You are not registered Please Sign Up";
            }
         

          

            return response;


        }

        public ResponseModel UserOtpVerify(vmOtpVerify obj)
        {
            ResponseModel response;

            var registration = Context.Registration.Where(z => z.Otp == obj.Otp && z.EmailId == obj.Email).FirstOrDefault();
            if (registration != null)
            {
                var userlogin = Context.UserRegLogin.Where(z => z.Username == registration.EmailId).FirstOrDefault();
                userlogin.IsOtpVerify = true;
                Context.SaveChanges();

                response = new ResponseModel
                {
                    status = Status.Success,
                    message = "Otp is matched"
                };
                return response;
            }
         
            response = new ResponseModel
            {
                status = Status.Warning,
                message = "Otp not matched.please Try Again"
            };

            return response;


        }

        public ResponseModel UserEmailOTPVerificationBySendMail(int? userId)
        {
              ResponseModel result = new ResponseModel();
                try
                {
                    sendemailRepository sendmail = new sendemailRepository();
                    var userInfo = Context.Registration.Where(z => z.Id == userId).FirstOrDefault();
                    bool status = sendmail.contentBody(userInfo, "EmailOTPVerification");

                    if (status == true)
                    {
                        result.data = status;
                        result.status = Status.Success;
                        result.message = "Email Send Successfully";
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    result.status = Status.Error;
                    result.error = ex.Message;

                }
                return result;
          

        }

        public ResponseModel UserResendOtp(vmResendOtp obj)
        {
            ResponseModel response = new ResponseModel(); ;
            Registration result = null;

            result = Context.Registration.Where(z => z.EmailId == obj.Email).FirstOrDefault();
            if (result != null)
            {
                result.Otp = "" + AuthUtilities.GenerateOTPNo();
                Context.SaveChanges();


                sendemailRepository sendmail = new sendemailRepository();
                bool status = sendmail.contentBody(result, "EmailOTPVerification");

                if (status == true)
                {
                    response.data = status;
                    response.status = Status.Success;
                    response.message = "Otp resend successfully";
                }
               
                return response;
            }
            else
            {
                response.data = result;
                response.status = Status.Warning;
                response.message = "Mobile No not matched.please Try Again";
            }
         
          
            return response;


        }


        public ResponseModel UserForgotPassword(vmForgotPassword obj)
        {
            ResponseModel response;
         
            var checkEmail = Context.UserRegLogin.Where(z => z.Username == obj.Email).FirstOrDefault();
            if (checkEmail != null)
            {
                response = new ResponseModel
                {
                    status = Status.Success,
                    message = "Send Change Password Link in Your Registered Email Id"
                };
                return response;
            }

            response = new ResponseModel
            {
                status = Status.Warning,
                message = "Email Id Does not Exist Please Try Again"
            };

            return response;


        }


        public ResponseModel UserChangePassword(vmChangePassword obj)
        {
            ResponseModel response;
            UserRegLogin user = null;
            
            user = Context.UserRegLogin.Where(z => z.Username == obj.Email).FirstOrDefault();
            if (user != null)
            {
                user.Password = obj.Password;
                Context.UserRegLogin.Update(user);
                Context.SaveChanges();

                response = new ResponseModel
                {
                    status = Status.Success,
                    message = "Password Changed Successfully"
                };
                return response;
            }

            response = new ResponseModel
            {
                status = Status.Warning,
                message = "Email Id Does not Exist Please Try Again"
            };

            return response;


        }


        public List<getAllUser> GetAllUserDetails()
        {
            List<getAllUser> users;
            users = Context.Registration.Select(x => new getAllUser
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName  = x.LastName,
                EmailId = x.EmailId,
                MobileNo = x.MobileNo,
                Category =x.Category,
                TravelEnthuiast = x.TravelEnthuiast

            }).ToList();
            
            return users;
        }
        
        public ResponseModel UpdateRegisterUser(vmUserRegistration obj)
        {
            ResponseModel response;

            string ProfileImage = string.Empty;
            if (obj.ProfileImage != null)
            {
                var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                ProfileImage = obj.ProfileImage != null ? prefixpath + "_" + obj.ProfileImage.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.ProfileImage != null) uploadcls.fileUpload(obj.ProfileImage, @"Uploads\User\image", ProfileImage);

            }

            Registration reg = new Registration();
            reg = Context.Registration.Where(z => z.Id == obj.Id).FirstOrDefault();
            reg.FirstName = obj.FirstName;
            reg.LastName = obj.LastName;
            reg.EmailId = obj.EmailId;
            reg.MobileNo = obj.MobileNo;
            reg.Category = obj.Category;
            reg.TravelEnthuiast = obj.TravelEnthuiast;
            reg.UpdatedDate = DateTime.Now;
            reg.UpdatedBy = 1;
            if (obj.ProfileImage != null)
            {
                if(reg.ProfileImg != null)
                {
                    FileUploadcls uploadcls = new FileUploadcls();
                    uploadcls.fileDeleted(@"Uploads\User\image", reg.ProfileImg);
                }
                reg.ProfileImg = ProfileImage;
            }
            Context.SaveChanges();
            reg = Context.Registration.Where(z => z.Id == obj.Id).FirstOrDefault();


            response = new ResponseModel
            {
                data = reg,
                status = Status.Success,
                message = " User Profile Updated Successfully"
            };

            return response;


        }



        public ResponseModel ChangePassword(vmUserChangePassword obj)
        {
            ResponseModel response;

            UserRegLogin userLogin = new UserRegLogin();
            userLogin = Context.UserRegLogin.Where(z => z.RegistrationId == obj.RegistrationId).FirstOrDefault();


            if(userLogin.Password == obj.OldPassword)
            {
                userLogin.Password = obj.NewPassword;    
            }
            else
            {
                response = new ResponseModel
                {
                    status = Status.Warning,
                    message = "Old Password is not match"
                };
                return response;
            }

            userLogin.UpdatedDate = DateTime.Now;
            userLogin.UpdatedBy = 1;
            Context.SaveChanges();
            
            response = new ResponseModel
            {
                status = Status.Success,
                message = " Your password Change successfully"
            };

            return response;

        }


        public ResponseModel sendForgotPasswordMail(string email)
        {
            ResponseModel response = new ResponseModel(); ;
            Registration result = null;

            result = Context.Registration.Where(z => z.EmailId == email).FirstOrDefault();
            if (result != null)
            {


                sendemailRepository sendmail = new sendemailRepository();
                bool status = sendmail.contentBody(result, "SendMailForgotPassword");

                if (status == true)
                {
                    response.data = status;
                    response.status = Status.Success;
                    response.message = "Reset Password Link Send in Your Registered Mail ";
                }

                return response;
            }
            else
            {
                response.data = result;
                response.status = Status.Warning;
                response.message = "Your Email Not Exist In Record";
            }


            return response;


        }

  




        //public void SaveAboutUsDetail( vmAboutUsDetail obj)
        //{
        //    AboutUs aboutusObj = new AboutUs();
        //    aboutusObj.Description = obj.Description;
        //    aboutusObj.Status = obj.Status;
        //    aboutusObj.CreatedDate = DateTime.Now;
        //    aboutusObj.CreatedBy = 1;
        //    aboutusObj.UpdatedDate = DateTime.Now;
        //    aboutusObj.UpdatedBy = 1;
        //    Context.AboutUs.Add(aboutusObj);
        //    Context.SaveChanges();
        //}

        //public List<vmGetAboutUsDetail> GetAboutUsDetail()
        //{
        //    List<vmGetAboutUsDetail> aboutUsObj;
        //    aboutUsObj = Context.AboutUs.Select(x => new vmGetAboutUsDetail
        //    {
        //        Id = x.Id,
        //        Description = x.Description,
        //        Status = x.Status,

        //    }).ToList();

        //    return aboutUsObj;
        //}

        //public Registration GetLoginUser(int userID)
        //{
        //    if (userID > 0)
        //    {
        //        Registration resultValue = new Registration(); //Context.Registration.Where(z => z.RegistrationId == userID).FirstOrDefault();
        //        return resultValue;
        //    }
        //    return null;
        //}
        //public List<Registration> GetVendorUsers(int? userID)
        //{
        //    if (userID > 0)
        //    {
        //        var resultValue = new List<Registration>(); //Context.Registration.Where(z => z.RegistrationId == userID && z.RoleId == 2).ToList();
        //        return resultValue;
        //    }
        //    else
        //    {
        //        var resultValue =   new List<Registration>(); //Context.Registration.Where(z => z.RoleId == 2).ToList();
        //        return resultValue;
        //    }

        //}


        //public ResponseModel RegisterUser(vmRegistration obj) {
        //    ResponseModel response = new ResponseModel();
        //    if (obj != null) {
        //        //using (TransactionScope trans = new TransactionScope())
        //        //{
        //        try {
        //            Registration reg = null;

        //            if (obj.RegistrationId > 0) {
        //                var Registrationentity = Context.Registration.Where(z => z.RegistrationId == obj.RegistrationId).FirstOrDefault();
        //                Registrationentity.CanUpload = obj.CanUpload;
        //                Registrationentity.CreatedDate = DateTime.Now;
        //                Registrationentity.Email = obj.Email;
        //                Registrationentity.Name = obj.Name;
        //                Registrationentity.Gcmid = obj.Gcmid;
        //                Registrationentity.MobileNo = obj.MobileNo;
        //                Registrationentity.Password = obj.Password;
        //            }
        //            else {
        //                if (obj.Email != string.Empty) {
        //                    if (sendemailRepository.IsValidEmail(obj.Email)) {
        //                        var checkEmail = Context.Registration.Where(z => z.Email == obj.Email).FirstOrDefault();
        //                        if (checkEmail != null) {
        //                            response = new ResponseModel {
        //                                status = Status.Warning,
        //                                message = "Email Address already exists."
        //                            };
        //                            return response;
        //                        }
        //                        var checkMobile = Context.Registration.Where(z => z.MobileNo == obj.MobileNo).FirstOrDefault();
        //                        if (checkMobile != null) {
        //                            response = new ResponseModel {
        //                                status = Status.Warning,
        //                                message = "Mobile Number already exists."
        //                            };
        //                            return response;
        //                        }
        //                    }
        //                    else {
        //                        response = new ResponseModel {
        //                            status = Status.Warning,
        //                            message = "Email Address not correct."
        //                        };
        //                        return response;
        //                    }
        //                }
        //                var checkUsername = Context.Registration.Where(z => z.MobileNo == obj.MobileNo).FirstOrDefault();
        //                if (checkUsername == null) {
        //                    obj.CreatedDate = DateTime.Now;
        //                    Context.Registration.Add(obj);
        //                    response.status = Status.Success;
        //                    response.message = "Successfully Registered";                            
        //                }
        //                else {
        //                    response = new ResponseModel {
        //                        status = Status.Warning,
        //                        message = "Mobile Number already exists."
        //                    };
        //                    return response;
        //                }
        //                Context.SaveChanges();

        //            }


        //            if (reg != null) {
        //                response.status = Status.Success;
        //                response.data = reg;
        //                response.message = obj.RegistrationId > 0 ? "Updated successfully!  Thank you." : "Registered successfully!  Thank you.";
        //            }
        //            //  trans.Complete();



        //        }
        //        catch (Exception ex) {
        //            // trans.Dispose();
        //            throw ex;
        //        }
        //        finally {
        //            //    trans.Dispose();
        //        }
        //        // }
        //    }
        //    return response;
        //}





    }
}
