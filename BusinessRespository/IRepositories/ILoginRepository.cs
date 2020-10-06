
using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRespository.IRepositories {
    public interface ILoginRepository
    {
        ResponseModel RegisterUser(vmRegistration obj);
        ResponseModel LoginUser(vmLoginUser obj);
        ResponseModel UserOtpVerify(vmOtpVerify obj);
        ResponseModel UserResendOtp(vmResendOtp obj);

        ResponseModel UserForgotPassword(vmForgotPassword obj);

        ResponseModel UserChangePassword(vmChangePassword obj);

        List<getAllUser> GetAllUserDetails();
        ResponseModel UpdateRegisterUser(vmUserRegistration obj);

        ResponseModel ChangePassword(vmUserChangePassword obj);
        ResponseModel UserEmailOTPVerificationBySendMail(int? userId);
        ResponseModel sendForgotPasswordMail(string email);
      
       //void SaveAboutUsDetail(vmAboutUsDetail obj);
        //List<vmGetAboutUsDetail> GetAboutUsDetail();

        //Registration GetLoginUser(int userID);
        //List<Registration> GetVendorUsers(int? userID);
    }
}
