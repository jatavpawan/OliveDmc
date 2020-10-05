using System.Threading.Tasks;
using BusinessDataModel.ViewModel;
using BusinessServices.IServices;
using CookApp.Filters;

using Microsoft.AspNetCore.Mvc;

namespace CookApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomException))]
    public class LoginController : ControllerBase {

        private ILoginService _loginService ;
        public LoginController(ILoginService loginService) {
            _loginService = loginService;
        }
        //[HttpPost]
        //[Route("RegisterUser")]
        //public async Task<ResponseModel> RegisterUser(vmRegistration obj) {

        //    var Data = _loginService.RegisterUser(obj);
        //    return await System.Threading.Tasks.Task.FromResult(Data);
        //    //return null;
        //}

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ResponseModel> RegisterUser(vmRegistration obj)
        {
            var Data = _loginService.RegisterUser(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<ResponseModel> LoginUser(vmLoginUser obj)
        {
            var Data = _loginService.LoginUser(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("UserOtpVerify")]
        public async Task<ResponseModel> UserOtpVerify(vmOtpVerify obj)
        {
            var Data = _loginService.UserOtpVerify(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("UserResendOtp")]
        public async Task<ResponseModel> UserResendOtp(vmResendOtp obj)
        {
            var Data = _loginService.UserResendOtp(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("UserForgotPassword")]
        public async Task<ResponseModel> UserForgotPassword(vmForgotPassword obj)
        {
            var Data = _loginService.UserForgotPassword(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("UserChangePassword")]
        public async Task<ResponseModel> UserChangePassword(vmChangePassword obj)
        {
            var Data = _loginService.UserChangePassword(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllUserDetails")]
        public async Task<ResponseModel> GetAllUserDetails()
        {
            var Data = _loginService.GetAllUserDetails();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("UpdateRegisterUser")]
        public async Task<ResponseModel> UpdateRegisterUser([FromForm]vmUserRegistration obj)
        {
            var Data = _loginService.UpdateRegisterUser(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
        
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ResponseModel> ChangePassword(vmUserChangePassword obj)
        {
            var Data = _loginService.ChangePassword(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("UserEmailOTPVerificationBySendMail")]
        public async Task<ResponseModel> UserEmailOTPVerificationBySendMail(int? userId)
        {
            var Data = _loginService.UserEmailOTPVerificationBySendMail(userId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("sendForgotPasswordMail")]
        public async Task<ResponseModel> sendForgotPasswordMail(string email)
        {
            var Data = _loginService.sendForgotPasswordMail(email);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

       

    }
}