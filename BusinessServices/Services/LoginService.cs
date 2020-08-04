using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services
{
    public class LoginService : ILoginService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor _httpContextaccessor;
        private Registration SessionUser;
        private ResponseModel response;
        public LoginService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            _httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //{
            //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //}
        }

        public ResponseModel RegisterUser(vmRegistration obj)
         {
            try
            {
                var resultValue = new ResponseModel();
                resultValue =  _unitOfWork.LoginRepository.RegisterUser(obj);

                response.data = resultValue.data;
                response.message = resultValue.message;
                response.status = resultValue.status;
                          
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }

         public ResponseModel UserOtpVerify(vmOtpVerify obj)
         {
            try
            {
                var resultValue = new ResponseModel();
                resultValue =  _unitOfWork.LoginRepository.UserOtpVerify(obj);

                response.message = resultValue.message;
                response.status = resultValue.status;
                          
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }
         public ResponseModel UserResendOtp(vmResendOtp obj)
         {
            try
            {
                var resultValue = new ResponseModel();
                resultValue =  _unitOfWork.LoginRepository.UserResendOtp(obj);
                response = resultValue;
                          
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }

        //public ResponseModel updateRegisterUser(vmRegistration obj)
        //{
        //    ResponseModel result = new ResponseModel();
        //    try
        //    {
        //        obj.MobileNo = SessionUser.MobileNo;
        //        obj.RegistrationId = SessionUser.Id;

        //        var returnmessage = "";
        //        var resultValue = _unitOfWork.LoginRepository.RegisterUser(obj, out returnmessage);
        //        if (resultValue.Count > 0)
        //        {
        //            result.status = Status.Success;
        //            result.data = returnmessage;
        //            //if (obj.Flag != "IOTP") {
        //            //    //  var logindetail=  _unitOfWork.LoginRepository.GetLoginUser(int.Parse(resultValue));
        //            //    result.message = BusinessRespository.Utility.AuthUtilities.GenerateToken(resultValue.FirstOrDefault(), !string.IsNullOrEmpty(obj.MobileNo) ? obj.MobileNo : obj.Email);
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.data = ex.Message;
        //        result.status = Status.Error;
        //        result.message = "Credential not matched, please try again.";
        //    }
        //    return result;
        //}
        public ResponseModel LoginUser(vmLoginUser obj)
        {
           
            try
            {
                var resultValue = _unitOfWork.LoginRepository.LoginUser(obj);
                if (resultValue != null)
                {
                    response.status = Status.Success;
                    response.data = resultValue;
                    response.message = BusinessRespository.Utility.AuthUtilities.GenerateToken(resultValue, obj.Email);


                }
                else
                {
                    response.status = Status.Warning;
                    response.message = "Id and Password not matched, please try again.";
                }
            }
            catch (Exception ex)
            {
                response.data = null;
                response.status = Status.Error;
                response.message = ex.Message;
            }
            return response;
        }

        public ResponseModel UserForgotPassword(vmForgotPassword obj)
        {
            try
            {
                var resultValue = new ResponseModel();
                resultValue = _unitOfWork.LoginRepository.UserForgotPassword(obj);
                response = resultValue;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }

        public ResponseModel UserChangePassword(vmChangePassword obj)
        {
            try
            {
                var resultValue = new ResponseModel();
                resultValue = _unitOfWork.LoginRepository.UserChangePassword(obj);
                response = resultValue;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }


        public ResponseModel GetAllUserDetails()
        {
            try
            {
                var resultValue = _unitOfWork.LoginRepository.GetAllUserDetails();

                response.data = resultValue;
                response.status = Status.Success;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }


        
        public ResponseModel UpdateRegisterUser(vmUserRegistration obj)
        {
            try
            {
                var resultValue = new ResponseModel();
                resultValue = _unitOfWork.LoginRepository.UpdateRegisterUser(obj);
                response = resultValue;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }


        public ResponseModel ChangePassword(vmUserChangePassword obj)
        {
            try
            {
                var resultValue = new ResponseModel();
                resultValue = _unitOfWork.LoginRepository.ChangePassword(obj);
                response = resultValue;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }


        //public ResponseModel SaveAboutUsDetail(vmAboutUsDetail obj )
        //{
        //    try
        //    {
        //        _unitOfWork.LoginRepository.SaveAboutUsDetail(obj);

        //        response.status = Status.Success;
        //        response.message = "Save Abouts Page Detail";

        //    }
        //    catch (Exception ex)
        //    {
        //        response.message = ex.Message;
        //        response.status = Status.Error;
        //    }
        //    return response;
        //}

        //public ResponseModel GetAboutUsDetail()
        //{
        //    try
        //    {
        //        var resultValue = _unitOfWork.LoginRepository.GetAboutUsDetail();
        //        response.data = resultValue;            
        //        response.status = Status.Success;
        //        //response.message = "About Us Listing";

        //    }
        //    catch (Exception ex)
        //    {
        //        response.message = ex.Message;
        //        response.status = Status.Error;
        //    }
        //    return response;
        //}


        //public ResponseModel getUserdetails()
        //{
        //    ResponseModel result = new ResponseModel();

        //    try
        //    {
        //        var resultValue = _unitOfWork.LoginRepository.GetLoginUser(SessionUser.Id);
        //        if (resultValue != null)
        //        {
        //            result.status = Status.Success;
        //            result.data = resultValue;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.data = ex.Message;
        //        result.status = Status.Error;
        //        result.message = "Credential not matched, please try again.";
        //    }
        //    return result;
        //}
        //public ResponseModel Checknewuser()
        //{
        //    ResponseModel result = new ResponseModel();

        //    try
        //    {
        //        var resultValue = _unitOfWork.LoginRepository.GetLoginUser(SessionUser.Id);
        //        if (resultValue != null)
        //        {
        //            result.status = Status.Success;
        //            result.data = resultValue;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.data = ex.Message;
        //        result.status = Status.Error;
        //        result.message = "Credential not matched, please try again.";
        //    }
        //    return result;
        //}

        //public ResponseModel GetVendorUsers(int? userID)
        //{
        //    ResponseModel result = new ResponseModel();

        //    try
        //    {
        //        var resultValue = _unitOfWork.LoginRepository.GetVendorUsers(userID);
        //        if (resultValue != null)
        //        {
        //            result.status = Status.Success;
        //            result.data = resultValue;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.data = ex.Message;
        //        result.status = Status.Error;
        //        result.message = "Credential not matched, please try again.";
        //    }
        //    return result;

        //}
    }
}
