using BusinessDataModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.IServices {
   public interface ILoginService {
        ResponseModel RegisterUser(vmRegistration obj);
        ResponseModel LoginUser(vmLoginUser obj);
        ResponseModel UserOtpVerify(vmOtpVerify obj);

        ResponseModel UserResendOtp(vmResendOtp obj);

        ResponseModel UserForgotPassword(vmForgotPassword obj);

        ResponseModel UserChangePassword(vmChangePassword obj);

        ResponseModel GetAllUserDetails();

        ResponseModel UpdateRegisterUser(vmUserRegistration obj);

        ResponseModel ChangePassword(vmUserChangePassword obj);

        ResponseModel UserEmailOTPVerificationBySendMail(int? userId);


        ResponseModel sendForgotPasswordMail(string email);

        //ResponseModel SaveAboutUsDetail(vmAboutUsDetail obj);

        //ResponseModel GetAboutUsDetail();

        // ResponseModel getUserdetails();
        //ResponseModel updateRegisterUser(vmRegistration obj);
        //ResponseModel  GetVendorUsers(int? userID);
    }
}
